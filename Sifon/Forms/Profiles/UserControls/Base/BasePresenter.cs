using System;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Validation;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Validation;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Base
{
    internal abstract class BasePresenter
    {
        private readonly IBaseView _view;
        protected readonly IFormValidation _formValidation;

        protected BasePresenter(IBaseView view)
        {
            _view = view;

            _view.Loaded += Loaded;
            _view.Loaded += (sender, args) => _view.SetTooltips();
            _view.Loaded += (sender, args) => _view.AddPassiveValidationHandlers();

            _formValidation = new FormValidation();
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
                 _formValidation.ShowError(Messages.Profiles.Connectivity.Errors.ProfileDamaged, Messages.Profiles.Connectivity.Errors.RemoteFoldermissing);
            }
        }
    }
}
