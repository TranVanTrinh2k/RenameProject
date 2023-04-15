using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class RemoveSpecialCharRule : IRule
    {
        public string ReplaceCharSpecial { get; set; }
        public RemoveSpecialCharRule()
        {
            ReplaceCharSpecial = " ";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string reName(string name)
        {
            Regex reg = new Regex(@"[^a-zA-Z0-9.]");
            name = reg.Replace(name, ReplaceCharSpecial);
            return name;
        }
    }
}
