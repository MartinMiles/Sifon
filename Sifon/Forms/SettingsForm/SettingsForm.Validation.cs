using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.SettingsForm
{
    partial class SettingsForm
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textRepository.TextChanged += RepositoryChanged;
        }

        private void RepositoryChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = textRepository.Text.Length > 0;
        }

        #endregion

        public bool ValidateValues()
        {
            var messages = new List<string>();

            if (!Regex.IsMatch(textRepository.Text, Pattern.SettingsForm.PluginsRepository))
            {
                messages.Add(Validation.SettingsForm.PluginsRepository);
            }

            return ShowValidationError(messages);
        }
    }
}
