using System;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Abstractions.Providers;
using Sifon.ApiClient.Providers;

namespace Sifon.Forms.Feedback
{
    internal class FeedbackPresenter
    {
        private readonly IFeedbackView _view;
        private readonly IApiProvider _apiProvider;

        internal FeedbackPresenter(IFeedbackView view)
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
            try
            {
                var errors = await _apiProvider.SendFeedback<IFeedback, string>(e.Value);
                _view.UpdateResult(errors);
            }
            catch (Exception exception)
            {
                _view.ProcessError(exception);
            }
        }
    }
}
