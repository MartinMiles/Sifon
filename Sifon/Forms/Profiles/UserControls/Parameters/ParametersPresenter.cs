using System;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.ScriptGenerators;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    public class ParametersPresenter : BasePresenter
    {
        private readonly IParametersView _view;
        private ParametersSampleScriptGenerator _parametersSampleScriptGenerator;

        public ParametersPresenter(IParametersView view) : base(view)
        {
            _view = view;
        }

        protected override void Loaded(object sender, EventArgs e)
        {
            Presenter.ProfileChanged += ProfileChanged;
            _view.DownloadSampleScriptClicked += DownloadSampleScriptClicked;
            _view.SetValues(Presenter.SelectedProfile.Parameters);
        }

        private void DownloadSampleScriptClicked(object sender, EventArgs e)
        {
            _parametersSampleScriptGenerator = new ParametersSampleScriptGenerator(ProfilesService.SelectedProfile);

            string script = _parametersSampleScriptGenerator.Generate();
            _view.SaveSampleScript(script);
        }

        private void ProfileChanged(object sender, EventArgs<bool> e)
        {
            _view.SetValues(Presenter.SelectedProfile.Parameters);
        }

        // button status - 
    }
}
