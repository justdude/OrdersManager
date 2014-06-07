﻿using System;
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
                return @"\PhotoCache\" + Person.PhotoName;
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
        }*/

    }
}
