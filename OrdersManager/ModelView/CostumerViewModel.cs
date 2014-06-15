using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using OrdersManager.Model;

namespace OrdersManager.ModelView
{
    public class CostumerViewModel : PersonViewModel
    {
        private string careerName = "Costumer";
        public string CareerName
        {
            get
            {
                return careerName;
            }
            set
            {
                CareerName = value;
                OnPropertyChanged("CareerName");
            }
        }
        public CostumerViewModel(Person person) : base(person)
        {

        }

    }
}
