using System;

namespace Sifon.Forms.Base
{
    internal interface IBaseForm
    {
        event EventHandler<EventArgs> FormLoaded;
    }
}
