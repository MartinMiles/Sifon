using System;
using System.Management.Automation;
using Sifon.Abstractions.Formatters;

namespace Sifon.Code.Formatters.Text
{
    public class ProgressFormatter : IFormatter<ProgressRecord>
    {
        public string Format(ProgressRecord data)
        {
            var currentOperation = data.CurrentOperation != null
                ? $" - {data.CurrentOperation.Replace("  ", " ")}"
                : String.Empty;

            return $"{data.Activity}{currentOperation}";
        }
    }
}
