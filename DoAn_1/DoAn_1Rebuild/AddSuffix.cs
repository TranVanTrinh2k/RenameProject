using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class AddSuffix : IRule
    {
        public string suffix { get; init; }
        public AddSuffix()
        {
            suffix = "Team";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public string TachRaTenFileKhongCoDuoi(string name)
        {
            int length = name.Length;
            char[] arr = name.ToCharArray(0, length);
            int vitri = name.LastIndexOf("\\");
            int vitricuoi = name.LastIndexOf(".");
            string v = name.Substring(vitri + 1, length - vitri - 1 - (length - vitricuoi));
            return v;
        }
        private string TachLayExtension(string path)
        {
            int length = path.Length;
            char[] arr = path.ToCharArray(0, length);
            int vitri = path.LastIndexOf("\\");
            int vitricuoi = path.LastIndexOf(".");
            string v = path.Substring(vitricuoi, length - vitricuoi);
            return v;
        }
        public string reName(string name)
        {
            string extension = TachLayExtension(name);
            name = TachRaTenFileKhongCoDuoi(name);
            var sb = new StringBuilder();
            sb.Append(name);
            sb.Append(" ");
            sb.Append(suffix);
            sb.Append(extension);
            return sb.ToString();
        }
    }
}
