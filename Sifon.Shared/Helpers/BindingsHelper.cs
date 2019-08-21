using System.Collections.Generic;
using Microsoft.Web.Administration;

namespace Sifon.Shared.Helpers
{
    public class BindingsHelper
    {
        public static IList<KeyValuePair<string, string>> GetBindingsForSite(Site site)
        {
            var list = new List<KeyValuePair<string, string>>();

            if (site != null)
            {
                var bindings = site.Bindings;
                foreach (var binding in bindings)
                {
                    list.Add(new KeyValuePair<string, string>(binding.Protocol.ToUpper(), binding.Host));
                }
            }

            return list;
        }
    }
}
