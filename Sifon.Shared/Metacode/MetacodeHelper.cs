using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Sifon.Shared.Extensions;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Metacode
{
    public class MetacodeHelper
    {
        private readonly IEnumerable<string> _meta;

        public MetacodeHelper(string scriptPath)
        {
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException($"File does not exist: {scriptPath}");
            }

            _meta = File.ReadAllLines(scriptPath).Where(l => l.StartsWith("###")).Select(s => s.Trim());
        }

        public Dictionary<string, object> ExecuteMetacode()
        {
            var dynamicResultsDictionary = new Dictionary<string, object>();
            var regex = new Regex(Settings.Regex.Plugins.MetacodeSynthax);

            foreach (string line in _meta)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    var output = match.Groups[1].Value;
                    var type = match.Groups[2].Value;
                    var method = match.Groups[3].Value;
                    var methodParameters = match.Groups[4].Value;

                    var list = new List<object>();
                    if (!string.IsNullOrWhiteSpace(methodParameters))
                    {
                        var paramsArray = methodParameters.Split(',');
                        
                        foreach (string parameter in paramsArray)
                        {
                            list.Add(parameter.Trim('\"'));
                        }
                    }

                    var dynamicMethodOutput = DynamicCodeRunner.RunWithClassicSharpCodeProvider(type, method, list.ToArray());
                    if (output.NotEmpty() && dynamicMethodOutput != null)
                    {
                        dynamicResultsDictionary.Add(output, dynamicMethodOutput);
                    }
                }
            }

            return dynamicResultsDictionary;
        }

        public IEnumerable<string> IdentifyDependencies()
        {
            var list = new List<string>();

            var regex = new Regex(Settings.Regex.Plugins.DependenciesToExtract);

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
