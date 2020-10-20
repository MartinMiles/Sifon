using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Plugins;
using Sifon.Code.Events;
using Sifon.Code.Helpers;
using Sifon.Code.Model;

namespace Sifon.Forms.MainForm
{
    partial class Main
    {
        #region Plugins features

        private Size MenuSize => new Size(180, 22);
        
        public void PopulateToolStripMenuItemWithPluginsAndScripts(PluginMenuItem pluginMenuItem)
        {
            pluginsToolStripMenuItem.DropDownItems.Clear();
            DirectorySearch(pluginMenuItem, pluginsToolStripMenuItem);

            MoveContainerPluginsIntoTheirOwnMenu(pluginsToolStripMenuItem);
        }

        private void MoveContainerPluginsIntoTheirOwnMenu(ToolStripMenuItem pluginsToolStripMenuItem)
        {
            var menuItemContainers = FindMenuItemByTopLevelName(pluginsToolStripMenuItem, "Containers");
            if (menuItemContainers != null)
            {
                menuContainerPlugins.DropDownItems.Clear();

                var copy = new ToolStripItem[menuItemContainers.DropDownItems.Count];
                menuItemContainers.DropDownItems.CopyTo(copy,0);
                foreach (var child in copy)
                {
                    menuContainerPlugins.DropDownItems.Add(child);
                }
                pluginsToolStripMenuItem.DropDownItems.Remove(menuItemContainers);
            }
        }

        private ToolStripMenuItem FindMenuItemByTopLevelName(ToolStripMenuItem pluginsToolStripMenuItem, string name)
        {
            foreach (ToolStripMenuItem menuItem in pluginsToolStripMenuItem.DropDownItems)
            {
                if (menuItem.Text == name)
                {
                    return menuItem;
                }
            }

            return null;
        }

        private void DirectorySearch(PluginMenuItem menuItem, ToolStripMenuItem parentMenuItem)
        {
            try
            {
                parentMenuItem.Name = menuItem.DirectoryFullPath;

                if (menuItem.DirectoryName == "Sifon.Plugins")
                {
                    menuItem.DirectoryName = parentMenuItem.Text;
                }

                parentMenuItem.Text = menuItem.DirectoryName;

                AddScriptsToMenu(menuItem.Scripts, parentMenuItem);
                AddPluginsToMenu(menuItem.Plugins, parentMenuItem);

                foreach (var itemChild in menuItem.Children)
                {
                    var dirToolStripMenuItem = new ToolStripMenuItem { Size = MenuSize };
                    DirectorySearch(itemChild, dirToolStripMenuItem);
                    parentMenuItem.DropDownItems.Add(dirToolStripMenuItem);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddPluginsToMenu(Dictionary<string, string> plugins, ToolStripMenuItem dirToolStripMenuItem)
        {
            var instances = new PluginHelper().LoadAllPlugins(plugins.Select(p => p.Key));

            foreach (var pluginInstance in instances)
            {
                var newToolStripMenuItem = new ToolStripMenuItem
                {
                    Name = pluginInstance.Name,
                    Text = pluginInstance.Name,
                    Size = MenuSize,
                    Tag = pluginInstance
                };

                newToolStripMenuItem.Click += PluginMenuClick;
                dirToolStripMenuItem.DropDownItems.Add(newToolStripMenuItem);
            }
        }

        private void AddScriptsToMenu(Dictionary<string,string> scripts, ToolStripMenuItem dirToolStripMenuItem)
        {
            foreach (var fileInfo in scripts)
            {
                var nameAndDescription = ReadScriptNameAndDescription(fileInfo.Key);

                var newToolStripMenuItem = new ToolStripMenuItem
                {
                    Name = fileInfo.Key,
                    Text = nameAndDescription?.Item1 ?? fileInfo.Value,
                    Size = MenuSize,
                    ToolTipText = nameAndDescription?.Item2 ?? String.Empty

                };
                newToolStripMenuItem.Click += scriptToolStripMenuItemToolStripMenuItem_Click;
                dirToolStripMenuItem.DropDownItems.Add(newToolStripMenuItem);
            }
        }

        private Tuple<string, string> ReadScriptNameAndDescription(string FilePath)
        {
            const string namePattern = @"^###\s*(?i)Name(?-i):\s*(.*)$";
            const string descPattern = @"^###\s*(?i)Description(?-i):\s*(.*)$";

            var tuple = new Tuple<string, string>(null, null);

            if (File.Exists(FilePath))
            {
                var lines = File.ReadLines(FilePath);
                if (lines.Any())
                {
                    var firstLine = lines.ElementAt(0);

                    var name = new RegexHelper(namePattern).Extract(firstLine);
                    tuple = new Tuple<string, string>(name, null);

                    if (lines.Count() > 1)
                    {
                        var secondLine = lines.ElementAt(1);
                        var description = new RegexHelper(descPattern).Extract(secondLine);
                        tuple = new Tuple<string, string>(name, description);
                    }
                }
            }

            return tuple;
        }

        private void scriptToolStripMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var scriptName = ((ToolStripItem)sender).Name;
            ScriptToolStripClicked(this, new EventArgs<string>(scriptName));
        }

        private void RemoveClickEvent(Button b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private async void PluginMenuClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem pluginMenuItem)
            {
                if (pluginMenuItem.Tag is BasePlugin plugin)
                {
                    BeginUI();

                    RemoveClickEvent(buttonStopScript);
                    buttonStopScript.Click += (_s, _e) => { plugin.CancellationTokenSource.Cancel(); FinishUI(); };

                    plugin.CancellationTokenSource = new CancellationTokenSource();
                    plugin.Progress = new Progress<PluginProgress>(PluginProgressUpdated);

                    try
                    {
                        await Task.Run((Action)plugin.Execute, plugin.CancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                    }

                    FinishUI();
                }
                else
                {
                    ((IPlugin)pluginMenuItem.Tag).Execute();
                }
            }
        }

        private void PluginProgressUpdated(PluginProgress progress)
        {
            UpdateProgressBar(progress.PercentDone, progress.Activity);

            if (progress.Messages != null)
            {
                foreach (var message in progress.Messages)
                {
                    AppendLine(message, Color.Yellow);
                }
            }
        }

        #endregion
    }
}
