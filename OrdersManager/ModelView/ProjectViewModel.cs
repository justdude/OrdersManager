using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using System.Data;
using OrdersManager.Model;

namespace OrdersManager.ModelView
{
    public class ProjectViewModel: Node
    {

        protected Project Project
        { get; set; }


        public ProjectViewModel(Project project)
        {
            this.Project = project;
        }
  
        public DataView TableView
        {
            get
            {
                DataTable table = new DataTable("TableView");
                table.Columns.Add("Id");
                table.Columns.Add("ProjectCost");
                table.Columns.Add("ProjectStatus");
                table.Columns.Add("StartDate");
                table.Columns.Add("FinalDate");

                table.Rows.Add(Id.ToString(), 
                               ProjectCost.ToString(), 
                               ProjectStatus.ToString(), 
                               StartDate.ToString(),
                               FinalDate.ToShortDateString());

                return table.DefaultView;
            }
        }

        public int Id
        {
            get
            {
                return Project.Id;
            }
            set
            {
                Project.Id = value;
                OnPropertyChanged("Id");
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
                return Project.ProjectCost;
            }
            set
            {
                Project.ProjectCost = value;
                OnPropertyChanged("ProjectCost");
            }
        }


        public string ProjectStatus
        {
            get
            {
                return Project.ProjectStatus;
            }
            set
            {
                Project.ProjectStatus = value;
                OnPropertyChanged("ProjectStatus");
            }
        }

        public DateTime StartDate
        {
            get
            {
                return Project.StartDate;
            }
            set
            {
                Project.StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public DateTime FinalDate
        {
            get
            {
                return Project.FinalDate;
            }
            set
            {
                Project.FinalDate = value;
                OnPropertyChanged("FinalDate");
            }
        }



        /*public ObservableCollection<TaskViewModel> Tasks
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
        }*/

        /*public override string ToString()
        {
            return Name;
        }*/

    }
}
