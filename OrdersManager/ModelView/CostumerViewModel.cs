using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;

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
        public CostumerViewModel()
        {
            base.FIO = "Moriarti";
        }

    }
}
