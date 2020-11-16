using System;

namespace Sifon.Code.Formatters.Text
{
    // TODO: Turn this class into IFormatter<string> and split mute logic out of it
    public class GenericTextFormatter
    {
        private bool muteOutputFlag;
        const string muteContent = "Sifon-MuteOutput";
        const string unmuteContent = "Sifon-UnmuteOutput";

        private bool muteProgressFlag;
        const string muteProgressContent = "Sifon-MuteProgress";
        const string unmuteProgressContent = "Sifon-UnmuteProgress";

        private bool muteWarningFlag;
        const string muteWarningContent = "Sifon-MuteWarnings";
        const string unmuteWarningContent = "Sifon-UnmuteWarnings";

        private bool muteErrorFlag;
        const string muteErrorContent = "Sifon-MuteErrors";
        const string unmuteErrorContent = "Sifon-UnmuteErrors";


        public bool ProgressMuted => muteProgressFlag;

        public string FormatOutput(string line)
        {
            UpdateMuteStatus(line);

            line = muteOutputFlag ? String.Empty : line;

            line = IngnoreMuteCommandFromOutput(line);

            return ReplaceDotWithNewLine(line);
        }

        private string ReplaceDotWithNewLine(string line)
        {
            return line.Length == 1 && line == "." ? Environment.NewLine : line;
        }

        public string FormatWarning(string line)
        {
            UpdateMuteStatus(line);

            line = muteWarningFlag ? String.Empty : line;

            return IngnoreMuteCommandFromOutput(line);
        }

        public string FormatError(string line)
        {
            UpdateMuteStatus(line);

            line = muteErrorFlag ? String.Empty : line;

            return IngnoreMuteCommandFromOutput(line);
        }

        private string IngnoreMuteCommandFromOutput(string line)
        {
            if (line.IndexOf(muteWarningContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(unmuteWarningContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(muteErrorContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(unmuteErrorContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(muteProgressContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(unmuteProgressContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(muteContent, StringComparison.CurrentCultureIgnoreCase) >= 0
                || line.IndexOf(unmuteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                line = String.Empty;
            }

            return line;
        }

        private void UpdateMuteStatus(string value)
        {
            if (value.IndexOf(muteWarningContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteWarningFlag = true;
            }

            if (value.IndexOf(unmuteWarningContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteWarningFlag = false;
            }

            if (value.IndexOf(muteErrorContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteErrorFlag = true;
            }

            if (value.IndexOf(unmuteErrorContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteErrorFlag = false;
            }

            if (value.IndexOf(muteProgressContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteProgressFlag = true;
            }

            if (value.IndexOf(unmuteProgressContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteProgressFlag = false;
            }

            if (value.IndexOf(muteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteOutputFlag = true;
            }

            if (value.IndexOf(unmuteContent, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                muteOutputFlag = false;
            }
        }
    }
}