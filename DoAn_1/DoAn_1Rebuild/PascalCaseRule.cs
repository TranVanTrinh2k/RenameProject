using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class PascalCase : IRule
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

        public string reName(string name)
        {
            char[] charArray = name.ToCharArray();
            bool foundSpace = true;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.IsLetter(charArray[i]))
                {
                    if (foundSpace)
                    {
                        charArray[i] = Char.ToUpper(charArray[i]);
                        foundSpace = false;
                    }
                }
                else
                {
                    foundSpace = true;
                }
            }
            name = new string(charArray);
            return name;
        }
    }
}
