using System;
using Sifon.Abstractions.Providers;
using Sifon.Code.Model;
using Sifon.Code.Providers;
using Sifon.Code.Statics;

namespace Sifon.Forms.Updates
{
    public class CheckUpdatesPresenter
    {
        private readonly ICheckUpdatesView _view;
        private readonly IApiProvider _apiProvider;
        
        public CheckUpdatesPresenter(ICheckUpdatesView view)
        {
            _view = view;

            _view.CheckClicked += CheckClicked;
            _apiProvider = new ApiProvider<bool>();
        }

        private async void CheckClicked(object sender, EventArgs e)
        {
            var version = await _apiProvider.FindLatestVersion<ProductVersion>();
            var thisProduct = new ProductVersion(Settings.VersionNumber);
            _view.UpdateResult(version, Settings.Api.HostBase, version <= thisProduct);
        }
    }
}
