using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Validation;

namespace Sifon.Shared.Validation
{
    public class FormValidation : IFormValidation
    {
        private readonly IDisplayMessage _displayMessage;

        public FormValidation(IDisplayMessage displayMessage)
        {
            _displayMessage = displayMessage;
        }

        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            var errorBuilder = new StringBuilder(Sifon.Code.Statics.Validation.General.ErrorsList);

            foreach (var error in errorList)
            {
                errorBuilder.AppendLine(error);
            }

            if (errorList.Any())
            {
                _displayMessage.ShowError(Sifon.Code.Statics.Validation.General.MessageBoxCapture, errorBuilder.ToString());
            }

            return !errorList.Any();
        }
    }
}