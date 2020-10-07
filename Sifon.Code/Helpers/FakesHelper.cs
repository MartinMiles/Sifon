using System;
using System.Management.Automation;
using Sifon.Code.Model.Fake;
using Sifon.Code.Extensions;

namespace Sifon.Code.Helpers
{
    public class FakesHelper
    {
        public bool ValidateQueryTime(PSObject psObject)
        {
            var queryTime = psObject.Convert<QueryTime>();
            if (queryTime != null && queryTime.TimeOfQuery != DateTime.MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
