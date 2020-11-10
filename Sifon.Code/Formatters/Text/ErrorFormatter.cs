using System;
using Sifon.Abstractions.Formatters;

namespace Sifon.Code.Formatters.Text
{
    public class ErrorFormatter : IFormatter<string>
    {
        public string Format(string exceptionMessage)
        {
            return exceptionMessage.Replace("System.Data.SqlClient.SqlError: ", String.Empty);
        }
    }
}
