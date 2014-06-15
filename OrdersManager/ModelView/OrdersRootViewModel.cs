using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using MVVM;
using System.Windows.Input;
using System.Windows.Controls;
using MVVM;
using System.ComponentModel;
using System.Windows.Data;

using OrdersManager.Database;
using OrdersManager.Views;
using OrdersManager.ModelView;
using OrdersManager.Model;
using System.Threading.Tasks;

namespace OrdersManager.ModelView
{
    public class OrdersRootViewModel : ViewModelBase
    {

        public static OrdersRootViewModel Instance
        {
            get;
            private set;
        }


        #region Tabs
        private ItemCollection Tabs;

        public TabItem[] TabsStartCollections
        {
            get;
            private set;
        }
        #endregion

        #region ContextMenu
        public List<MVVM.MenuItem> MenuOptions
        {
            get  {
                var menu = new List<MVVM.MenuItem>();
                var add = new MVVM.MenuItem("Add");

                add.Command = new DelegateCommand(() => 
                    {
                        var selected = SelectedItem;
                        if (selected != null)
                        { 

                            if (selected is PersonViewModel)
                            {
                                var window = new PersonInsertView();
                                window.Show();
                                window.Activate();
                            }

                            else if (selected is ProjectViewModel)
                            {
                                var window = new PersonInsertView();
                                window.Show();
                            }

                            else if (selected is TaskViewModel)
                            {
                                var window = new PersonInsertView();
                                window.Show();
                            }
                        }
                    
                    });

                var remove = new MVVM.MenuItem("Remove")
                {
                    Command = new MVVM.DelegateCommand(
                                                         () => {
                                                             
                                                             //SelectedItem 
                                                            
                                                         }
                                )
                };

                var goTo = new MVVM.MenuItem("Go to...")
                {
                    Command =  new MVVM.DelegateCommand( 
                                                         () => { GoToTab(SelectedItem.GetType().ToString()); }
                                )
                };



                menu.Add(add);
                menu.Add(remove);
                menu.Add(goTo);
                menu.Add(new MVVM.MenuItem("Close _All") 
                                    { 
                                        /*Command = new DelegatingCommand(OnCloseAll, 
                                                        () => FileList.Count > 0)*/
                                    });

               return menu;
            }
        }
        #endregion

        #region Lisbox people type
        private int selectedItemTypeNameIndex;
        public int SelectedItemTypeNameIndex
        {
            get
            {
                return selectedItemTypeNameIndex;
            }
            set
            {
                selectedItemTypeNameIndex = value;
                if (selectedItemTypeNameIndex == 0)
                {
                    Peoples = FillCostumers();
                }
                else
                    Peoples = FillFreelancer();
                OnPropertyChanged("SelectedItemTypeNameIndex");
            }
        }
        #endregion

        #region Items
        private object selectedNode;
        private ObservableCollection<Node> projects;
        private ObservableCollection<Node> peoples;

