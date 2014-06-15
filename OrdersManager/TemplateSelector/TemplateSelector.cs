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
        public DataTemplate TaskView { get; set; }

        public static TemplateSelector Instance
        {
            get;
            private set;
        }

        public TemplateSelector()
        {
            Instance = this;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FreelancerViewModel)
                return ProfileView;
            //return (container as FrameworkElement).FindResource("FreelancerViewModel") as DataTemplate;
            else if (item is CostumerViewModel)
                return ProfileView;
            //return (container as FrameworkElement).FindResource("CostumerViewModel") as DataTemplate;
            else if (item is ProjectViewModel)
                return GridedView;
            //return (container as FrameworkElement).FindResource("ProjectViewModel") as DataTemplate;
            else if (item is TaskViewModel)
                return TaskView;
            return null;

        }
    }
   
}
