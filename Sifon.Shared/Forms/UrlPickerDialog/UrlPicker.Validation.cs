using System;
using System.Collections.Generic;

namespace Sifon.Shared.Forms.UrlPickerDialog
{
    partial class UrlPicker
    {
        #region Passive validation on text changed and character entered

        protected void AddPassiveValidationHandlers()
        {
            UrlTextbox.TextChanged += TextHasChanged;
        }

        private bool IsValid(string urlToValidate)
        {
            Uri uriResult;
            return Uri.TryCreate(urlToValidate, UriKind.Absolute, out uriResult)
                   && (!OnlyHttp || uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                   && (!OnlyFile || urlToValidate.ToLower().EndsWith(".zip"));
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = Url.Length > 0 && IsValid(Url.Trim());
            buttonInstall.Enabled = buttonsEnabled;
            buttonInstall.Focus();
        }

        #endregion

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;


        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!IsValid(Url))
            {
                _validationMessages.Add("Please make sure your URL is in correct format");
            }

            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}

