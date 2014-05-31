using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM;

namespace OrdersManager.MVVM
{
    public class Node: ViewModelBase
    {
        
        public string Key;

        private string visibleText;
        public string VisibleText
        {
            get
            {
                return visibleText;
            }
            set
            {
                visibleText = value;
                OnPropertyChanged("VisibleText");
            }
        }

        private object objectValue;
        private object ObjectValue
        {
            get
            {
                return objectValue;
            }
            set
            {
                objectValue = value;
            }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public object Parent
        { get; set; }
        public object Child
        { get; set; }

        public Node() {  }

        public Node(string visibletext, object value)
        {
            this.VisibleText = visibletext;
            this.ObjectValue = value;
        }

        public Node(string key, string visibletext, object value)
        {
            this.Key = key;
            this.VisibleText = visibletext;
            this.ObjectValue = value;
        }


    }



}
