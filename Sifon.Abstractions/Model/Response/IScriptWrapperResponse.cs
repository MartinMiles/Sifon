using System;
using System.Collections.Generic;

namespace Sifon.Abstractions.Model.Response
{
    public interface IScriptWrapperResponse<T>
    {
        List<T> Results { get; }
        List<Exception> Errors { get; }
    }
}