using System;
using Sifon.Abstractions.Providers;
using Sifon.ApiClient.Providers;
using Sifon.Code.Logger;
using Sifon.Code.Model;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Forms.Updates
{
    public class CheckUpdatesPresenter
    {
        private readonly ICheckUpdatesView _view;
        private readonly IApiProvider _apiProvider;
        private readonly SettingsProvider _settingsProvider;
        
        public CheckUpdatesPresenter(ICheckUpdatesView view)
        {
            _view = view;

            _view.CheckClicked += CheckClicked;
            _settingsProvider = new SettingsProvider();

            _apiProvider = new ApiProvider<bool> { EnableSendingExceptions = _settingsProvider.Read().SendCrashDetails };
        }

        //TODO: Consider using monad to simplify the below
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