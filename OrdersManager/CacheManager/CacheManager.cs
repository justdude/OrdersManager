using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrdersManager.ModelView;


namespace OrdersManager.CacheManager
{
    public class CacheManager
    {


       // public List<FreelancerViewModel> Freelancers;
        public List<ProjectViewModel> Projects;
        public List<FreelancerViewModel> Freelancers;
        public List<CostumerViewModel> Costumers;


        public CacheManager()
        {
            Projects = new List<ProjectViewModel>()
            {
                new ProjectViewModel(),
                new ProjectViewModel(),
                new ProjectViewModel()
            };

            Freelancers = new List<FreelancerViewModel>()
            {
                new FreelancerViewModel(),
                new FreelancerViewModel(),
                new FreelancerViewModel(),
                new FreelancerViewModel(),
                new FreelancerViewModel()
            };

            Costumers = new List<CostumerViewModel>()
            {
                new CostumerViewModel(),
                new CostumerViewModel(),
                new CostumerViewModel(),
                new CostumerViewModel()
            };
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
