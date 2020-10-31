using System.Collections.Generic;

namespace Sifon.Abstractions.Validation
{
    public interface IFormValidation
    {
        bool ShowValidationError(IEnumerable<string> errorList);
    }
}
