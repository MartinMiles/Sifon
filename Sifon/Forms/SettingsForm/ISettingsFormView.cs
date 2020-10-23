using System;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Forms.Base;

namespace Sifon.Forms.SettingsForm
{
    public interface ISettingsFormView : IBaseForm
    {
        event EventHandler<EventArgs<ICrashDetails>> ValuesChanged;

        void SetView(ICrashDetails entity);
        void UpdateResult();
    }
}
