using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.Providers;
using Sifon.Code.Events;
using Sifon.Code.Providers;
using Sifon.Code.Providers.Profile;

namespace Sifon.Forms.Feedback
{
    public class FeedbackPresenter
    {
        private readonly IFeedbackView _view;
        private readonly IApiProvider _apiProvider;

        public FeedbackPresenter(IFeedbackView view)
        {
            _view = view;
            _apiProvider = new ApiProvider<IFeedback>();

            _view.FormLoaded += FormLoad;
            _view.SubmitClicked += SubmitClicked;
        }

        private void FormLoad(object sender, EventArgs e)
        {
        }

        private async void SubmitClicked(object sender, EventArgs<IFeedback> e)
        {
            var result = await _apiProvider.SendFeedback<IFeedback, string>(e.Value);

            _view.UpdateResult(result);
        }
    }
}
