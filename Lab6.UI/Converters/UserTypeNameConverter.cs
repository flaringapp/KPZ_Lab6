using System;
using System.Globalization;
using System.Windows.Data;
using static Lab6.Data.UserModel;

namespace Lab6.Converters
{
    public class UserTypeNameConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (UserType)value;
            return type.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
