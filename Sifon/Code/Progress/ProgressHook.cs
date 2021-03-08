using System;
using System.Collections.Generic;

namespace Sifon.Code.Progress
{
    /// <summary>
    /// This class is used as the last resort for displaying the progress when it is not coming either with stream or at all.
    /// In that case we can hook some progress values to some specific output lines, as well as format those for progress status.
    /// </summary>
    internal class ProgressHook
    {
        internal IDictionary<string, int> Replacements;
        internal string ReplacementPattern = String.Empty;

        public ProgressHook(string replacementPattern)
        {
            if (string.IsNullOrWhiteSpace(replacementPattern))
            {
                throw new ArgumentException("replacementPattern should not be an empty string");
            }

            Replacements = new Dictionary<string, int>();
            ReplacementPattern = replacementPattern;
        }
    }
}
