using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Sifon.Shared.Helpers;
using Sifon.Shared.Model;

namespace Sifon.Shared.Extensions.Models
{
    public static class SolrInfoExtensions
    {
        public static SolrInfo Convert(PSObject data)
        {
            var s = data.ToStringArray();
            string version = new RegexHelper("^@{solr-spec-version=(.*)}$").Extract((string)s[1]);
            return new SolrInfo { Url = $"https://localhost:{s[0]}/solr", Version = version, Directory = (string)s[2] };
        }
   }
}
