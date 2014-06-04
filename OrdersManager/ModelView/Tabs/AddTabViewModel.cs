using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Windows.Input;

namespace OrdersManager.ModelView
{
    public class AddTabViewModel 
    {
        public int Index
        {
            get;
            set;
        }

        public List<string> WindowsTypes
        {
            get;
            set;
        }

        public ICommand AddClick
        {
            get;
            set;
        }

        public AddTabViewModel(List<string> tabTypesNames, Action closeAction)
        {
            this.WindowsTypes = tabTypesNames;
            AddClick = new DelegateCommand(
                ()=>
                {
                    OrdersManager.ModelView.OrdersRootViewModel.Instance.AddTab(Index);
                    closeAction();
                }
            );
        }


    }
}
