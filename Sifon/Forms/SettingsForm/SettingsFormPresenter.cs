using System;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.Providers.Profile;

namespace Sifon.Forms.SettingsForm
{
    internal class SettingsFormPresenter
    {
        private readonly ISettingsFormView _view;
        private readonly SettingsProvider _settingsProvider;

        public SettingsFormPresenter(ISettingsFormView view)
        {
            _view = view;
            _settingsProvider = new SettingsProvider();

            _view.FormLoaded += FormLoad;
            _view.ValuesChanged += ValuesChanged;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            var entity = _settingsProvider.Read();
            _view.SetView(entity);
        }

        private void ValuesChanged(object sender, EventArgs<ICrashDetails> e)
        {
            _settingsProvider.SaveCrashDetails(e.Value);
            _view.UpdateResult();
        }
    }
}
