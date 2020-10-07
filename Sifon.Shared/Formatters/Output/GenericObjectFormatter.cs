using System;
using System.Management.Automation;
using System.Text;

namespace Sifon.Code.Formatters.Output
{
    internal class GenericObjectFormatter : IOutputFormatter
    {
        private readonly PSObject _object;

        public GenericObjectFormatter(PSObject objectToFormat)
        {
            _object = objectToFormat;
        }

        public string Format()
        {
            var stringBuilder = new StringBuilder();
            foreach (var prop in _object.Properties)
            {
                try
                {
                    stringBuilder.AppendLine($"{prop.Name}\t{prop.Value}");
                }
                catch (Exception e)
                {
                    stringBuilder.AppendLine(e.Message);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
