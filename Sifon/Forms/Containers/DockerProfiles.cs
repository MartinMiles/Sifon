using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles;
using Sifon.Shared.Events;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Containers
{
    public partial class DockerProfiles : BaseForm, IDockerProfilesView, IContainerProfile
    {
        #region Public events

        public event EventHandler<EventArgs> Loaded = delegate { };
        public event EventHandler<EventArgs<IContainerProfile>> ProfileAdded = delegate { };
        public event EventHandler<EventArgs<IContainerProfile>> ProfileRenamed = delegate { };
        public event EventHandler<EventArgs<string>> SelectedProfileChanged = delegate { };
        public event EventHandler<EventArgs> SelectedProfileDeleted = delegate { };

        #endregion

        #region IContainerProfile implementation

        public bool Selected
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string ProfileName
        {
            get => textProfileName.Text;
            set => throw new NotImplementedException();
        }

        public string Repository
        {
            get => textRepositoryUrl.Text;
            set => throw new NotImplementedException();
        }

        public string Folder
        {
            get => textRepositoryFolder.Text;
            set => throw new NotImplementedException();
        }

        public string AdminPassword
        {
            get => textAdminPassword.Text;
            set => throw new NotImplementedException();
        }

        public string SaPassword
        {
            get => textSaPassword.Text;
            set => throw new NotImplementedException();
        }

        public ProfilesPresenter Presenter => throw new NotImplementedException();

        #endregion

        public DockerProfiles()
        {
            InitializeComponent();
            new DockerProfilesPresenter(this);
        }

        private void DockerProfiles_Load(object sender, EventArgs e)
        {
            Loaded(this, new EventArgs());
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

        public void SetFields(IContainerProfile profile)
        {
            textProfileName.Text = profile.ProfileName;
            textRepositoryUrl.Text = profile.Repository;
            textRepositoryFolder.Text = profile.Folder;
            textAdminPassword.Text = profile.AdminPassword;
            textSaPassword.Text = profile.SaPassword;
        }

        //private void UpdateButtonsState()
        //{
        //    bool buttonsEnabled = textProfileName.Text.Length > 0
        //                          && textRepositoryUrl.Text.Length > 0
        //                          //&& textRepositoryFolder.Text.Length > 0 - can be blank
        //                          && textAdminPassword.Text.Length > 0
        //                          && textSaPassword.Text.Length > 0;

        //    buttonRename.Enabled = buttonsEnabled;
        //}

        #region Event handlers

        private void buttonAddRename_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (comboProfiles.SelectedIndex > 0)
            {
                ProfileRenamed(this, new EventArgs<IContainerProfile>(this));
            }
            else
            {
                ProfileAdded(this, new EventArgs<IContainerProfile>(this));
            }
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkDelete.Enabled = comboProfiles.SelectedIndex > 0;
            buttonAddRename.Text = comboProfiles.SelectedIndex > 0 ? Settings.Buttons.Rename : Settings.Buttons.Add;

            if (comboProfiles.SelectedIndex > 0)
            {
                SelectedProfileChanged(this, new EventArgs<string>(comboProfiles.SelectedItem.ToString()));
            }
            else
            {
                textProfileName.Text = String.Empty;
                textRepositoryUrl.Text = String.Empty;
                textRepositoryFolder.Text = String.Empty;
                textAdminPassword.Text = String.Empty;
                textSaPassword.Text = String.Empty;
            }
        }

        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowYesNo(Messages.General.YesNoCaption, Messages.Profiles.ConfirmDeletingProfile))
            {
                SelectedProfileDeleted(this, e);
            }
        }

        private void buttonDefaults_Click(object sender, EventArgs e)
        {
            textProfileName.Text = "Sitecore 10 XP0 - Getting Started";
            textRepositoryUrl.Text = "https://github.com/Sitecore/docker-examples";
            textRepositoryFolder.Text = "getting-started";
            textAdminPassword.Text = "Password12345";
            textSaPassword.Text = "Password12345";
        }

        #endregion

        private void linkRevealAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPasswordWithinTextbox(textAdminPassword, (LinkLabel)sender);
        }

        private void linkRevealSa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPasswordWithinTextbox(textSaPassword, (LinkLabel)sender);
        }
    }
}