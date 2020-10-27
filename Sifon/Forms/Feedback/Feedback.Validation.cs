using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sifon.Code.Statics;
using Sifon.Extensions;
using Sifon.Statics;

namespace Sifon.Forms.Feedback
{
    partial class Feedback
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textFullname.KeyPress += NameAndPrefixKeyPress;
            textEmail.KeyPress += NameAndPrefixKeyPress;
            textFeedback.KeyPress += NameAndPrefixKeyPress;

            textFullname.TextChanged += TextHasChanged;
            textEmail.TextChanged += TextHasChanged;
            textFeedback.TextChanged += TextHasChanged;
        }

        private void NameAndPrefixKeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!char.IsControl(character) && Regex.IsMatch(character.ToString(), GetFilterPattern(((TextBox)sender).Name)))
            {
                e.Handled = true;   // Stop the character from being entered into the control since it is illegal.
            }
        }

        private string GetFilterPattern(string name)
        {
            if (name == textFullname.Name)
            {
                return Pattern.Filter.SpecialCharacters.Except.DotsDashesApostrophes;
            }

            if (name == textEmail.Name)
            {
                return Pattern.Filter.SpecialCharacters.Except.DotsDashesAt;
            }

            if (name == textFeedback.Name)
            {
                return Pattern.DoNotFilter;
            }

            throw new ArgumentOutOfRangeException($"Control is not supporthe for passive validation: {name}");
        }

        private void UpdateButtonsState()
        {
            buttonSubmit.Enabled = textFullname.Text.Length > 0 && textEmail.Text.Length > 0 && textFeedback.Text.Length > 0;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        #endregion

        #region Validates on form submission (last resort when copypasting)

        private List<string> _validationMessages;

        private bool ValidateForm()
        {
            _validationMessages = new List<string>();

            if (!textFullname.ValidateRegex(Pattern.Feedback.Fullname))
            {
                _validationMessages.Add(Validation.Feedback.Fullname);
            }

            if (!ValidateEmail(textEmail.Text))
            {
                _validationMessages.Add(Validation.Feedback.Email);
            }

            if (!textFeedback.ValidateRegex(Pattern.Feedback.FeedbackMessage))
            {
                _validationMessages.Add(Validation.Feedback.FeedbackMessage);
            }

            return ShowValidationError(_validationMessages);
        }

        #endregion

        private bool ValidateEmail(string email)
        {
            try
            {
                var address = new MailAddress(email).Address;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
