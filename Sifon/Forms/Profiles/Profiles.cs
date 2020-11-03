using System;
using System.Windows.Forms;
using Sifon.Forms.Base;
using Sifon.Forms.Profiles.UserControls.Connectivity;
using Sifon.Forms.Profiles.UserControls.Parameters;
using Sifon.Forms.Profiles.UserControls.Remote;
using Sifon.Forms.Profiles.UserControls.Website;

namespace Sifon.Forms.Profiles
{
    internal partial class Profiles : BaseForm, IProfilesView
    {
        private bool modifiedFlag = false;
        private bool isFirstRunFlag;

        public event EventHandler<EventArgs> FormSaved = delegate { };
        public event EventHandler<EventArgs> ContinueWithoutCreatingProfile = delegate { };

        
        internal ProfilesPresenter Presenter { get; private set; }

        #region Constructors

        public Profiles(bool firstRun)
        {
            isFirstRunFlag = firstRun;
            ctor();

            buttonNoProfile.Visible = true;
        }

        public Profiles()
        {
            ctor();
        }

        private void ctor()
        {
            InitializeComponent();
            Presenter = new ProfilesPresenter(this);

            PopulateTabsWithUsercontrols();
        }

        #endregion

        #region Access properties

        public UserControls.Profile.Profile Profile { get; private set; }
        public Remote Remote { get; private set; }
        public Website Website { get; private set; }
        public Connectivity Connectivity { get; private set; }
        public Parameters Parameters { get; private set; }

        #endregion

        private void FormLoad(object sender, EventArgs e)
        {
            Raise_FormLoaded();
            PreloadTabs();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Profile.ValidateValues() && (Parameters == null || Parameters.ValidateValues()) && (Remote == null || Remote.ValidateValues()))
            {
                FormSaved(this, new EventArgs());
            }
        }

        public void FocusOnSaveButton()
        {
            buttonSave.Focus();
        }

        public void ToggleLastTabs(bool enabled)
        {
            // this disables last 3 tabs once we switch between local and remote profiles to enforce save
            for (int i = 2; i <= 4; i++)
            {
                tabControl1.TabPages[i].Enabled = enabled;
            }
        }

        private void PopulateTabsWithUsercontrols()
        {
            tabProfile.Controls.Add(Profile = new UserControls.Profile.Profile());
            tabRemote.Controls.Add(Remote = new Remote());

            if (!isFirstRunFlag)
            {
                tabWebsite.Controls.Add(Website = new Website());
                tabConnectivity.Controls.Add(Connectivity = new Connectivity());
                tabParameters.Controls.Add(Parameters = new Parameters());
            }
            else
            {
                tabControl1.Controls.Remove(tabWebsite);
                tabControl1.Controls.Remove(tabConnectivity);
                tabControl1.Controls.Remove(tabParameters);
            }
        }

        private void PreloadTabs()
        {
            tabProfile.Show();
            tabRemote.Show();
            
            if (!isFirstRunFlag)
            {
                tabWebsite.Show();
                tabConnectivity.Show();
                tabParameters.Show();
            }
        }

        public void EnableSaveButton(bool value)
        {
            buttonSave.Enabled = value;
            modifiedFlag = true;
        }

        private void Profiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            Raise_FormClosing();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && modifiedFlag && ShowYesNo("Changes not saved", "Are you sure you would like to leave without saving the changes?"))
            {
                CloseDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonNoProfile_Click(object sender, EventArgs e)
        {
            if (ShowYesNo("Continue without creating local or remote profile? (not recommended)", "Most of the menu items and plugins will be unavailable to you without having at least one active profile\nThe only function remains active is running Sitecore in containers."))
            {
                ContinueWithoutCreatingProfile(this, new EventArgs());
                Close();
            }
        }
    }
}
