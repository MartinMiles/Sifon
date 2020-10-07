using System;

namespace Sifon.Code.Formatters.Text
{
    public class ErrorFormatter
    {
        public string Format(string exceptionMessage)
        {
            return exceptionMessage.Replace("System.Data.SqlClient.SqlError: ", String.Empty);
        }
    }
}
