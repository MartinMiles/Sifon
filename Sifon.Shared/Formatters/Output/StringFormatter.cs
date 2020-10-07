using System.Management.Automation;

namespace Sifon.Code.Formatters.Output
{
    internal class StringFormatter :IOutputFormatter
    {
        private readonly object _object;

        internal StringFormatter(object objectToFormat)
        {
            var baseObject = ((PSObject)objectToFormat).BaseObject;
            _object = baseObject;
        }
        public string Format()
        {
            return _object.ToString();
        }
    }
}
