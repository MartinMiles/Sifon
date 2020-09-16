using System;

namespace Sifon.Shared.Formatters.Text
{
    public class GenericTextFormatter
    {
        private bool mute;
        const string muteContent = "Sifon-MuteOutput";
        const string unmuteContent = "Sifon-UnmuteOutput";

        public string Format(string line)
        {
            VerifyMuteStatus(line);

            if (mute || line.IndexOf(muteContent, StringComparison.CurrentCultureIgnoreCase) >= 0 || line.IndexOf(unmuteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                line = String.Empty;
            }

            return line;
        }

        private void VerifyMuteStatus(string value)
        {

            if (value.IndexOf(muteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                mute = true;
            }
            if (value.IndexOf(unmuteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                mute = false;
            }
        }
    }
}
