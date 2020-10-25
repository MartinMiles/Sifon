using System;
using Sifon.Code.Model;

namespace Sifon.Forms.Updates
{
    public interface ICheckUpdatesView
    {
        event EventHandler<EventArgs> CheckClicked;
        void UpdateResult(ProductVersion version, string hostBase, bool newerAvailable);
        void ProcessError(Exception exception);
    }
}
