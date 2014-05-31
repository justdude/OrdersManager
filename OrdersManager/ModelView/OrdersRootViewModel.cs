using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVM;

namespace OrdersManager.ModelView
{
    public class OrdersRootViewModel : ViewModelBase
    {

        //public ObservableCollection<PersonViewModel> Persons { get; set; }
        //public ObservableCollection<PersonViewModel> Projects { get; set; }
        public ObservableCollection<PersonViewModel> Costumers { get; set; }

        public OrdersRootViewModel()
        {
            Costumers = new ObservableCollection<PersonViewModel>(
                new PersonViewModel[] { new PersonViewModel(), new PersonViewModel() }  
                );

        }

    }
}
