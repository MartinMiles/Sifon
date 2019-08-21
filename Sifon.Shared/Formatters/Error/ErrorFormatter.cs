using System;

namespace Sifon.Shared.Formatters.Error
{
    public class ErrorFormatter
    {
        public string Format(string exceptionMessage)
        {
            return exceptionMessage.Replace("System.Data.SqlClient.SqlError: ", String.Empty);
        }
    }
}
