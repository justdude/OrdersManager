using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using System.Data;

namespace OrdersManager.ModelView
{
    public class ProjectViewModel: Node
    {

        private float projectCost = 1000000;
        private string projectStatus = "In progres";
        private DateTime finalDate = DateTime.Now;

        public DataView Project
        {
            get
            {
                DataTable table = new DataTable("Project");
                table.Columns.Add("Name");
                table.Columns.Add("ProjectCost");
                table.Columns.Add("ProjectStatus");
                table.Columns.Add("FinalDate");

                table.Rows.Add(Name.ToString(), 
                               ProjectCost.ToString(), 
                               ProjectStatus.ToString(), 
                               FinalDate.ToShortDateString());

                return table.DefaultView;
            }
        }

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

        public OrdersManager.ModelView.FreelancerViewModel Lead
        {
            get
            {
                FreelancerViewModel freel = null;
                freel = CacheManager.CacheManager.Instance.Freelancers.Where(p => p.IsLead == true).FirstOrDefault();
                return freel;
            }
            set
            {
                //projectCost = value;
                OnPropertyChanged("Lead");
            }
        }

        public float ProjectCost
        {
            get
            {
                return projectCost;
            }
            set
            {
                projectCost = value;
                OnPropertyChanged("ProjectCost");
            }
        }


        public string ProjectStatus
        {
            get
            {
                return projectStatus;
            }
            set
            {
                projectStatus = value;
                OnPropertyChanged("ProjectStatus");
            }
        }
        

        public DateTime FinalDate
        {
            get
            {
                return finalDate;
            }
            set
            {
                finalDate = value;
                OnPropertyChanged("FinalDate");
            }
        }


        public ObservableCollection<TaskViewModel> Tasks
        {
            get
            {
                var tasks = new List<TaskViewModel>(){ new TaskViewModel(), new TaskViewModel(), new TaskViewModel()};
                return new ObservableCollection<TaskViewModel>(tasks); //.Where(p=>p. = base.FIO) 
            }
            set
            {
                OnPropertyChanged("Tasks");
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
