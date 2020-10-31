using System;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Providers.Profile;
using Sifon.Shared.MessageBoxes;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal abstract class BasePresenter
    {
        private readonly IBaseView _view;
        protected readonly IDisplayMessage _displayMessage;

        protected BasePresenter(IBaseView view)
        {
            _view = view;

            _view.Loaded += Loaded;
            _view.Loaded += (sender, args) => _view.SetTooltips();
            _view.Loaded += (sender, args) => _view.AddPassiveValidationHandlers();

            _displayMessage = new DisplayMessage();
        }

        internal ProfilesPresenter Presenter => _view.Presenter;

        protected ProfilesProvider ProfilesService => Presenter?.ProfilesService;
        internal IProfile SelectedProfile => ProfilesService?.SelectedProfile;

        protected abstract void Loaded(object sender, EventArgs e);

        protected void ShowConnectivityError()
        {
            if (!Presenter.RemoteNotInitializedExceptionAlredyFired)
            {
                Presenter.RemoteNotInitializedExceptionAlredyFired = true;
                _displayMessage.ShowError(Messages.Profiles.Connectivity.Errors.ProfileDamaged, Messages.Profiles.Connectivity.Errors.RemoteFoldermissing);
            }
        }
    }
}
