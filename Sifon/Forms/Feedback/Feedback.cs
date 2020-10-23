using System;
using Sifon.Abstractions.Forms;
using Sifon.Code.Events;
using Sifon.Forms.Base;

namespace Sifon.Forms.Feedback
{
    internal partial class Feedback : BaseForm, IFeedbackView, IFeedback
    {
        public event EventHandler<EventArgs<IFeedback>> SubmitClicked = delegate { };

        public Feedback()
        {
            InitializeComponent();
            new FeedbackPresenter(this);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            EnableControls(false);

            SubmitClicked(this, new EventArgs<IFeedback>(this));
        }

        public void EnableControls(bool enabled)
        {
            buttonSubmit.Enabled = enabled;
            textFullname.Enabled = enabled;
            textEmail.Enabled = enabled;
            textFeedback.Enabled = enabled;
        }

        public void UpdateResult(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                ShowInfo("Successful", "Thank you for your feedback. ");

                textFullname.Text = String.Empty;
                textFeedback.Text = String.Empty;
                textEmail.Text = String.Empty;
            }
            else
            {
                ShowError("An error occured while sending the feedback", errorMessage);
            }

            EnableControls(true);
        }

        #region IFeedback

        public string Fullname
        {
            get => textFullname.Text.Trim();
            set => textFullname.Text = value;
        }

        public string Email
        {
            get => textEmail.Text.Trim();
            set => textEmail.Text = value;
        }
        public string FeedbackMessage
        {
            get => textFeedback.Text.Trim();
            set => textFeedback.Text = value;
        }

        #endregion
    }
}
