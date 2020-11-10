using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Containers
{
    internal partial class DockerProfiles : BaseForm, IDockerProfilesView, IContainerProfile
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

        public string ContainerProfileName
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

        public string SitecoreAdminPassword
        {
            get => textAdminPassword.Text;
            set => throw new NotImplementedException();
        }

        public string SaPassword
        {
            get => textSaPassword.Text;
            set => throw new NotImplementedException();
        }

        public string InitializeScript
        {
            get => textInitialize.Text;
            set => throw new NotImplementedException();
        }

        public string Notes
        {
            get => textNotes.Text;
            set => throw new NotImplementedException();
        }

        internal ProfilesPresenter Presenter => throw new NotImplementedException();

        #endregion

        internal DockerProfiles()
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
            textProfileName.Text = profile.ContainerProfileName;
            textRepositoryUrl.Text = profile.Repository;
            textRepositoryFolder.Text = profile.Folder;
            textAdminPassword.Text = profile.SitecoreAdminPassword;
            textSaPassword.Text = profile.SaPassword;
            textInitialize.Text = profile.InitializeScript;
            textNotes.Text = profile.Notes;
        }

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
            buttonAddRename.Text = comboProfiles.SelectedIndex > 0 ? Settings.Buttons.Change : Settings.Buttons.Add;

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
                textInitialize.Text = String.Empty;
                textNotes.Text = String.Empty;
            }
        }

        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowYesNo(Messages.General.YesNoCaption, Messages.Profiles.ConfirmDeletingProfile))
            {
                SelectedProfileDeleted(this, e);
            }
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

        public void ShowConfirmation()
        {
            ShowInfo("Successful", "Your changes have been saved");
        }
    }
}