using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Containers
{
    partial class DockerProfiles
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textProfileName.KeyPress += NameAndPrefixKeyPress;
            textRepositoryUrl.KeyPress += NameAndPrefixKeyPress;
            textRepositoryFolder.KeyPress += NameAndPrefixKeyPress;
            textAdminPassword.KeyPress += NameAndPrefixKeyPress;
            textSaPassword.KeyPress += NameAndPrefixKeyPress;

            textProfileName.TextChanged += TextHasChanged;
            textRepositoryUrl.TextChanged += TextHasChanged;
            textRepositoryFolder.TextChanged += TextHasChanged;
            textAdminPassword.TextChanged += TextHasChanged;
            textSaPassword.TextChanged += TextHasChanged;
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
            if (name == textProfileName.Name)
            {
                return Pattern.Filter.SpecialCharacters.Except.ProfileNameDisallowed;
            }            
            if (name == textRepositoryUrl.Name)
            {
                return Pattern.Filter.SpecialCharacters.Except.ForbiddenInURL;
            }
            if (name == textRepositoryFolder.Name)
            {
                return Pattern.Filter.Whitespaces;
            }
            if (name == textAdminPassword.Name)
            {
                return Pattern.Filter.Whitespaces;
            }
            if (name == textSaPassword.Name)
            {
                return Pattern.Filter.Whitespaces;
            }

            throw new ArgumentOutOfRangeException($"Control is not supporthe for passive validation: {name}");
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = textProfileName.Text.Length > 0
                                  && textRepositoryUrl.Text.Length > 0
                                  //&& textRepositoryFolder.Text.Length > 0 - can be blank
                                  && textAdminPassword.Text.Length > 0
                                  && textSaPassword.Text.Length > 0;

            buttonAddRename.Enabled = buttonsEnabled;
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

            if (!textProfileName.ValidateRegex(Pattern.DockerProfile.Name))
            {
                _validationMessages.Add(Validation.DockerProfiles.Name);
            }
            if (!textRepositoryUrl.ValidateRegex(Pattern.DockerProfile.RepositoryUrl))
            {
                _validationMessages.Add(Validation.DockerProfiles.RepositoryUrl);
            }            
            if (!textRepositoryFolder.ValidateRegex(Pattern.DockerProfile.Folder))
            {
                _validationMessages.Add(Validation.DockerProfiles.Folder);
            }
            if (!textAdminPassword.ValidateRegex(Pattern.DockerProfile.Password))
            {
                _validationMessages.Add(Validation.PortalCredentials.Password);
            }
            if (!textSaPassword.ValidateRegex(Pattern.DockerProfile.Password))
            {
                _validationMessages.Add(Validation.PortalCredentials.Password);
            }
            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}
