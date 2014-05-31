using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
 
namespace OrdersManager.ModelView
{
    class FreelancerViewModel : PersonViewModel
    {
        private string careerName = "Freelanser";
        public string CareerName
        {
            get
            {
                return CareerName;
            }
            set
            {
                CareerName = value;
                OnPropertyChanged("CareerName");
            }
        }


        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return new ObservableCollection<ProjectViewModel>(CacheManager.CacheManager.Instance.Projects); //.Where(p=>p. = base.FIO) 
            }
            set
            {
                CacheManager.CacheManager.Instance.Projects = value.ToList();
                OnPropertyChanged("Projects");
            }
        }


    }
}
