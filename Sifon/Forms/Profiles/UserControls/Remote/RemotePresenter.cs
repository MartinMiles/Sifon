using System;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Code.PowerShell;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    internal class RemotePresenter : BasePresenter
    {
        private readonly IRemoteView _view;
        private ScriptWrapper<string> _scriptWrapper;

        internal RemotePresenter(IRemoteView view) : base(view)
        {
            _view = view;
            _view.RemoteInitialized += RemoteInitialized;
            _view.TestRemote += async (s, e) => { await TestRemote(s, e as EventArgs<IRemoteSettings>); };
        }

        private void ToggleLastTabs(object sender, EventArgs<bool> e)
        {
            Presenter.ToggleLastTabs(e.Value);
        }

        protected override async Task Loaded(object sender, EventArgs ea)
        {
            await Task.CompletedTask;

            Presenter.ProfileChanged += async (s, e) => { await ProfileChanged(s, e as EventArgs<bool>); };
            SetValues();

            _view.ToggleLastTabs += ToggleLastTabs;
        }

        private async Task TestRemote(object sender, EventArgs<IRemoteSettings> e)
        {
            var profile = ProfilesService.CreateProfile(e.Value);
            _scriptWrapper = new ScriptWrapper<string>(profile, _view, d => d.ToString());

            await _scriptWrapper.Run("dir");

            if (_scriptWrapper.Results.Any())
            {
                _displayMessage.ShowInfo("Success", "Your connection details are valid.");
            }

            if (_scriptWrapper.Errors.Any() && _scriptWrapper.Errors.First() is RemoteTimeoutException)
            {
                _displayMessage.ShowError("Connection Error", "Falied to connect to remote machine with specified parameters");
            }

            _view.ToggleTestButton(true);
        }

        private void RemoteInitialized(object sender, EventArgs<string> e)
        {
            if (e.Value.NotEmpty())
            {
                SelectedProfile.RemoteFolder = e.Value.Trim();
                _view.SetRemoteFolder(e.Value);

                Presenter.Raise_RemoteInitializedEvent();
            }
        }

        private async Task ProfileChanged(object sender, EventArgs<bool> e)
        {
            await Task.CompletedTask;

            _view.EnableControls(e.Value);
            SetValues();
        }

        private void SetValues()
        {
            if (Presenter.SelectedProfile != null)
            {
                _view.SetHostname(Presenter.SelectedProfile.RemoteHost);
                _view.SetUsername(Presenter.SelectedProfile.RemoteUsername);
                _view.SetPassword(Presenter.SelectedProfile.RemotePassword);
                _view.SetRemoteFolder(Presenter.SelectedProfile.RemoteFolder);
                _view.SetCheckbox(Presenter.SelectedProfile.RemotingEnabled);
            }

            _view.UpdateButtons();
        }
    }
}
