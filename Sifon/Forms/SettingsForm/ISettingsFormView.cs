using System;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;

namespace Sifon.Forms.SettingsForm
{
    internal interface ISettingsFormView : IBaseForm
    {
        event EventHandler<EventArgs<ICrashDetails>> ValuesChanged;

        void SetView(ICrashDetails entity);
        void UpdateResult();
    }
}
