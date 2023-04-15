using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class AllLower : IRule
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string reName(string name)
        {
            name = name.ToLower();
            return name;
        }
    }
}
