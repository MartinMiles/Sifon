using System.Collections.Generic;
using System.Linq;
using Sifon.Shared.Extensions;

namespace Sifon.Forms.Backup
{
    public class BackupViewModel
    {
        public bool SiteChecked { get; set; }
        public string Sitecore { get; set; }

        public bool IdentityChecked => Identity.NotEmpty();
        public string Identity { get; set; }

        public bool XConnectChecked => XConnect.NotEmpty();
        public string XConnect { get; set; }

        public bool HorizonChecked => Horizon.NotEmpty();
        public string Horizon { get; set; }

        public bool PublishingChecked => Publishing.NotEmpty();
        public string Publishing { get; set; }

        public bool CommerceChecked => CommerceSites.Any();
        public IEnumerable<KeyValuePair<string, string>> CommerceSites { get; set; }
    }
}
