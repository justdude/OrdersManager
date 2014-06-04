using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;

namespace OrdersManager.ModelView
{

    public class TaskViewModel : Node
    {

        private string name = "Some task";
        private string taskStatus = "in progress";

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        public string TaskStatus
        {
            get
            {
                return taskStatus;
            }
            set
            {
                taskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }

        public string EstimateDate
        {
            get
            {
                return DateTime.Now.ToString();
            }
            set
            {
                OnPropertyChanged("EstimateDate");
            }
        }


        public ProjectViewModel Project
        {
            get; set;
        }

        /*public ObservableCollection<FreelancerViewModel> Freelancers
        {
            get
            {
                return new ObservableCollection<FreelancerViewModel>(CacheManager.CacheManager.Instance.Freelancers); //.Where(p=>p. = base.FIO) 
            }
            set
            {
                CacheManager.CacheManager.Instance.Freelancers = value.ToList();
                OnPropertyChanged("Freelancers");
            }
        }*/
        /*public override string ToString()
        {
            return Name;
        }*/

        public override string ToString()
        {
            return Name;
        }

    }
}
