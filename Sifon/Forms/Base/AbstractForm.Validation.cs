using System.Collections.Generic;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Validation;

namespace Sifon.Forms.Base
{
    abstract partial class AbstractForm
    {
        private readonly IFormValidation _formValidation;
        private readonly IDisplayMessage _displayMessage;

        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            return _formValidation.ShowValidationError(errorList);
        }

        public bool ShowYesNo(string caption, string message)
        {
            return _displayMessage.ShowYesNo(caption, message);
        }

        public void ShowInfo(string caption, string message)
        {
            _displayMessage.ShowInfo(caption, message);
        }

        public void ShowError(string caption, string message)
        {
            _displayMessage.ShowError(caption, message);
        }

        protected virtual void AddPassiveValidationHandlers()
        {
        }
    }
}
