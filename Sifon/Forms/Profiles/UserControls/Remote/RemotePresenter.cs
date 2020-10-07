using System;
using System.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Exceptions;
using Sifon.Code.Extensions;
using Sifon.Code.PowerShell;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    internal class RemotePresenter : BasePresenter
    {
        private readonly IRemoteView _view;
        private ScriptWrapper<string> _scriptWrapper;

        public RemotePresenter(IRemoteView view) : base(view)
        {
            _view = view;
            _view.RemoteInitialized += RemoteInitialized;
            _view.TestRemote += TestRemote;
        }

        private void ToggleLastTabs(object sender, EventArgs<bool> e)
        {
            Presenter.ToggleLastTabs(e.Value);
        }

        protected override void Loaded(object sender, EventArgs e)
        {
            Presenter.ProfileChanged += ProfileChanged;
            SetValues();

            _view.ToggleLastTabs += ToggleLastTabs;
        }

        private async void TestRemote(object sender, EventArgs<IRemoteSettings> e)
        {
            var profile = ProfilesService.CreateProfile(e.Value);
            _scriptWrapper = new ScriptWrapper<string>(profile, _view, d => d.ToString());

            await _scriptWrapper.Run("dir");

            if (_scriptWrapper.Results.Any())
            {
                _view.ShowInfo("Success", "Your connection details are valid.");
            }

            if (_scriptWrapper.Errors.Any() && _scriptWrapper.Errors.First() is RemoteTimeoutException)
            {
                _view.ShowError("Connection Error", "Falied to connect to remote machine with specified parameters");
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

        private void ProfileChanged(object sender, EventArgs<bool> e)
        {
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
