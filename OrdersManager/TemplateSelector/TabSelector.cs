using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using OrdersManager.ModelView;

namespace OrdersManager.TemplateSelector
{
    public class TabSelector : DataTemplateSelector
    {
        public DataTemplate PersonTab { get; set; }
        public DataTemplate ProjectTab { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is PersonTabViewModel)
                return PersonTab;

            return ProjectTab;
        }
    }
   
}
