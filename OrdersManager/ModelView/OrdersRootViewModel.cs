using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using MVVM;

namespace OrdersManager.ModelView
{
    public class OrdersRootViewModel : Node
    {


        public List<MenuItem> MenuOptions
        {
            get  {
               var menu = new List<MenuItem>();
               var mi = new MenuItem("Add");
                for (int i = 0; i < 4; i++ )
                {
                    /*var sff = fl;
                    mi.Children.Add(new MenuItem(fl.Attributes.Description) 
                    { 
                        Command = new DelegateCommand(() =>
                        { 
                            LoadFromFormat(sff); 
                        }) */
                }
                menu.Add(mi);

               menu.Add(new MenuItem("Close _All") 
                                    { 
                                        /*Command = new DelegatingCommand(OnCloseAll, 
                                                        () => FileList.Count > 0)*/
                                    });
               return menu;
            }


        }

        public DataView Project
        {
            get
            {
                DataTable table = new DataTable("Project");
                table.Columns.Add("Column1");
                table.Columns.Add("Column2");
                table.Rows.Add("text1","text2");
                table.Rows.Add("text1", "text2");
                return table.DefaultView;
            }
        }

        public ObservableCollection<ViewModelBase> SelectedNodes
        {
            get
            {
                var data = new ObservableCollection<ViewModelBase>();
                //data.Add(new FreelancerViewModel());
                data.Add(new TaskViewModel());
                return data;
            }
        }


        //public ObservableCollection<PersonViewModel> Persons { get; set; }
        public ObservableCollection<ProjectViewModel> Projects 
        {
            get
            {
                var data = OrdersManager.CacheManager.CacheManager.Instance.Projects;
                var list = new ObservableCollection<ProjectViewModel>(data);
                return list;
            }
        }

        public ObservableCollection<CostumerViewModel> Costumers
        {
            get
            {
                var data = OrdersManager.CacheManager.CacheManager.Instance.Costumers;
                var list = new ObservableCollection<CostumerViewModel>(data);
                return list;
            }
        }

        public ObservableCollection<FreelancerViewModel> Freelancers
        {
            get
            {
                var data = OrdersManager.CacheManager.CacheManager.Instance.Freelancers;
                var list = new ObservableCollection<FreelancerViewModel>(data);
                return list;
            }
        }

        public ObservableCollection<Node> Nodes { get; private set; }

        public OrdersRootViewModel()
        {
            var Projects = OrdersManager.CacheManager.CacheManager.Instance.Projects;
            for (int i = 0; i < Freelancers.Count; i++)
            {
                Freelancers[i].Children.Add(Costumers[0]);
                foreach (var pr in Projects)
                {
                    pr.Children.Add(Freelancers[i]);
                }
               
            }
            Nodes = new ObservableCollection<Node>(Projects);

            

        }

    }
}
