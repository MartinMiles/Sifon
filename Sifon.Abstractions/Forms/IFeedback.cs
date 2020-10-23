namespace Sifon.Abstractions.Forms
{
    public interface IFeedback
    {
        string Fullname { get; set; }
        string Email { get; set; }
        string FeedbackMessage { get; set; }
    }
}
