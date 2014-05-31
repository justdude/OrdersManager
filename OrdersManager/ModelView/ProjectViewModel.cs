using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;

namespace OrdersManager.ModelView
{
    public class ProjectViewModel: ViewModelBase
    {
        public string Name
        {
            get
            {
                return "Project name";
            }
            set
            {
                OnPropertyChanged("Name");
            }
        }

    }
}
