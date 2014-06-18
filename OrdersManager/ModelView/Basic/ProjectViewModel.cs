using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;
using System.Collections.ObjectModel;
using System.Data;
using OrdersManager.Model;
using System.Windows.Input;

namespace OrdersManager.ModelView
{
    public class ProjectViewModel: Node
    {

        protected Project Project
        { get; set; }


        public ProjectViewModel(Project project)
        {
            this.Project = project;
            base.Text = ProjectName;
        }
  
        public DataView TableView
        {
            get
            {
                DataTable table = new DataTable("TableView");
                table.Columns.Add("ProjectName");
                table.Columns.Add("ProjectCost");
                table.Columns.Add("ProjectStatus");
                table.Columns.Add("StartDate");
                table.Columns.Add("FinalDate");

                table.Rows.Add(ProjectName.ToString(), 
                               ProjectCost.ToString(), 
                               ProjectStatus.ToString(), 
                               StartDate.ToString(),
                               FinalDate.ToShortDateString());

                return table.DefaultView;
            }
        }

        public long Idproject
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


        public long CostumerId
        {
            get
            {
                return Project.CostumerId;
            }
            set
            {
                Project.CostumerId = value;
                OnPropertyChanged("CostumerId");
            }
        }

        public long TeamLeadId
        {
            get
            {
                return Project.TeamLeadId;
            }
            set
            {
                Project.TeamLeadId = value;
                OnPropertyChanged("TeamLeadId");
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

        public string ProjectName
        {
            get
            {
                return Project.ProjectName;
            }
            set
            {
                Project.ProjectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

         //AllPeoples}" SelectedItem="{Binding SelectedTeamLead

        //SelectedCostumer

        private List<Costumer> allPeoples;
        public List<Costumer> AllPeoples
        {
            get
            {
                if (allPeoples == null)
                {
                    var comm = new Database.Command(Database.DatabaseManager.Instance.Connection);
                    var table = comm.SelectCostumers();
                    allPeoples = Database.DatabaseConverter.ConvertRowsToList<Costumer>(table, Database.DatabaseConverter.ToCostumer);
                }
                return allPeoples;
            }
            set
            {
                allPeoples = value;
                OnPropertyChanged("AllPeoples");
            }
        }


        private Costumer selectedCostumer;
        public Costumer SelectedCostumer
        {
            get
            {
                if (selectedCostumer == null)
                {
                    var comm = new Database.Command(Database.DatabaseManager.Instance.Connection);
                    selectedCostumer = AllPeoples.Where(p => p.Id == CostumerId).FirstOrDefault();
                }
                return selectedCostumer;
            }
            set
            {
                selectedTeamLead = value;
                OnPropertyChanged("SelectedTeamLead");
            }
        }

        private Costumer selectedTeamLead;
        public Costumer SelectedTeamLead
        {
            get
            {
                if (selectedTeamLead == null)
                {
                    var comm = new Database.Command(Database.DatabaseManager.Instance.Connection);
                    selectedTeamLead = AllPeoples.Where(p => p.Id == TeamLeadId).FirstOrDefault();
                }
                return selectedTeamLead;
            }
            set
            {
                selectedTeamLead = value;
                OnPropertyChanged("SelectedTeamLead");
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
            return true;
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
