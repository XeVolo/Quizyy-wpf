﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quizyy_wpf.View
{
    /// <summary>
    /// Logika interakcji dla klasy EasterEggView.xaml
    /// </summary>
    public partial class EasterEggView : UserControl
    {
        private MainWindow mainWindow;
        public EasterEggView(MainWindow mainView)
        {
            InitializeComponent();
            mainWindow = mainView;
            OpenMode();
        }
        private void OpenMode()
        {
            mainWindow.backButton.Visibility = Visibility.Visible;
        }
    }
}
