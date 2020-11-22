using System;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;

namespace Sifon.Forms.SettingsForm
{
    internal partial class SettingsForm : BaseForm, ISettingsFormView, ICrashDetails
    {
        const string MASTER =  "Use master branch of a repository";
        const string VERSION = "Align to a version matching branch";

        public event EventHandler<EventArgs<ICrashDetails>> ValuesChanged = delegate { };

        internal SettingsForm()
        {
            InitializeComponent();
            new SettingsFormPresenter(this);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PopulateVersionsCombo();
            Raise_FormLoaded();
            buttonSave.Focus();
        }

        private void PopulateVersionsCombo()
        {
            comboBranching.Items.Clear();
            comboBranching.Items.Add(MASTER);
            comboBranching.Items.Add(VERSION);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // No need to do validation yet as single checkbox is always valid
            // Later use this clause: if(!ValidateForm()) return;
            if (ValidateValues())
            {
                ValuesChanged(this, new EventArgs<ICrashDetails>(this));
            }
        }

        #region Interface implementation

        public bool SendCrashDetails
        {
            get => checkBoxCrashLog.Checked;
            set => checkBoxCrashLog.Checked = value;
        }

        public string PluginsRepository
        {
            get => textRepository.Text;
            set => textRepository.Text = value;
        }

        public bool AlignVersions
        {
            get => comboBranching.SelectedItem == VERSION;
            set => comboBranching.SelectedItem = value ? VERSION : MASTER;
        }

        #endregion

        public void SetView(ICrashDetails entity)
        { 
            SendCrashDetails = entity.SendCrashDetails;
            PluginsRepository = entity.PluginsRepository;
            AlignVersions = entity.AlignVersions;
        }

        public void UpdateResult()
        {
            DialogResult = DialogResult.OK;
        }
    }
}
