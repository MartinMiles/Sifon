using System.Text.RegularExpressions;

namespace Sifon.Code.Helpers
{
    public class RegexHelper
    {
        private readonly string _pattern;

        public RegexHelper(string pattern)
        {
            _pattern = pattern;
        }

        public bool Match(string line)
        {
            return Regex.Match(line, _pattern).Success;
        }

        public string Extract(string line)
        {
            var m = Regex.Match(line, _pattern);
            if (m.Success)
            {
                return m.Groups[1].Value;
            }

            return null;
        }

        public string Replace(string line)
        {
            return Regex.Replace(line, _pattern, "");
        }
    }
}