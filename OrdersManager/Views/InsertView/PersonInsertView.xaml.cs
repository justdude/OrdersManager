﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Elysium;
namespace OrdersManager.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonInsertView.xaml
    /// </summary>
    public partial class PersonInsertView : Elysium.Controls.Window
    {
        public static PersonInsertView Instance
        { get; private set; }
        public PersonInsertView()
        {
            Instance = this;
            InitializeComponent();
        }
    }
}
