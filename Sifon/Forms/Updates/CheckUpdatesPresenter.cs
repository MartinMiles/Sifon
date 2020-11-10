using System;
using Sifon.Abstractions.Providers;
using Sifon.ApiClient.Providers;
using Sifon.Code.Factories;
using Sifon.Code.Logger;
using Sifon.Code.Model;
using Sifon.Code.Statics;

namespace Sifon.Forms.Updates
{
    internal class CheckUpdatesPresenter
    {
        private readonly ICheckUpdatesView _view;
        private readonly IApiProvider _apiProvider;
        private readonly ISettingsProvider _settingsProvider;

        internal CheckUpdatesPresenter(ICheckUpdatesView view)
        {
            _view = view;

            _view.CheckClicked += CheckClicked;
            _settingsProvider = Create.New<ISettingsProvider>();

            _apiProvider = new ApiProvider<bool> { EnableSendingExceptions = _settingsProvider.Read().SendCrashDetails };
        }

        //TODO: Consider using monads to simplify the below
        private async void CheckClicked(object sender, EventArgs e)
        {
            try
            {
                var version = await _apiProvider.FindLatestVersion<ProductVersion>();
                var thisProduct = new ProductVersion(Settings.VersionNumber);
                _view.UpdateResult(version, Settings.Api.HostBase, version <= thisProduct);
            }
            catch (Exception exception)
            {
                _view.ProcessError(exception);

                SimpleLog.Log(exception);

                var submitResult = await _apiProvider.SendException(exception);
                if (!string.IsNullOrWhiteSpace(submitResult))
                {
                    SimpleLog.Log("[WebAPI endpoint]: " + submitResult);
                }
            }
        }
    }
}