        public object SelectedItem
        {
            get
            {
                selectedNode = Node.GetSelectedItem(Projects);
                return selectedNode;
            }
            set
            {
                selectedNode = value;
                var cachedNode = selectedNode as Node;
                if (cachedNode != null)
                    cachedNode.IsSelected = true;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public ObservableCollection<Node> Projects
        {
            get
            {
                return projects;
            }
            private set
            {
                projects = value;
                OnPropertyChanged("Projects");
            }
        }

        public ObservableCollection<Node> Peoples
        {
            get
            {
                return peoples;
            }
            private set
            {
                peoples = value;
                OnPropertyChanged("Peoples");
            }
        }
 

        #endregion

        #region Commands
        public ICommand LoadContent 
        { 
            get; 
            set; 
        }

        public ICommand AddTabItemClick
        {
            get
            {
                if (onAddTabItemClick == null)
                {
                    onAddTabItemClick = new DelegateCommand(OnAddTabItemClick);
                }
                return onAddTabItemClick;
            }
            set
            {
                OnPropertyChanged("AddTabItemClick");
            }
        }
        #endregion

        #region Loaders states
        private bool projectsRingVisibility = false;
        private bool personsRingVisibility = false;
        private bool infoUsersRingVisibility = false;
        private bool infoProjectsRingVisibility = false;

        public bool ProjectsRingVisibility
        {
            get
            {
                return projectsRingVisibility;
            }
            set
            {
                projectsRingVisibility = value;
                OnPropertyChanged("ProjectsRingVisibility");
            }
        }
        public bool InfoProjectsRingVisibility
        {
            get
            {
                return infoProjectsRingVisibility;
            }
            set
            {
                infoProjectsRingVisibility = value;
                OnPropertyChanged("InfoProjectsRingVisibility");
            }
        }
        public bool InfoUsersRingVisibility
        {
            get
            {
                return infoUsersRingVisibility;
            }
            set
            {
                infoUsersRingVisibility = value;
                OnPropertyChanged("InfoUsersRingVisibility");
            }
        }
        public bool PersonsRingVisibility
        {
            get
            {
                return personsRingVisibility;
            }
            set
            {
                infoProjectsRingVisibility = value;
                OnPropertyChanged("PersonsRingVisibility");
            }
        }

        #endregion

        #region Delegetes click
        private DelegateCommand onAddTabItemClick;
        #endregion     

        public OrdersRootViewModel(ItemCollection tabs)
        {
            Instance = this;
            this.Tabs = tabs;
            FillTabs();

            LoadContent = new DelegateCommand(
                () => 
                {
                    //this.SelectedItem = Node.GetSelectedItem(this.Projects);
                },
                () => { return true; }
                );


            BackgroundWorker worker = new BackgroundWorker();

            ProjectsRingVisibility = true;
            PersonsRingVisibility = true;
            InfoProjectsRingVisibility = true;
            InfoUsersRingVisibility = true;

            worker.DoWork += new DoWorkEventHandler((sender, e) =>
                {
                   /* var comm = new Command(DatabaseManager.Instance.Connection);
                    Cache.CacheManager.Instance.Freelancers = DatabaseLoader.ComputeFreelansers(comm);
                    Cache.CacheManager.Instance.Costumers = DatabaseLoader.ComputeCostumers(comm);
                    Cache.CacheManager.Instance.Tasks = DatabaseLoader.ComputeTasks(comm);
                    Cache.CacheManager.Instance.Projects = DatabaseLoader.ComputeProjects(comm);
                    var nodes = new ObservableCollection<MVVM.Node>(Cache.CacheManager.Instance.Projects.Select(x => x as Node).ToList());*/

                    System.Threading.Thread.Sleep(2000);


                    Projects = FillProjects();
                    Peoples = FillCostumers();
                       
                    ProjectsRingVisibility = false;
                    PersonsRingVisibility = false;
                    InfoProjectsRingVisibility = false;
                    InfoUsersRingVisibility = false;
                });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender,e) =>
                {

                });


            worker.RunWorkerAsync();

        }

        #region Select From Database for treeview

        public ObservableCollection<Node> FillProjects()
        {
            var comm = new Command(DatabaseManager.Instance.Connection);
            var nodes = new ObservableCollection<Node>();

            var Freelancers = DatabaseLoader.ComputeFreelansers(comm).ToList();
            //var Costumers = DatabaseLoader.ComputeCostumers(comm).ToList();
            var Tasks = DatabaseLoader.ComputeTasks(comm).ToList();
            var Projects = DatabaseLoader.ComputeProjects(comm).ToList();

            foreach(var project in Projects)
            {
                Node nodeProject = project;
                Node nodeLead = Freelancers.Where(p => p.PersonId == project.TeamLeadId).First();
                foreach (var task in Tasks)
                {
                    if (task.ProjectId == project.Idproject)
                    {
                        Node node = task;
                        foreach (var freelancer in Freelancers)
                        {
                            if (freelancer.PersonId == task.ExecutorId)
                            {
                                
                                node.Children.Add(freelancer);
                            }

                        }
                        nodeProject.Children.Add(node);
                    }
                }

                nodes.Add(nodeProject);
                if (nodeLead!=null)
                    nodeProject.Children.Add(nodeLead);
               
            }

            var array = new int[]{ 34,2,1,65}.ToList();
            array.Sort();

            Node temp = new MVVM.Node();
            temp.Text = "Projects";
            temp.IsExpanded = true;
            foreach (var node in nodes)
                temp.Children.Add(node);

            var tempList = new AsyncObservableCollection<MVVM.Node>();
            tempList.Add(temp);
            return tempList;
        }

