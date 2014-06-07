using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using OrdersManager.Model;

namespace OrdersManager.ModelView
{

    public class TaskViewModel : Node
    {

        protected Task Task
        {
            get;
            set;
        }

        public TaskViewModel(Task task)
        {
            this.Task = task;
        }

        public new int Id
        {
            get
            {
                return Task.Id;
            }
            set
            {
                Task.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public int ExecutorId
        {
            get
            {
                return Task.ExecutorId;
            }
            set
            {
                Task.ExecutorId = value;
                OnPropertyChanged("EstimateDate");
            }
        }
        public int ProjectId
        {
            get
            {
                return Task.ProjectId;
            }
            set
            {
                Task.ProjectId = value;
                OnPropertyChanged("ProjectId");
            }
        }

        public string Name
        {
            get
            {
                return Task.Name;
            }
            set
            {
                Task.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string TaskStatus
        {
            get
            {
                return Task.TaskStatus;
            }
            set
            {
                Task.TaskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }

        public string StartDate
        {
            get
            {
                return Task.StartDate;
            }
            set
            {
                Task.StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        public string EstimateDate
        {
            get
            {
                return Task.EstimateDate;
            }
            set
            {
                Task.EstimateDate = value;
                OnPropertyChanged("EstimateDate");
            }
        }


        /*public ProjectViewModel TableView
        {
            get; set;
        }*/


        /*public override string ToString()
        {
            return Name;
        }*/

        /*public override string ToString()
        {
            return Name;
        }*/

    }
}
