using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Training7.Converter
{
    public class IntToBrushConverter : IValueConverter
    {
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush orange = new SolidColorBrush(Colors.Orange);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int) value;


            if(number >= 5)
            {
                return green;
            }else if(number >= 3)
            {
                return yellow;
            }else if(number >=1 || number == 0)
            {
                return red;
            }

            //error state = anything else = orange
            return orange;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
