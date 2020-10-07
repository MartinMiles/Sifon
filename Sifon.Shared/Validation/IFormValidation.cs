using System.Collections.Generic;

namespace Sifon.Code.Validation
{
    public interface IFormValidation
    {
        bool ShowValidationError(IEnumerable<string> errorList);
        bool ShowYesNo(string caption, string message);
        void ShowInfo(string caption, string message);
        void ShowError(string caption, string message);
    }
}
