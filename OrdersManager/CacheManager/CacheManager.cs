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

        public CacheManager()
        {

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
