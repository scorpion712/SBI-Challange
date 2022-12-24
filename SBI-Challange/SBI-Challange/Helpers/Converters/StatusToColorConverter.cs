using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SBIChallange.Helpers.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                var status = (int) value;
                return status == 0 ? Application.Current.Resources["NotActiveColor"] : Application.Current.Resources["ActiveColor"];
            }
            return Application.Current.Resources["NotActiveColor"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
