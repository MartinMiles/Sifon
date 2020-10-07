using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Newtonsoft.Json;

namespace Sifon.Code.Extensions
{
    public static class PSObjectExtensions
    {
        public static string[] ToStringArray(this PSObject psObject)
        {
            var resultList = new List<string>();

            if (psObject?.BaseObject == null)
            {
                return null;
            }

            if (psObject.BaseObject is ArrayList list)
            {
                foreach (string item in list)
                {
                    resultList.Add(item);
                }
                return resultList.ToArray();
            }

            if (psObject.BaseObject is string[] array)
            {
                return array;
            }

            throw new NotSupportedException();
        }

        public static T Convert<T>(this PSObject psObject)
        {
            var serialized = JsonConvert.SerializeObject(psObject.Properties.ToDictionary(k => k.Name, v => v.Value));
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
