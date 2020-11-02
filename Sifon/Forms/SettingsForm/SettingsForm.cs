using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Forms.Base;

namespace Sifon.Forms.SettingsForm
{
    internal partial class SettingsForm : BaseForm, ISettingsFormView, ICrashDetails
    {
        public event EventHandler<EventArgs<ICrashDetails>> ValuesChanged = delegate { };

        public SettingsForm()
        {
            InitializeComponent();
            new SettingsFormPresenter(this);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Raise_FormLoaded();
            buttonSave.Focus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // No need to do validation yet as single checkbox is always valid
            // Later use this clause: if(!ValidateForm()) return;

            ValuesChanged(this, new EventArgs<ICrashDetails>(this));
        }

        public bool SendCrashDetails
        {
            get => checkBoxCrashLog.Checked;
            set => checkBoxCrashLog.Checked = value;
        }

        public void SetView(ICrashDetails entity)
        {
            SendCrashDetails = entity.SendCrashDetails;
        }

        public void UpdateResult()
        {
            DialogResult = DialogResult.OK;
        }
    }
}
