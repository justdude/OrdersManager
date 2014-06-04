using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;

namespace OrdersManager.ModelView
{
    public class PersonViewModel: Node
    {
        private string fio = "Sherlock Holmes";
        public string FIO
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
                OnPropertyChanged("Fio");
            }
        }

        protected string photoPath = @"\PhotoCache\programmist.png";
        public string PhotoPath
        {
            get
            {
                return photoPath;
            }
            set
            {
                photoPath = value;
                OnPropertyChanged("PhotoPath");
            }
        }

        public string Adress
        {
            get
            {
                return "London, 221B Baker Street";
            }
            set
            {
                OnPropertyChanged("Adress");
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

        public override string ToString()
        {
            return FIO;
        }

    }
}
