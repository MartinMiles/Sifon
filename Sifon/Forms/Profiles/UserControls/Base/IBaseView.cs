using System;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal interface IBaseView
    {
        event EventHandler<EventArgs> Loaded;

        ProfilesPresenter Presenter { get; }

        void SetTooltips();
        void AddPassiveValidationHandlers();
    }
}
