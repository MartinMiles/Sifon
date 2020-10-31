namespace Sifon.Abstractions.Messages
{
    public interface IDisplayMessage
    {
        bool ShowYesNo(string caption, string message);
        void ShowInfo(string caption, string message);
        void ShowError(string caption, string message);
    }
}
