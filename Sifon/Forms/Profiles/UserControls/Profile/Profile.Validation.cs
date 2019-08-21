using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    partial class Profile
    {
        #region Passive validation on text changed and character entered

        public override void AddPassiveValidationHandlers()
        {
            textProfileName.KeyPress += ValidateNameAndPrefixKeyPress;
            textProfileName.KeyUp += EnsureNameNotChangedForDelete;
            textPrefix.KeyPress += ValidateNameAndPrefixKeyPress;

            textProfileName.TextChanged += TextHasChanged;
            textPrefix.TextChanged += TextHasChanged;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void ValidateNameAndPrefixKeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), Pattern.Filter.SpecialCharacters.Except.DotsDashes))
            {
                e.Handled = true;
            }
        }

        private void EnsureNameNotChangedForDelete(object sender, KeyEventArgs e)
        {
            buttonDelete.Enabled = textProfileName.Text == comboProfiles.SelectedItem.ToString();
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = textProfileName.Text.Length > 0 && textPrefix.Text.Length > 0;
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
            
            return ShowValidationError(messages);
        }
    }
}
