using System;
using System.Collections.Generic;

namespace Sifon.Abstractions.Model.Response
{
    // TODO: Verify if this interface is of any use at all
    public interface IScriptWrapperResponse<T>
    {
        List<T> Results { get; }
        List<Exception> Errors { get; }
    }
}