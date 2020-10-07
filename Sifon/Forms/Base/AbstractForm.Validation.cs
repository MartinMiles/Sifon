using System.Collections.Generic;
using Sifon.Abstractions.Validation;
using Sifon.Code.Validation;

namespace Sifon.Forms.Base
{
    abstract partial class AbstractForm
    {
        private readonly IFormValidation _formValidation;

        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            return _formValidation.ShowValidationError(errorList);
        }

        public bool ShowYesNo(string caption, string message)
        {
            return _formValidation.ShowYesNo(caption, message);
        }

        public void ShowInfo(string caption, string message)
        {
            _formValidation.ShowInfo(caption, message);
        }

        public void ShowError(string caption, string message)
        {
            _formValidation.ShowError(caption, message);
        }

        protected virtual void AddPassiveValidationHandlers()
        {
        }
    }
}
