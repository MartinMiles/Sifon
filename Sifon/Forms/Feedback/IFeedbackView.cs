using System;
using Sifon.Abstractions.Forms;
using Sifon.Code.Events;
using Sifon.Forms.Base;

namespace Sifon.Forms.Feedback
{
    public interface IFeedbackView : IBaseForm
    {
        event EventHandler<EventArgs<IFeedback>> SubmitClicked;

        void UpdateResult(string errorMessage);
        void ProcessError(Exception exception);
    }
}
