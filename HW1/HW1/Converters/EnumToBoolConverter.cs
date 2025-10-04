namespace HW1.Converters;

public class EnumToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var parameterString = parameter as string;
        if (parameterString == null)
            return false;

        if (Enum.IsDefined(value.GetType(), value) == false)
            return false;

        var parameterValue = Enum.Parse(value.GetType(), parameterString);

        return parameterValue.Equals(value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var parameterString = parameter as string;
        if (parameterString == null)
            return false;

        if (value is bool isChecked && isChecked)
            return Enum.Parse(targetType, parameterString);
        return false;
    }
}