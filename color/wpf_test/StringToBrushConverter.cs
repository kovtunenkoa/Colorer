using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Data;
using System.Globalization;

namespace wpf_test
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BrushConverter converter = new BrushConverter();
            System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString((string)value);
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
