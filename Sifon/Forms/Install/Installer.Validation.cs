using System;
using System.Collections.Generic;
using System.IO;

namespace Sifon.Forms.Install
{
    partial class Install
    {
        #region Passive validation on text changed and character entered

        protected void AddPassiveValidationHandlers()
        {
            prefixText.TextChanged += TextHasChanged;
            sitecoreSiteText.TextChanged += TextHasChanged;
            xconnectText.TextChanged += TextHasChanged;
            identityServerText.TextChanged += TextHasChanged;

            textDestinationFolder.TextChanged += TextHasChanged;
            licenseTextbox.TextChanged += TextHasChanged;
            adminPasswordText.TextChanged += TextHasChanged;

            solrUrlText.TextChanged += TextHasChanged;
            solrServiceText.TextChanged += TextHasChanged;
            solrRootFolderText.TextChanged += TextHasChanged;

            sqlServerText.TextChanged += TextHasChanged;
            sqlServerUsernameText.TextChanged += TextHasChanged;
            sqlServerPasswordText.TextChanged += TextHasChanged;
        }

        private bool IsValid(string urlToValidate)
        {
            Uri uriResult;
            return Uri.TryCreate(urlToValidate, UriKind.Absolute, out uriResult);
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool buttonsEnabled = solrUrlText.Text.Length > 0 
                                  && solrServiceText.Text.Length > 0
                                  && solrRootFolderText.Text.Length > 0
                                  
                                  && textDestinationFolder.Text.Length > 0
                                  && licenseTextbox.Text.Length > 0
                                  && adminPasswordText.Text.Length > 0
                                  
                                  && sqlServerText.Text.Length > 0
                                  && sqlServerUsernameText.Text.Length > 0
                                  && sqlServerPasswordText.Text.Length > 0
                                  
                                  && prefixText.Text.Length > 0
                                  && sitecoreSiteText.Text.Length > 0
                                  && xconnectText.Text.Length > 0
                                  && identityServerText.Text.Length > 0

                                  && IsValid(solrUrlText.Text.Trim());

            buttonInstall.Enabled = buttonsEnabled;
            //buttonInstall.Focus();
        }

        #endregion

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;


        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!IsValid(solrUrlText.Text.Trim()))
            {
                _validationMessages.Add("Please make sure your URL is in correct format");
            }

            if (!File.Exists(licenseTextbox.Text.Trim()))
            {
                _validationMessages.Add("License file foes not exist at the provided path");
            }

            return ShowValidationError(_validationMessages);
        }

        #endregion
    }
}
