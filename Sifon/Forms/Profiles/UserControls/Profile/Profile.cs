using System;
using System.Collections.Generic;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    public partial class Profile : BaseUserControl, IProfileView
    {
        #region Public events

        public event EventHandler<EventArgs<Tuple<string, string>>> ProfileAdded = delegate { };
        public event EventHandler<EventArgs<Tuple<string, string>>> ProfileRenamed = delegate { };
        public event EventHandler<EventArgs<string>> SelectedProfileChanged = delegate { };
        public event EventHandler<EventArgs> SelectedProfileDeleted = delegate { };

        #endregion

        #region Expose fields properties

        internal string ProfileName => textProfileName.Text.Trim();

        internal string ProfilePrefix => textPrefix.Text.Trim();

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

        public void SetProfileTextbox(string name)
        {
            textProfileName.Text = name;
        }

        public void SetPrefixTextbox(string name)
        {
            textPrefix.Text = name;
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = comboProfiles.SelectedIndex > 0;
            buttonRename.Text = comboProfiles.SelectedIndex > 0 ? Settings.Buttons.Rename : Settings.Buttons.Add;

            if (comboProfiles.SelectedIndex > 0)
            {
                SelectedProfileChanged(this, new EventArgs<string>(comboProfiles.SelectedItem.ToString()));
            }
            else
            {
                textProfileName.Text = String.Empty;
                textPrefix.Text = String.Empty;
            }

            Presenter.Raise_ProfileChangedEvent(comboProfiles.SelectedIndex > 0);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ShowYesNo(Messages.General.YesNoCaption, Messages.Profiles.ConfirmDeletingProfile))
            {
                SelectedProfileDeleted(this, e);
            }
        }

        private Tuple<string, string> ProfilePrefixTuple => new Tuple<string, string>(textProfileName.Text.Trim(), textPrefix.Text.Trim());

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (comboProfiles.SelectedIndex > 0)
            {
                ProfileRenamed(this, new EventArgs<Tuple<string, string>>(ProfilePrefixTuple));
            }
            else
            {
                ProfileAdded(this, new EventArgs<Tuple<string, string>>(ProfilePrefixTuple));
            }
        }
    }
   
}
