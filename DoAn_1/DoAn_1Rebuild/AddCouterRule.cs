using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_1Rebuild
{
    public class AddCouterRule : IRule
    {
        private int currentvalue = 0;
        private int _start = 0;
        public int start { get => _start; init { _start = value; currentvalue = value; } }
        public int step { get; init; }
        public int end { get; init; }
        public AddCouterRule()
        {
            start = 0;
            end = 999;
            currentvalue = 1;
            step = 1;
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
            var builder = new StringBuilder();
            builder.Append(name);
            builder.Append(" ");
            builder.Append(currentvalue);
            builder.Append(extension);
            currentvalue += step;
            return builder.ToString();
        }
    }
}
