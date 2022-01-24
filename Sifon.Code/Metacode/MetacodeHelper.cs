using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Sifon.Abstractions.Metacode;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;
using Sifon.Code.Helpers;
using Sifon.Code.Model;

namespace Sifon.Code.Metacode
{
    internal class MetacodeHelper: IMetacodeHelper
    {
        private readonly IEnumerable<string> _meta;
        private readonly string[] powerShellBooleans = { "$true", "$false" };

        private readonly string _scriptPath;

        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }

        public bool DisplayLocalOnly
        {
            get
            {
                var regex = new Regex(Settings.Regex.Metacode.DisplayLocalOnly, RegexOptions.IgnoreCase);
                return _meta.Any(l => regex.Match(l).Success);
            }
        }
        public bool ExecuteLocalOnly
        {
            get
            {
                var regex = new Regex(Settings.Regex.Metacode.ExecuteLocalOnly, RegexOptions.IgnoreCase);
                return _meta.Any(l => regex.Match(l).Success);
            }
        }
        public bool RequiresProfile
        {
            get
            {
                bool prequiresProfile = true;

                var regex = new Regex(Settings.Regex.Metacode.RequiresProfile, RegexOptions.IgnoreCase);
                //return _meta.Any(l => regex.Match(l).Success);

                foreach (string line in _meta)
                {
                    if (line.StartsWith("###") 
                        && line.IndexOf("Requires Profile:", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var matchCollection = regex.Matches(line);

                        foreach (Match match in matchCollection)
                        {
                            var _bool = match.Groups[1].Value;
                            Boolean.TryParse(_bool, out prequiresProfile);
                            
                        }
                    }
                }

                return prequiresProfile;
            }
        }

        public bool IsCompatibleVersion
        {
            get
            {
                var regex = new Regex(Settings.Regex.Metacode.Compatibility, RegexOptions.IgnoreCase);

                foreach (string line in _meta)
                {
                    var match = regex.Match(line);
                    if (match.Success)
                    {
                        var minimalSupported = new ProductVersion(match.Groups[1].Value);
                        var thisProduct = new ProductVersion(Settings.VersionNumber);
                        return thisProduct >= minimalSupported;
                    }
                }

                return true;
            }
        }

        private string ScriptFolder => Path.GetDirectoryName(_scriptPath);

        #endregion

        internal MetacodeHelper(string scriptPath)
        {
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException($"File does not exist: {scriptPath}");
            }

            _scriptPath = scriptPath;
            _meta = File.ReadAllLines(scriptPath).Where(l => l.StartsWith("###")).Select(s => s.Trim());

            ReadScriptNameAndDescription();
        }

        private void ReadScriptNameAndDescription()
        {
            if (_meta.Any())
            {
                Name = new RegexHelper(Settings.Regex.Metacode.Name).Extract(_meta.ElementAt(0));

                if (_meta.Count() > 1)
                {
                    Description = new RegexHelper(Settings.Regex.Metacode.Description).Extract(_meta.ElementAt(1));
                }
            }
        }
        
        public IDictionary<string, object> ExecuteMetacode(IDictionary<string, dynamic> parameters, string winformsAssemblyLocation)
        {
            var dynamicResultsDictionary = new Dictionary<string, object>();
            var regex = new Regex(Settings.Regex.Metacode.ExecutableFunction);

            foreach (string line in _meta)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    var output = match.Groups[1].Value;
                    var type = match.Groups[2].Value;
                    var method = match.Groups[3].Value;
                    var methodParameters = match.Groups[4].Value;
                    var list = ExtractParameters(parameters, methodParameters).ToArray();

                    var dynamicMethodOutput = DynamicCodeRunner.RunWithClassicSharpCodeProvider(type, method, list, winformsAssemblyLocation);
                    if (output.NotEmpty() && dynamicMethodOutput != null)
                    {
                        dynamicResultsDictionary.Add(output, dynamicMethodOutput);
                    }
                }
            }

            return dynamicResultsDictionary;
        }

        private object[] ExtractParameters(IDictionary<string, dynamic> parameters, string methodParameters)
        {
            var list = new List<object>();
            if (!string.IsNullOrWhiteSpace(methodParameters))
            {
                var stringValuePattern = new Regex(Settings.Regex.Metacode.Parameter);

                foreach (string parameter in ExtractCommaSeparatedFunctionParams(methodParameters))
                {
                    var param = parameter.Trim();
                    string key = param.Trim('$');

                    if (stringValuePattern.IsMatch(param))
                    {
                        list.Add(ExpandTokensWithinStringValues(param.Trim('\"'), parameters));
                    }
                    else if(powerShellBooleans.Contains(param.ToLower()))
                    {
                        bool boolValue = bool.TryParse(key, out boolValue) && boolValue;
                        list.Add(boolValue);
                    }
                    else
                    {
                        if (parameters.ContainsKey(key))
                        {
                            list.Add(parameters[key]);
                        }
                    }
                }
            }

            return list.ToArray();
        }

        private IEnumerable<string> ExtractCommaSeparatedFunctionParams(string methodParameters)
        {
            var regex = new Regex(Settings.Regex.Metacode.FunctionParametersToExtract, RegexOptions.Compiled);
                
            var matchCollection = regex.Matches(methodParameters);
            foreach (Match match in matchCollection)
            {
                yield return match.Groups[1].Value;
            }
        }

        private string ExpandTokensWithinStringValues(string parameter, IDictionary<string, dynamic> parameters)
        {
            foreach (var param in parameters)
            {
                if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(parameter, $"${param.Key}", CompareOptions.IgnoreCase) >= 0)
                {
                    parameter = Regex.Replace(parameter, $"\\${param.Key}", param.Value, RegexOptions.IgnoreCase);
                }
            }

            parameter = Regex.Replace(parameter, $"\\$PSScriptRoot", ScriptFolder, RegexOptions.IgnoreCase);


            return parameter;
        }


        public IEnumerable<string> IdentifyDependencies()
        {
            var list = new List<string>();

            var regex = new Regex(Settings.Regex.Metacode.DependenciesToExtract);

            foreach (string line in _meta)
            {
                if (line.StartsWith("### Dependencies:"))
                {
                    var matchCollection = regex.Matches(line);

                    foreach (Match match in matchCollection)
                    {
                        var files = match.Groups[1].Value;
                        if (!string.IsNullOrWhiteSpace(files))
                        {
                            var paramsArray = files.Split(',');
                            foreach (string parameter in paramsArray)
                            {
                                list.Add(parameter.Trim().Trim('\"'));
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}
