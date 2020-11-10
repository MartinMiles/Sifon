using System;
using System.Threading.Tasks;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.ScriptGenerators;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Factories;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    internal class ParametersPresenter : BasePresenter
    {
        private readonly IParametersView _view;
        private IParametersSampleScriptGenerator _parametersSampleScriptGenerator;

        internal ParametersPresenter(IParametersView view) : base(view)
        {
            _view = view;
        }

        protected override async Task Loaded(object sender, EventArgs ea)
        {
            if (Presenter.SelectedProfile == null) return;

            Presenter.ProfileChanged += async (s, e) => { await ProfileChanged(s, e as EventArgs<bool>); };
            _view.DownloadSampleScriptClicked += DownloadSampleScriptClicked;
            _view.SetValues(Presenter.SelectedProfile.Parameters);
        }

        private void DownloadSampleScriptClicked(object sender, EventArgs e)
        {
            _parametersSampleScriptGenerator = Create.WithCurrentProfile<IParametersSampleScriptGenerator>();

            string script = _parametersSampleScriptGenerator.Generate();
            _view.SaveSampleScript(script);
        }

        private async Task ProfileChanged(object sender, EventArgs<bool> e)
        {
            await Task.CompletedTask;

            if (Presenter.SelectedProfile != null)
            {
                _view.SetValues(Presenter.SelectedProfile.Parameters);
            }
        }
    }
}
