using System;
using System.Management.Automation;

namespace Sifon.Shared.Formatters.Text
{
    public class ProgressFormatter
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
