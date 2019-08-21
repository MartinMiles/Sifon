using System.Collections.Generic;

namespace Sifon.Abstractions.Plugins
{
    public class PluginProgress
    {
        public string Activity { get; set; }
        public int PercentDone { get; set; }
        public IEnumerable<string> Messages { get; set; }

        #region Constructors

        public PluginProgress(string activity, int percent)
        {
            Activity = activity;
            PercentDone = percent;
            Messages = new List<string>();
        }
        public PluginProgress(string activity, int percent, string message)
        {
            Activity = activity;
            PercentDone = percent;
            Messages = new[] {message};

        }
        public PluginProgress(string activity, int percent, IEnumerable<string> messages)
        {
            Activity = activity;
            PercentDone = percent;
            Messages = messages;
        }

        #endregion
    }
}
