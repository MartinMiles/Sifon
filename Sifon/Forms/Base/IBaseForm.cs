using System;

namespace Sifon.Forms.Base
{
    //TODO  : Ensure other forms use it instead of excplicitly declaring event
    public interface IBaseForm
    {
        event EventHandler<EventArgs> FormLoaded;
    }
}
