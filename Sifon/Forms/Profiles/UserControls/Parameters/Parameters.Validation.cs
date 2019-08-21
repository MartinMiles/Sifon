using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    public partial class Parameters
    {
        #region Passive validation on text changed and character entered

        private void UpdateButton(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && (textBox.Name.StartsWith(Settings.Profiles.Parameters.KeyPrefix) || textBox.Name.StartsWith(Settings.Profiles.Parameters.ValPrefix)))
            {
                var idx = textBox.Name.Substring(3);
                int rowIndex = int.TryParse(idx, out rowIndex) ? rowIndex : -1;

                if (rowIndex > -1)
                {
                    var key = Find(Settings.Profiles.Parameters.KeyPrefix, lines - 1);
                    var val = Find(Settings.Profiles.Parameters.ValPrefix, lines - 1);

                    if (key != null && val != null)
                    {
                        buttonAddPair.Enabled = !key.IsEmpty() && !val.IsEmpty();
                    }
                }
            }
        }

        private void ValidateParameterName(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (character == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
            else if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), Pattern.Filter.SpecialCharacters.Except.Underscores))
            {
                e.Handled = true;
            }

            linkLabelSampleDownload.Enabled = false;
        }

        private void MoveNext(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buttonAddPair.PerformClick();
            }
        }

        #endregion

        public bool ValidateValues()
        {
            var knownNames = Settings.Parameters.AsDictionary().Keys;

            var messages = new List<string>();

            try
            {
                foreach (var value in Values)
                {
                    
                    if (!Regex.IsMatch(value.Key, Pattern.PowerShell.ParameterName))
                    {
                        messages.Add($"{value.Key} {Validation.Profiles.Parameters.IncorrectParameterName}");
                    }

                    if (knownNames.Contains(value.Key))
                    {
                        messages.Add($"{value.Key} {Validation.Profiles.Parameters.NameAlreadyDefined}");
                    }
                }
            }
            catch (ArgumentException e)
            {
                messages.Add(Validation.Profiles.Parameters.DuplicatesNotAllowed);
            }

            return ShowValidationError(messages);
        }
    }
}
