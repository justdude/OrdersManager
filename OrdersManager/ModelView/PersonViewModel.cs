using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using OrdersManager.Model;
namespace OrdersManager.ModelView
{
    public class PersonViewModel: Node
    {

        protected Person Person
        { get; set; }

        public PersonViewModel(Person person)
        {
            this.Person = person;
        }


        public long PersonId
        {
            get
            {
                return Person.Id;
            }
            set
            {
                Person.Id = value;
                OnPropertyChanged("PersonId");
            }
        }

        public string FIO
        {
            get
            {
                return Person.FIO;
            }
            set
            {
                Person.FIO = value;
                OnPropertyChanged("FIO");
            }
        }

        public string PhotoPath
        {
            get
            {
                return System.IO.Path.GetFullPath("PhotoCache/" + Person.PhotoName);
                //return @"\PhotoCache\" + Person.PhotoName;
            }
            set
            {
                Person.PhotoName = value;
                OnPropertyChanged("PhotoPath");
            }
        }

        public string Adress
        {
            get
            {
                return Person.Adress;
            }
            set
            {
                Person.Adress = value;
                OnPropertyChanged("Adress");
            }
        }


       /* public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return new ObservableCollection<ProjectViewModel>(Cache.Cache.Instance.Projects); //.Where(p=>p. = base.FIO) 
            }
            set
            {
                Cache.Cache.Instance.Projects = value.ToList();
                OnPropertyChanged("Projects");
            }
        }

        public override string ToString()
        {
            return FIO;
        }*/

    }
}
