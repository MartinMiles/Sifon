using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.PortalCredentials
{
    partial class PortalCredentials
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textUsername.KeyPress += NameAndPrefixKeyPress;
            textPassword.KeyPress += NameAndPrefixKeyPress;

            textUsername.TextChanged += TextHasChanged;
            textPassword.TextChanged += TextHasChanged;
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
            if (name == textUsername.Name)
            {
                return Pattern.Filter.SpecialCharacters.Except.DotsDashesAmpersand;
            }
            if (name == textPassword.Name)
            {
                return Pattern.Filter.Whitespaces;
            }

            throw new ArgumentOutOfRangeException($"Control is not supporthe for passive validation: {name}");
        }


        private void UpdateButtonsState()
        {
            bool buttonsEnabled = textUsername.Text.Length > 0 && textPassword.Text.Length > 0;

            buttonTest.Enabled = buttonsEnabled;
            buttonSave.Enabled = buttonsEnabled;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        #endregion

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;


        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!textUsername.ValidateRegex(Pattern.PortalCredentials.Username))
            {
                _validationMessages.Add(Validation.PortalCredentials.Username);
            }
            if (!textPassword.ValidateRegex(Pattern.PortalCredentials.Password))
            {
                _validationMessages.Add(Validation.PortalCredentials.Password);
            }
            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}
