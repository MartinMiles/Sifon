﻿using System;
using System.IO;
using System.Windows.Forms;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Shared.Forms.SitecoreVersionSelectorDialog;

namespace Sifon.Plugins.Example.ShareAPI
{
    public class SharedApiExample : BasePlugin, IPlugin
    {
        public SharedApiExample(IProfile profile) : base(profile)
        {
        }

        public string Name => "Shared API example";

        internal const string Kernel = "Sitecore.Kernel.dll";
        
        internal string BinFolder => Path.Combine(Profile.Webroot, "bin");
        internal string KernelPath => Path.Combine(BinFolder, Kernel);

        public override void Execute()
        {
            var version = String.Empty;
            string selectedPath = String.Empty;

            var versionSelector = new SitecoreVersionSelector { StartPosition = FormStartPosition.CenterParent, _kernelPath = KernelPath };

            if (versionSelector.ShowDialog() == DialogResult.OK)
            {
                version = versionSelector._selectedVersion.Product;
                var browser = new FolderBrowser(Profile, true) { StartPosition = FormStartPosition.CenterParent, Text = "Select folder" };
                selectedPath = browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : String.Empty;
            }

            MessageBox.Show($" Verson: {version}{Environment.NewLine} Selected path: {selectedPath}");
        }
    }
}
