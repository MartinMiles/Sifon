using System;
using System.Collections.Generic;
using System.Reflection;
using Sifon.Abstractions.Plugins;
using Sifon.Code.Factories;
using Sifon.Code.Model.Profiles;

namespace Sifon.Code.Helpers
{
    public class PluginHelper
    {
        //private readonly PluginFactory _pluginFactory;

        //public PluginHelper()
        //{
        //    //_pluginFactory = new PluginFactory();
        //}

        public ICollection<IPlugin> LoadAllPlugins(IEnumerable<string> dllFileNames)
        {
            var assemblies = LoadAssemblies(dllFileNames);
            var pluginTypes = LoadPlugins(assemblies);
            return InstantiatePlugins(pluginTypes);
        }

        private ICollection<Assembly> LoadAssemblies(IEnumerable<string> dllFileNames)
        {
            var assemblies = new List<Assembly>();
            foreach (string dllFile in dllFileNames)
            {
                var assemblyName = AssemblyName.GetAssemblyName(dllFile);
                var assembly = Assembly.Load(assemblyName);
                assemblies.Add(assembly);
            }

            return assemblies;
        }

        private ICollection<Type> LoadPlugins(ICollection<Assembly> assemblies)
        {
            Type pluginType = typeof(IPlugin);
            ICollection<Type> pluginTypes = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    try
                    {
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                    catch (ReflectionTypeLoadException e)
                    {
                    }
                }
            }

            return pluginTypes;
        }

        private ICollection<IPlugin> InstantiatePlugins(ICollection<Type> pluginTypes)
        {
            ICollection<IPlugin> plugins = new List<IPlugin>(pluginTypes.Count);
            foreach (Type type in pluginTypes)
            {
                try
                {
                    var plugin = Create.WithProfile<IPlugin>();  // _pluginFactory.Create(type);

                    if (plugin != null)
                    {
                        plugins.Add(plugin);
                    }
                }
                catch (Exception e)
                {
                    // we cannot trust external plugins written by third parties have defined signature,
                    // so if incompatible - just carry on with others
                }
            }

            return plugins;
        }
    }
}
