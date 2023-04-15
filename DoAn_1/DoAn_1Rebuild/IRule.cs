using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public interface IRule : ICloneable
    {
        string reName(string name);
    }
}
