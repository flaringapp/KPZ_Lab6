using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using static Lab6.Data.UserModel;

namespace Lab6.Converters
{
    public class UserTypeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (UserType)value;
            var uri = new Uri(string.Format(@"../Images/UserType/ic_{0}.png", type), UriKind.Relative); 
            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
