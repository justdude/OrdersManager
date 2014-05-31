using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;

namespace OrdersManager.ModelView
{
    public class PersonViewModel: ViewModelBase
    {
        private string fio = "Some name";
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

        protected string photoPath;
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
                return photoPath;
            }
            set
            {
                photoPath = value;
                OnPropertyChanged("Adress");
            }
        }


        /*public List<ProjectViewModel> Projects { get; set; }

        public PersonViewModel()
        {
            List<ProjectViewModel> arr = new List<ProjectViewModel>() { new ProjectViewModel(), new ProjectViewModel() };
            Projects = arr;
        }*/

    }
}
