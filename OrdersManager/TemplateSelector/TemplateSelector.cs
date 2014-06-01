using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using OrdersManager.ModelView;

namespace OrdersManager.TemplateSelector
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate GridedView { get; set; }
        public DataTemplate ProfileView { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FreelancerViewModel || item is CostumerViewModel)
                return ProfileView;

            return GridedView;
        }
    }
   
}
