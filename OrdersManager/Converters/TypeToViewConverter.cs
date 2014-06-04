using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using OrdersManager.ModelView;

namespace OrdersManager.Converters
{
    public class TypeToViewConverter : IValueConverter
    {
        public DataTemplate GridedView 
        { 
            get
            {
                var t = Application.Current.FindResource("PersonTemplate") as DataTemplate;
                return t;
            }
        }
        public DataTemplate ProfileView
        { 
            get
            {
                return Application.Current.FindResource("GridedTemplate") as DataTemplate;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is FreelancerViewModel || value is CostumerViewModel)
                return ProfileView;

            return GridedView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
