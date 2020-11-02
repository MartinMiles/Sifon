using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.Extensions;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Forms.Prerequsites
{
    internal class PrerequsitesPresenter
    {
        private readonly IPrerequisitesView _view;
        private readonly ScriptWrapper<Tuple<bool, bool, bool, bool>> _scriptWrapper;
        protected readonly ProfilesProvider _profileService;


        public PrerequsitesPresenter(IPrerequisitesView view)
        {
            _view = view;
            _view.FormLoaded += FormLoaded;
            _view.InstallClicked += InstallClicked;

            _profileService = new ProfilesProvider();

            _scriptWrapper = new ScriptWrapper<Tuple<bool,bool,bool,bool>>
                (_profileService.CreateLocal(), view, d => d.Convert<Tuple<bool, bool, bool, bool>>());
            _scriptWrapper.ProgressReady += ProgressReady;
            _scriptWrapper.ErrorReady += ErrorReady;
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            var results = await _scriptWrapper.Run(Modules.Functions.CheckPrerequisites);
            _view.UpdateView(_scriptWrapper.Results.FirstOrDefault());
        }

        private async void InstallClicked(object sender, EventArgs<IPrerequisites> e)
        {
            var parameters = new Dictionary<string, dynamic>();

            parameters.Add("InstallChoco", e.Value.Chocolatey);
            parameters.Add("InstallGit", e.Value.Git);
            parameters.Add("InstallWinRM", e.Value.WinRM);
            parameters.Add("InstallSIF", e.Value.SIF);

            await _scriptWrapper.Run(Modules.Functions.InstallPrerequisites, parameters);

            if (_scriptWrapper.Errors.Any())
            {
                _view.Error(_scriptWrapper.Errors.FirstOrDefault());
            }
            else
            {
                _view.Success(_scriptWrapper.Results.FirstOrDefault());
            }
        }

        #region Script-related

        private void ProgressReady(ProgressRecord data)
        {
            _view.UpdateProgressBar(data.PercentComplete, $"{data.Activity} - {data.StatusDescription}");
        }

        private void ErrorReady(Exception exception)
        {
            if (exception is PSRemotingTransportException)
            {
                _scriptWrapper.Finish();
            }
        }

        #endregion
    }
}
