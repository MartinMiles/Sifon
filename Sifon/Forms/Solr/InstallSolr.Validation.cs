using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Code.Statics;
using Sifon.Extensions;
using Sifon.Statics;

namespace Sifon.Forms.Solr
{
    partial class InstallSolr
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textPort.KeyPress += NameAndPrefixKeyPress;
        }

        private void NameAndPrefixKeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), GetFilterPattern(((TextBox)sender).Name)))
            {
                e.Handled = true;   // Stop the character from being entered into the control since it is illegal.
            }
        }

        private string GetFilterPattern(string name)
        {
            if (name == textPort.Name)
            {
                return Pattern.InstallSolr.Port;
            }

            throw new ArgumentOutOfRangeException($"Control is not supporthe for passive validation: {name}");
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = textPort.Text.Length > 0
                                  && textFolder.Text.Length > 0
                                  && textFolderSuffix.Text.Length > 0;

            buttonInstall.Enabled = buttonsEnabled;
        }

        #endregion

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;


        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!textFolder.ValidateRegex(Pattern.InstallSolr.Folder))
            {
                _validationMessages.Add(Validation.InstallSolr.Folder);
            }
            if (!textPort.ValidateRegex(Pattern.InstallSolr.Port))
            {
                _validationMessages.Add(Validation.InstallSolr.Port);
            }
           
            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}
