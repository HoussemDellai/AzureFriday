using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureFriday.Converters
{
    public class SecondsToMinutesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var seconds = (int)value;

            var duration = "" + seconds / 60;

            if (seconds / 60 < 10)
            {
                duration = "0" + duration;
            }

            if (seconds % 60 < 10)
            {
                duration += ":0" + seconds % 60;
            }
            else
            {
                duration += ":" + seconds % 60;
            }

            return duration;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
