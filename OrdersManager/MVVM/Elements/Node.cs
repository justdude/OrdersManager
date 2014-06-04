using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections;
using System;

namespace MVVM
{
    public class Node : ViewModelBase
    {
        public Node()
        {
            this.id = Guid.NewGuid().ToString();
        }

        private ObservableCollection<Node> children = new ObservableCollection<Node>();
        private ObservableCollection<Node> parent = new ObservableCollection<Node>();
        private string text;
        private string id;
        private bool isSelected = false;
        private bool isExpanded;

        public ObservableCollection<Node> Children
        {
            get { return this.children; }
        }

        public ObservableCollection<Node> Parent
        {
            get { return this.parent; }
        }

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;
                OnPropertyChanged("Text");
            }
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        public static Node FindSelectedNode(ObservableCollection<Node> nodes)
        {
            Node selectedNode = null;
            foreach (var node in nodes)
            {
                selectedNode = GetSelected(node);
                if (selectedNode != null)
                    return selectedNode;
            }
            return selectedNode;
        }

        private static Node GetSelected(Node baseNode)
        {
            if (baseNode == null) return null;
            if (baseNode.isSelected )
                return baseNode;

            if (baseNode.Children!=null)
                foreach (Node node in baseNode.Children)
                {
                    if (node != null && node.IsSelected)
                        return node;
                    if (node.Children != null)
                        return Node.GetSelected(node);
                }
            return null;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }*/

    }//class Node

}
