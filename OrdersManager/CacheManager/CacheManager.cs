using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrdersManager.ModelView;
using System.Collections.ObjectModel;


namespace OrdersManager.Cache
{
    public class CacheManager
    {

        public CacheManager()
        {
            
        }


        private ObservableCollection<ProjectViewModel> projects;
        private ObservableCollection<TaskViewModel> tasks;
        private ObservableCollection<CostumerViewModel> costumers;
        private ObservableCollection<FreelancerViewModel> freelancers;


        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                /*if (projects == null)
                    projects = new ObservableCollection<ProjectViewModel>();*/
                return projects;
            }
            set
            {
                projects = value;
            }
        }


        public ObservableCollection<CostumerViewModel> Costumers
        {
            get
            {
                /*if (projects == null)
                    projects = new ObservableCollection<ProjectViewModel>();*/
                return costumers;
            }
            set
            {
                costumers = value;
            }
        }

        public ObservableCollection<FreelancerViewModel> Freelancers
        {
            get
            {
                return freelancers;
            }
            set
            {
                freelancers = value;
            }
        }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
            }
        }

        private static CacheManager cacheManager;
        public static CacheManager Instance
        {
            get
            {
                if (cacheManager==null)
                {
                    cacheManager = new CacheManager();
                }
                return cacheManager;
            }
        }

    }
}
