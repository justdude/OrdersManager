using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using System.Data;
using OrdersManager.Model;
using MVVM;
using OrdersManager.Database;
using System.Windows.Input;

namespace OrdersManager.ModelView
{
    class InsertProjectModelView : ProjectViewModel
    {
        public InsertProjectModelView(Project proj)
            : base(proj)
        {

        }


        private DelegateCommand ok;
        private DelegateCommand cansel;
        public new ICommand OkeyClick
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

        public new ICommand CancelClick
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


        public override bool OkeyEnabled()
        {
            return base.ProjectName.Length > 2;
        }


        public override void OnOkeyClick()
        {
            Command comm = new Database.Command(DatabaseManager.Instance.Connection);

            var item = new OrdersManager.Model.Project();
            item.ProjectName = base.ProjectName;
            item.ProjectStatus = base.ProjectStatus;
            item.ProjectCost = base.ProjectCost;
            item.TeamLeadId = base.TeamLeadId;
            item.StartDate = base.StartDate;
            item.FinalDate = base.FinalDate;

            comm.InsertProject(item);
            Views.ProjectInsertView.Instance.Close();
            //base.OnOkeyClick();
        }

    }
}
