﻿using System;
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

namespace OrdersManager.ModelView
{
    public class OrdersRootViewModel : ViewModelBase
    {

        public static OrdersRootViewModel Instance
        {
            get;
            private set;
        }

        public ObservableCollection<Node> Nodes 
        { 
            get; 
            private set; 
        }

        private ItemCollection Tabs;

        public TabItem[] TabsStartCollections
        {
            get;
            private set;
        }


        public List<MVVM.MenuItem> MenuOptions
        {
            get  {
                var menu = new List<MVVM.MenuItem>();
                var mi = new MVVM.MenuItem("Add");
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

                menu.Add(new MVVM.MenuItem("Close _All") 
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

        public object SelectedItem
        {
            get
            {
                
                //System.Windows.MessageBox.Show("sad");
                return selectedNode;
            }
            set
            {
                selectedNode = value;
                OnPropertyChanged("SelectedItem");
            }
            /*set
            {
                if (value == null) return;
                selectedNode = value;
                selectedNode.IsSelected = value.IsSelected;
                OnPropertyChanged("IsSelected");
            }*/
        }


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


        private object selectedNode;
        private DelegateCommand onAddTabItemClick;


        public OrdersRootViewModel(ItemCollection tabs)
        {
            Instance = this;
            this.Tabs = tabs;
            FillTabs();

            LoadContent = new DelegateCommand(
                () => 
                {
                    this.SelectedItem = Node.FindSelectedNode(this.Nodes);
                },
                () => { return true; }
                );

            FillNodes();

        }

        private void FillTabs()
        {
            List<TabItem> TabsStart = Tabs.OfType<TabItem>().ToList<TabItem>();
            TabsStart.RemoveAt(TabsStart.Count - 1);
            TabsStartCollections = TabsStart.ToArray();
        }

        private void FillNodes()
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

        public void OnAddTabItemClick()
        {
            List<string> tabHeaders = new List<string>();
            foreach (var tab in TabsStartCollections)
                tabHeaders.Add((string)((TabItem)tab).Header);
            Views.TabTypeSelect window = new Views.TabTypeSelect(tabHeaders);
            window.ShowDialog();
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

    }
}
