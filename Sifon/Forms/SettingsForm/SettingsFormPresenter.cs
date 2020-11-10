using System;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;

namespace Sifon.Forms.SettingsForm
{
    internal class SettingsFormPresenter
    {
        private readonly ISettingsFormView _view;
        private readonly ISettingsProvider _settingsProvider;

        internal SettingsFormPresenter(ISettingsFormView view)
        {
            _view = view;
            _settingsProvider = Create.New<ISettingsProvider>();

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
