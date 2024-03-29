﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Providers;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.Statics;

namespace Sifon.Forms.Prerequsites
{
    internal class PrerequsitesPresenter
    {
        private readonly IPrerequisitesView _view;
        private readonly IScriptWrapper<bool> _scriptWrapper;

        internal PrerequsitesPresenter(IPrerequisitesView view)
        {
            _view = view;
            _view.FormLoaded += FormLoaded;
            _view.InstallClicked += InstallClicked;

            var localProfile = Create.New<IProfilesProvider>().CreateLocal();

            _scriptWrapper = Create.WithParam(_view, d => bool.Parse(d.ToString()), localProfile);
            _scriptWrapper.ProgressReady += ProgressReady;
            _scriptWrapper.ErrorReady += ErrorReady;
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            await _scriptWrapper.Run(Modules.Functions.CheckPrerequisites);
            _view.UpdateView(_scriptWrapper.Results.ToArray());
        }

        private async void InstallClicked(object sender, EventArgs<IPrerequisites> e)
        {
            var parameters = new Dictionary<string, dynamic>();

            var InstallValues = new [] 
                { e.Value.Chocolatey,
                    e.Value.Git,
                    e.Value.WinRM,
                    e.Value.SIF,
                    e.Value.NetCore,
                    e.Value.SqlServer
                };
            parameters.Add("InstallValues", InstallValues);

            await _scriptWrapper.Run(Modules.Functions.InstallPrerequisites, parameters);

            if (_scriptWrapper.Errors.Any())
            {
                _view.Error(_scriptWrapper.Errors.FirstOrDefault());
            }
            else
            {
                await _scriptWrapper.Run(Modules.Functions.CheckPrerequisites);
                _view.UpdateView(_scriptWrapper.Results.ToArray());
                _view.Success(_scriptWrapper.Results.ToArray());
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
