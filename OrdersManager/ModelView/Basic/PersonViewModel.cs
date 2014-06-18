using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using OrdersManager.Model;
using System.Windows.Input;
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


        private DelegateCommand ok;
        private DelegateCommand cansel;
        public ICommand OkeyClick
        {
            get
            {
                if (ok == null)
                    ok = new DelegateCommand(OnOkeyClick, OkeyEnabled);
                return ok;
            }
            set
            {
                OnPropertyChanged("OkeyClick");
            }
        }

        public ICommand CancelClick
        {
            get
            {

                if (cansel == null)
                    cansel = new DelegateCommand(OnCancelClick);

                return cansel;
            }
            set
            {
                OnPropertyChanged("CancelClick");
            }
        }


        public virtual bool OkeyEnabled()
        {
            return false;
        }

        public virtual void OnOkeyClick()
        {
            System.Windows.MessageBox.Show("");
        }

        public virtual void OnCancelClick()
        {
            System.Windows.MessageBox.Show("OnCancelClick");

        }
    }
}
