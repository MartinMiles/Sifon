using System;
using System.Threading.Tasks;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
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

            //_view.Loaded += Loaded;
            _view.LoadedAsync += async (s, e) => { await Loaded(s, e); CommonPostLoadTasks(); };
            //_view.LoadedAsync += async (s, e) => { await _view.SetTooltips(); };
            //_view.Loaded += (sender, args) => _view.SetTooltips();
            //_view.Loaded += (sender, args) => _view.AddPassiveValidationHandlers();

            _displayMessage = new DisplayMessage();
        }

        private void CommonPostLoadTasks()
        {
            _view.SetTooltips();
            _view.AddPassiveValidationHandlers();
        }

        internal ProfilesPresenter Presenter => _view.Presenter;

        protected IProfilesProvider ProfilesService => Presenter?.ProfilesProvider;
        internal IProfile SelectedProfile => ProfilesService?.SelectedProfile;

        protected abstract Task Loaded(object sender, EventArgs e);

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
