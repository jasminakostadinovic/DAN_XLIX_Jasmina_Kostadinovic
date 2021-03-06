﻿using Hotel_Management_App.Model;
using Hotel_Management_App.ViewModel.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management_App.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView(tblManager manager)
        {
            InitializeComponent();
            this.DataContext = new ManagerViewModel(this, manager);
        }
    }
}
