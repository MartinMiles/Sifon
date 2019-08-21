using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Shared.Statics;

namespace Sifon.Extensions
{
    internal static class TextBoxExtensions
    {
        internal static bool IsEmpty(this TextBox textBox)
        {
            return textBox.Text.Trim().Length == 0;
        }

        internal static bool ValidateNotEmpty(this TextBox textBox, string inputFriendlyName, IList<string> validationMessages)
        {
            textBox.Text = textBox.Text.Trim();

            bool notEmpty = textBox.Text.Length > 0;

            if (!notEmpty)
            {
                validationMessages.Add($"{inputFriendlyName} {Validation.General.ShouldNotBeEmpty}");
            }

            return notEmpty;
        }

        internal static bool ValidateRegex(this TextBox textBox, string pattern)
        {
            textBox.Text = textBox.Text.Trim();

            bool doesMatch = Regex.IsMatch(textBox.Text, pattern);
            return doesMatch;
        }
    }
}
