using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifon.Code.Statics;
using Sifon.Extensions;
using Sifon.Statics;

namespace Sifon.Forms.SQL
{
    internal partial class InstallSQL
    {
        /*
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

        */

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;

        
        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!textInstance.ValidateRegex(Pattern.InstallDatabase.Instance))
            {
                _validationMessages.Add(Validation.InstallDatabase.Instance);
            }
            if (!textPassword.ValidateRegex(Pattern.InstallDatabase.Password))
            {
                _validationMessages.Add(Validation.InstallDatabase.Password);
            }
           
            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}