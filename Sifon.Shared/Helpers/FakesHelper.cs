using System;
using System.Management.Automation;
using Sifon.Shared.Extensions;
using Sifon.Shared.Model.Fake;

namespace Sifon.Shared.Helpers
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
