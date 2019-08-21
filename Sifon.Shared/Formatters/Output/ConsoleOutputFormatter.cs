using System.Data;
using System.Management.Automation;

namespace Sifon.Shared.Formatters.Output
{
    public class ConsoleOutputFormatter
    {
        internal IOutputFormatter CreateFormatter(PSObject obj)
        {
            var baseObject = obj.BaseObject;

            if (baseObject is string)
            {
                return new StringFormatter(obj);
            }

            if (baseObject is DataRow)
            {
                return new DataRowFormatter(obj);
            }

            return new GenericObjectFormatter(obj);
        }

        public string Format(PSObject obj)
        {
            var formatter = CreateFormatter(obj);
            return formatter.Format();
        }
    }
}
