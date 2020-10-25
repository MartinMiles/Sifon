using System;

namespace Sifon.Forms.Base
{
    public interface IBaseForm
    {
        event EventHandler<EventArgs> FormLoaded;
    }
}
