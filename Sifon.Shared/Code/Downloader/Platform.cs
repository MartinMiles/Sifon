using System.Collections.Generic;

namespace Sifon.Shared.Code.Downloader
{
    internal class Platform
    {
        public string name { get; set; }
        public string folder{ get; set; }
        public IEnumerable<Resource> resources { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
