using System;
using System.Collections.Generic;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Validation;
using Sifon.Forms.Base;
using Sifon.Shared.MessageBoxes;
using Sifon.Shared.Validation;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal class BaseUserControl : AbstractUserControl, IBaseView
    {
        public event EventHandler<EventArgs> Loaded = delegate { };
        public event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;

        private readonly IFormValidation _formValidation;
        private readonly IDisplayMessage _displayMessage;

        public BaseUserControl()
        {
            _displayMessage = new DisplayMessage();
            _formValidation = new FormValidation(_displayMessage);
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (LoadedAsync != null)
            {
                await LoadedAsync(this, new EventArgs());
            }
            //Loaded(this, e);
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
            return _displayMessage.ShowYesNo(caption, message);
        }
        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            return _formValidation.ShowValidationError(errorList);
        }
        public void ShowError(string caption, string message)
        {
            _displayMessage.ShowError(caption, message);
        }
        public void ShowInfo(string caption, string message)
        {
            _displayMessage.ShowInfo(caption, message);
        }

        #endregion
    }
}
