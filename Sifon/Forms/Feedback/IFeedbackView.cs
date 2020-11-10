using System;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.Feedback
{
    internal interface IFeedbackView : IBaseForm
    {
        event EventHandler<EventArgs<IFeedback>> SubmitClicked;

        void UpdateResult(string errorMessage);
        void ProcessError(Exception exception);
    }
}
