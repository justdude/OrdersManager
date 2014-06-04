using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OrdersManager.ModelView;

namespace OrdersManager.Views
{
    /// <summary>
    /// Interaction logic for TabTypeSelect.xaml
    /// </summary>
    public partial class TabTypeSelect : Window
    {
        public TabTypeSelect(List<string> tabTypesNames)
        {
            InitializeComponent();
            Action act = () => this.Close();
            AddTabViewModel modelView = new AddTabViewModel(tabTypesNames, act);
            this.DataContext = modelView;
        }
    }
}
