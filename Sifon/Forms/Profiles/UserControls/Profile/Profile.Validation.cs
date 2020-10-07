using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    partial class Profile
    {
        #region Passive validation on text changed and character entered

        public override void AddPassiveValidationHandlers()
        {
            textProfileName.KeyPress += ValidateNameKeyPress;
            textProfileName.KeyUp += EnsureNameNotChangedForDelete;
            textPrefix.KeyPress += ValidatePrefixKeyPress;

            textProfileName.TextChanged += TextHasChanged;
            textPrefix.TextChanged += TextHasChanged;
            textAdminUsername.TextChanged += TextHasChanged;
            textAdminPassword.TextChanged += TextHasChanged;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void ValidateNameKeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateKeyPress(e, Pattern.Filter.SpecialCharacters.Except.ProfileNameDisallowed);
        }

        private void ValidatePrefixKeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateKeyPress(e, Pattern.Filter.SpecialCharacters.Except.DotsDashes);
        }

        private void ValidateKeyPress(KeyPressEventArgs e, string regexPattern)
        {
            char character = e.KeyChar;
            if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), regexPattern))
            {
                e.Handled = true;
            }
        }

        private void EnsureNameNotChangedForDelete(object sender, KeyEventArgs e)
        {
            linkDelete.Enabled = textProfileName.Text == comboProfiles.SelectedItem.ToString();
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = textProfileName.Text.Length > 0 
                                  && textPrefix.Text.Length > 0 
                                  && textAdminUsername.Text.Length > 0 
                                  && textAdminPassword.Text.Length > 0;
            
            buttonRename.Enabled = buttonsEnabled;

            Presenter.EnableSaveButton(buttonsEnabled);
        }

        #endregion

        public bool ValidateValues()
        {
            var messages = new List<string>();

            if (!Regex.IsMatch(textProfileName.Text, Pattern.Profile.Name))
            {
                messages.Add(Validation.Profiles.Profile.Name);
            }
            if (!Regex.IsMatch(textPrefix.Text, Pattern.Profile.Prefix))
            {
                messages.Add(Validation.Profiles.Profile.Prefix);
            }
            if (!Regex.IsMatch(textAdminUsername.Text, Pattern.Profile.AdminUsername))
            {
                messages.Add(Validation.Profiles.Profile.Prefix);
            }
            if (!Regex.IsMatch(textAdminPassword.Text, Pattern.Profile.AdminPassword))
            {
                messages.Add(Validation.Profiles.Profile.Prefix);
            }
            
            return ShowValidationError(messages);
        }
    }
}
