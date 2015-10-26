using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureFriday.Converters
{
    public class LinkToVideoExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var link = value as string;

            if (link.Contains("_"))
            {
                return link.Substring(link.LastIndexOf("_") + 1);
            }

            return link.Substring(link.LastIndexOf(".") + 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
