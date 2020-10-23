using Sifon.Abstractions.Forms;

namespace Sifon.UK.Website.Model
{
    public class Feedback : IFeedback
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string FeedbackMessage { get; set; }
    }
}