using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DoAn_1Rebuild
{
    public class Converter : IValueConverter
    {
        public List<IRule> Rules { get; set; }
        public Converter()
        {
            Rules = new List<IRule>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (string)value;
            string newname = name;
            foreach (var rule in Rules)
            {
                newname = rule.reName(newname);
            }
            return newname;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
