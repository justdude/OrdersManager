using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
 
namespace OrdersManager.ModelView
{
    public class FreelancerViewModel : PersonViewModel
    {
        private string careerName = "Freelanser";
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

        /*public ObservableCollection<TaskViewModel> Tasks
        {
            get
            {
                var tasks = new List<TaskViewModel>() { new TaskViewModel(), new TaskViewModel(), new TaskViewModel() };
                return new ObservableCollection<TaskViewModel>(tasks);
            }
            set
            {
                OnPropertyChanged("Tasks");
            }
        }*/

        public bool IsLead { get; set; }

        public FreelancerViewModel()
        {
            base.FIO = "Dr. Watson";
        }

    }
}
