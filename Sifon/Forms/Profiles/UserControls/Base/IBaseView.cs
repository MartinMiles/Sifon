using System;
using Sifon.Forms.Base;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal interface IBaseView
    {
        event EventHandler<EventArgs> Loaded;
        event BaseForm.AsyncEventHandler<EventArgs> LoadedAsync;

        ProfilesPresenter Presenter { get; }

        void SetTooltips();
        void AddPassiveValidationHandlers();
    }
}
