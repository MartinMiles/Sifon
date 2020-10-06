using System;
using System.Collections.Generic;
using Sifon.Shared.Validation;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal class BaseUserControl : AbstractUserControl, IBaseView, IFormValidation
    {
        public event EventHandler<EventArgs> Loaded = delegate { };
        private readonly IFormValidation _formValidation;

        public BaseUserControl()
        {
            _formValidation = new FormValidation();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Loaded(this, e);
        }

        public override void SetTooltips()
        {
        }

        public override void AddPassiveValidationHandlers()
        {
        }

        #region Wrappers around shared code

        public bool ShowYesNo(string caption, string message)
        {
            return _formValidation.ShowYesNo(caption, message);
        }
        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            return _formValidation.ShowValidationError(errorList);
        }
        public void ShowError(string caption, string message)
        {
            _formValidation.ShowError(caption, message);
        }
        public void ShowInfo(string caption, string message)
        {
            _formValidation.ShowInfo(caption, message);
        }

        #endregion
    }
}
