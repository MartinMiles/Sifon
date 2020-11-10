using System.Management.Automation;
using Sifon.Abstractions.Model;
using Sifon.Code.Helpers;
using Sifon.Code.Model;

namespace Sifon.Code.Extensions.Models
{
    public static class SolrInfoExtensions
    {
        public static ISolrInfo Convert(PSObject data)
        {
            var s = data.ToStringArray();
            string version = new RegexHelper("^@{solr-spec-version=(.*)}$").Extract((string)s[1]);
            return new SolrInfo { Url = $"https://localhost:{s[0]}/solr", Version = version, Directory = (string)s[2] };
        }
   }
}
