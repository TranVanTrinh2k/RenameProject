using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class OneSpaceRule : IRule
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
        public string reName(string name)
        {
            name = name.Trim();
            RegexOptions options = RegexOptions.None;
            Regex reg = new Regex(@"\s\s+", options);
            name = reg.Replace(name, " ");
            return name;
        }
    }
}
