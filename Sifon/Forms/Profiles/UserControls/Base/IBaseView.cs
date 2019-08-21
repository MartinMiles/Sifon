using System;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    public interface IBaseView
    {
        event EventHandler<EventArgs> Loaded;

        ProfilesPresenter Presenter { get; }

        void SetTooltips();
        void AddPassiveValidationHandlers();
    }
}
