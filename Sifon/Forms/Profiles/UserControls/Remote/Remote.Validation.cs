using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Shared.Extensions;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    partial class Remote
    {
        #region Passive validation on text changed and character entered

        public override void AddPassiveValidationHandlers()
        {
            textHostname.KeyUp += ValidateNotEmpty;
            textUsername.KeyUp += ValidateNotEmpty;
            textPassword.KeyUp += ValidateNotEmpty;
        }

        private void ValidateNotEmpty(object sender, KeyEventArgs e)
        {
            ValidateNotEmpty();
        }

        private void ValidateNotEmpty()
        {
            bool buttonEnabled = !checkBoxRemote.Checked || !textHostname.IsEmpty() && !textUsername.IsEmpty() && !textPassword.IsEmpty();
            Presenter.EnableSaveButton(buttonEnabled);

            UpdateButtons();
        }

        public bool TestButtonEnabled => checkBoxRemote.Checked && !textHostname.IsEmpty() && !textUsername.IsEmpty() && !textPassword.IsEmpty();
        public bool InitButtonEnabled => checkBoxRemote.Checked && !textHostname.IsEmpty() && !textUsername.IsEmpty() && !textPassword.IsEmpty();

        #endregion

        public bool ValidateValues()
        {
            var messages = new List<string>();

            if (RemotingEnabled && !RemoteHost.NotEmpty())
            {
                messages.Add(Validation.Profiles.Remote.HostnameNotEmpty);
            }

            if (RemotingEnabled && !RemoteUsername.NotEmpty())
            {
                messages.Add(Validation.Profiles.Remote.UsernameNotEmpty);
            }

            if (RemotingEnabled && !RemotePassword.NotEmpty())
            {
                messages.Add(Validation.Profiles.Remote.PasswordNotEmpty);
            }

            if (RemotingEnabled && !RemoteFolder.NotEmpty())
            {
                messages.Add(Validation.Profiles.Remote.FolderNotEmpty);
            }

            return ShowValidationError(messages);
        }
    }
}
