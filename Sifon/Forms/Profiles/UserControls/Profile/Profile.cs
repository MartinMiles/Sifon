using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Other;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    internal partial class Profile : BaseUserControl, IProfileView, IProfileUserControl
    {
        #region Public events

        public event EventHandler<EventArgs<IProfileUserControl>> ProfileAdded = delegate { };
        public event EventHandler<EventArgs<IProfileUserControl>> ProfileRenamed = delegate { };
        public event EventHandler<EventArgs<string>> SelectedProfileChanged = delegate { };
        public event EventHandler<EventArgs> SelectedProfileDeleted = delegate { };

        #endregion

        #region Expose fields properties

        public string ProfileName
        {
            get => textProfileName.Text.Trim();
            set => textProfileName.Text = value;
        }

        public string Prefix
        {
            get => textPrefix.Text.Trim();
            set => textPrefix.Text = value;
        }

        public string AdminUsername
        {
            get => textAdminUsername.Text.Trim();
            set => textAdminUsername.Text = value;
        }

        public string AdminPassword
        {
            get => textAdminPassword.Text.Trim();
            set => textAdminPassword.Text = value;
        }

        #endregion

        public Profile()
        {
            InitializeComponent();
            new ProfilePresenter(this);
        }
        
        public void LoadProfilesDropdown(IEnumerable<string> profiles, string selectedProfileName)
        {
            comboProfiles.Items.Clear();
            comboProfiles.Items.Add(Settings.Dropdowns.AddNewProfile);

            foreach (var profile in profiles)
            {
                comboProfiles.Items.Add(profile);
            }

            if (comboProfiles.Items.Count == 1)
            {
                comboProfiles.SelectedIndex = 0;
            }
            else if (comboProfiles.Items.Contains(selectedProfileName))
            {
                comboProfiles.SelectedItem = selectedProfileName;
            }

            UpdateButtonsState();
        }   

        public void SetFields(IProfileUserControl profile)
        {
            textProfileName.Text = profile.ProfileName;
            textPrefix.Text = profile.Prefix;
            textAdminUsername.Text = profile.AdminUsername;
            textAdminPassword.Text = profile.AdminPassword;
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkDelete.Enabled = comboProfiles.SelectedIndex > 0;
            buttonRename.Text = comboProfiles.SelectedIndex > 0 ? Settings.Buttons.Change : Settings.Buttons.Add;

            if (comboProfiles.SelectedIndex > 0)
            {
                SelectedProfileChanged(this, new EventArgs<string>(comboProfiles.SelectedItem.ToString()));
            }
            else
            {
                textProfileName.Text = String.Empty;
                textPrefix.Text = String.Empty;
                textAdminUsername.Text = String.Empty;
                textAdminPassword.Text = String.Empty;
            }

            Presenter.Raise_ProfileChangedEvent(comboProfiles.SelectedIndex > 0);
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (comboProfiles.SelectedIndex > 0)
            {
                ProfileRenamed(this, new EventArgs<IProfileUserControl>(this));
            }
            else
            {
                ProfileAdded(this, new EventArgs<IProfileUserControl>(this));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowYesNo(Messages.General.YesNoCaption, Messages.Profiles.ConfirmDeletingProfile))
            {
                SelectedProfileDeleted(this, e);
            }
        }
    }
}
