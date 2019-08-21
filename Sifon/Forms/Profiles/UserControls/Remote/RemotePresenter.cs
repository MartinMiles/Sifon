using System;
using System.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Exceptions;
using Sifon.Shared.Extensions;
using Sifon.Shared.PowerShell;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    public class RemotePresenter : BasePresenter
    {
        private readonly IRemoteView _view;
        private ScriptWrapper<string> _scriptWrapper;

        public RemotePresenter(IRemoteView view) : base(view)
        {
            _view = view;
            _view.RemoteInitialized += RemoteInitialized;
            _view.TestRemote += TestRemote;
        }

        protected override void Loaded(object sender, EventArgs e)
        {
            Presenter.ProfileChanged += ProfileChanged;
            SetValues();
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
            _view.SetCheckbox(Presenter.SelectedProfile.RemotingEnabled);
            _view.SetHostname(Presenter.SelectedProfile.RemoteExecutionHost);
            _view.SetUsername(Presenter.SelectedProfile.RemoteUsername);
            _view.SetPassword(Presenter.SelectedProfile.RemotePassword);
            _view.SetRemoteFolder(Presenter.SelectedProfile.RemoteFolder);

            _view.UpdateButtons();
        }
    }
}
