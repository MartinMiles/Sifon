using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Code.Extensions;

namespace Sifon.Forms.Install
{
    partial class Install
    {
        const string ValidIpAddressRegex = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
        const string ValidHostnameRegex = @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$";

        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
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

            textRemoteHostname.TextChanged += RemotingTextHasChanged;
            textRemoteUsername.TextChanged += RemotingTextHasChanged;
            textRemotePassword.TextChanged += RemotingTextHasChanged;

            sqlServerText.TextChanged += SqlTextHasChanged;
            sqlServerUsernameText.TextChanged += SqlTextHasChanged;
            sqlServerPasswordText.TextChanged += SqlTextHasChanged;

            solrRootFolderText.TextChanged += SolrTextHasChanged;
            solrServiceText.TextChanged += SolrTextHasChanged;
            solrUrlText.TextChanged += SolrTextHasChanged;
        }

        protected void AddPassiveValidationHandlersForRemoting()
        {

        }

        protected void AddPassiveValidationHandlersForSQL()
        {

        }

        protected void AddPassiveValidationHandlersForSolr()
        {

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
        private void RemotingTextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
            UpdateRemotingButtonsState();
            UpdateSqlButtonsState();
            UpdateSolrButtonsState();
        }

        private void SqlTextHasChanged(object sender, EventArgs e)
        {
            UpdateSqlButtonsState();
        }

        private void SolrTextHasChanged(object sender, EventArgs e)
        {
            UpdateSolrButtonsState();
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

                                  && IsValid(solrUrlText.Text.Trim())

                                  && IsRemotingBlockValid();

            buttonInstall.Enabled = buttonsEnabled;
        }

        private void UpdateRemotingButtonsState()
        {
            buttonTestRemoting.Enabled = IsRemotingBlockValid();
            buttonSolrFolder.Enabled = IsRemotingBlockValid();
            targetFolderButton.Enabled = IsRemotingBlockValid();
        }

        private void UpdateSqlButtonsState()
        {
            buttonTestSQL.Enabled = IsRemotingBlockValid()
                                    && sqlServerText.Text.NotEmpty()
                                    && sqlServerUsernameText.Text.NotEmpty()
                                    && sqlServerPasswordText.Text.NotEmpty();
        }

        private void UpdateSolrButtonsState()
        {
            buttonTestSolr.Enabled = IsRemotingBlockValid() 
                                     && solrRootFolderText.Text.NotEmpty()
                                    && solrServiceText.Text.NotEmpty()
                                    && solrUrlText.Text.NotEmpty()
                                    && IsValid(solrUrlText.Text.Trim());
        }

        private bool IsRemotingBlockValid()
        {
            if (checkBoxRemote.Checked)
            {
                return RemoteHost.NotEmpty() 
                       && RemoteUsername.NotEmpty() 
                       && RemotePassword.NotEmpty();
            }

            return true;
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
        private bool IsValidTextBox(TextBox textBox)
        {
            var value = textBox.Text.Trim();

            if (textBox.Name == textRemoteHostname.Name)
            {
                return Regex.IsMatch(value, ValidIpAddressRegex) || Regex.IsMatch(value, ValidHostnameRegex);
            }

            if (textBox.Name == textRemoteUsername.Name)
            {
                return !string.IsNullOrWhiteSpace(value);
            }

            if (textBox.Name == textRemotePassword.Name)
            {
                return !string.IsNullOrWhiteSpace(value);
            }

            return false;
        }
        private bool ValidateTestRemoting()
        {
            _validationMessages = new List<string>();

            if (!IsValidTextBox(textRemoteHostname))
            {
                _validationMessages.Add("Please make sure remote hostname or IP address are correct");
            }

            if (!IsValidTextBox(textRemoteUsername))
            {
                _validationMessages.Add("Please make sure remote machine username is not empty");
            }

            if (!IsValidTextBox(textRemotePassword))
            {
                _validationMessages.Add("Please make sure remote machine password is not empty");
            }

            return ShowValidationError(_validationMessages);
        }
        #endregion
    }
}
