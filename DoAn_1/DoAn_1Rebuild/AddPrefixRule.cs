using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class AddPrefixRule : IRule
    {
        public string Prefix { get; init; }
        public AddPrefixRule()
        {
            Prefix = "TVT";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string reName(string name)
        {
            var sb = new StringBuilder();
            sb.Append(Prefix);
            sb.Append(" ");
            sb.Append(name);
            return sb.ToString();
        }
    }
}
