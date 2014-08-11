using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace wpf_test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ColorViewModel cvm = new ColorViewModel(this);
            this.DataContext = cvm;
        }
        
    }
}
