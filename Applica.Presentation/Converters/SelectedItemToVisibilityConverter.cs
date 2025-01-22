using System.Globalization;
using System.Windows.Data;
using System.Windows;
using Applica.Domain.Entities;
using Applica.Presentation.ViewModels.Models;
using System.Diagnostics;

namespace Applica.Presentation.Converters;

public class SelectedItemToVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length < 2)
            return Visibility.Collapsed;

        var currentItem = values[0] as CompanyVM;  
        var selectedItem = values[1] as CompanyVM;

        if (currentItem == null || selectedItem == null)
            return Visibility.Collapsed;

        Debug.WriteLine($"CurrentItem Id: {currentItem.Id}, SelectedItem Id: {selectedItem.Id}");
        return currentItem.Id == selectedItem.Id ? Visibility.Visible : Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}