        public ObservableCollection<Node> FillCostumers()
        {
            var comm = new Command(DatabaseManager.Instance.Connection);
            var nodes = new ObservableCollection<Node>();

            //var Freelancers = DatabaseLoader.ComputeFreelansers(comm).ToList();
            var Costumers = DatabaseLoader.ComputeCostumers(comm).ToList();
            //var Tasks = DatabaseLoader.ComputeTasks(comm).ToList();
            var Projects = DatabaseLoader.ComputeProjects(comm).ToList();

            foreach (var costumer in Costumers)
            {
                Node parentNode = costumer;

                foreach (var project in Projects)
                {
                    if (project.Idproject == costumer.PersonId)
                    {
                        Node childNode = project;
                        parentNode.Children.Add(project);
                    }
                }
                nodes.Add(parentNode);

            }


            Node temp = new MVVM.Node();
            temp.Text = "Costumers";
            temp.IsExpanded = true;
            foreach (var node in nodes)
                temp.Children.Add(node);

            var tempList = new AsyncObservableCollection<MVVM.Node>();
            tempList.Add(temp);
            return tempList;
        }


        public ObservableCollection<Node> FillFreelancer()
        {
            var comm = new Command(DatabaseManager.Instance.Connection);
            var nodes = new ObservableCollection<Node>();

            var Freelancers = DatabaseLoader.ComputeFreelansers(comm).ToList();
            //var Costumers = DatabaseLoader.ComputeCostumers(comm).ToList();
            var Tasks = DatabaseLoader.ComputeTasks(comm).ToList();
            //var Projects = DatabaseLoader.ComputeProjects(comm).ToList();

            foreach (var freelancer in Freelancers)
            {
                Node parentNode = freelancer;

                foreach (var task in Tasks)
                {
                    if (task.Id == freelancer.PersonId)
                    {
                        Node childNode = task;
                        parentNode.Children.Add(task);
                    }
                }
                nodes.Add(parentNode);

            }

            Node temp = new MVVM.Node();
            temp.Text = "Freelancers";
            temp.IsExpanded = true;
            foreach (var node in nodes)
                temp.Children.Add(node);

            var tempList = new ObservableCollection<MVVM.Node>();
            tempList.Add(temp);
            return tempList;
        }

        #endregion


        #region OnClick

        public void OnDeleteClick()
        {
           // var target = null;
            //if ()
        }

        public void OnInsertClick()
        {

        }
        

        #endregion

        #region Tabs handle

        public void OnAddTabItemClick()
        {

            /* Command comm = new Database.Command(DatabaseManager.Instance.Connection);

             comm.CreateTableCostumer();
             comm.CreateTableFreelancer();
             comm.CreateTableTask();
             comm.CreateProjects();
             var costumer = new OrdersManager.Model.Costumer();
             costumer.FIO = "dfgdfgdfgdfgdfg";
             costumer.PhotoName = "bvnvbnvbnvbnvbnvbn";
             costumer.Adress = "adress";
             comm.InsertCostumer(costumer);

             DatabaseManager.Instance.Close();*/

            List<string> tabHeaders = new List<string>();
            foreach (var tab in TabsStartCollections)
                tabHeaders.Add((string)((TabItem)tab).Header);
            Views.TabTypeSelect window = new Views.TabTypeSelect(tabHeaders);
            window.ShowDialog();
        }

        private void FillTabs()
        {
            List<TabItem> TabsStart = ToTabsList(this.Tabs);
            TabsStartCollections = TabsStart.ToArray();
        }

        private List<TabItem> ToTabsList(ItemCollection tabs)
        {
            List<TabItem> TabsStart = tabs.OfType<TabItem>().ToList<TabItem>();
            TabsStart.RemoveAt(TabsStart.Count - 1);
            return TabsStart;
        }

        /// <summary>
        /// AddTab
        /// </summary>
        /// <param name="Index"> индекс вкладки</param>
        public void AddTab(int Index)
        {
            TabItem cachedTab = new TabItem();
            cachedTab.Content = (TabsStartCollections[Index]).Content;
            cachedTab.Header = (TabsStartCollections[Index]).Header;
            Tabs.Insert(Tabs.Count - 1,cachedTab);
        }

        public void GoToTab(string typeName)
        {
            var tabs = ToTabsList(Tabs);
            var res = tabs.FirstOrDefault<TabItem>(
                p => p.GetType().ToString()== typeName && p.TabIndex <= Tabs.CurrentPosition);
            if (res!=null)
            {
                Tabs.MoveCurrentTo(res);
            }
        }
        #endregion
    }
}
