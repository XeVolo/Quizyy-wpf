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
using Quizyy_wpf.Controller;
using Quizyy_wpf.Model;

namespace Quizyy_wpf.View
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseView.xaml
    /// </summary>
    public partial class ChooseView : UserControl
    {
        private MainWindow mainWindow;
        private StackPanel? stackPanel1;
        private StackPanel? stackPanel2;
        private Button? ansButton1;
        private Button? ansButton2;
        private Button? ansButton3;
        private Button? ansButton4;
        private TextBlock? DisplayTextBlock;
        private List<WriteModel> items = BaseController.GetWriteList();
        private int index = 0;
        private ChooseController controller=new ChooseController();

        public ChooseView(MainWindow mainView)
        {
            InitializeComponent();
            mainWindow = mainView;
            OpenMode();
        }
        public void OpenMode()
        {
            mainWindow.backButton.Visibility = Visibility.Visible;
            NewSet();
        }
        private void NewSet()
        {
            List<string> anslist = new List<string>();
            index = controller.GetRandom();
            anslist.Add(items[index].answer);
            anslist.Add(items[index].incorrectans1);
            anslist.Add(items[index].incorrectans2);
            anslist.Add(items[index].incorrectans3);
            List<int> drawn = controller.GetNumbers();
            stackPanel1 = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 100, 0, 0)
            };
            stackPanel2 = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 100, 0, 0)
            };
            ansButton1 = new Button
            {
                Content = anslist[drawn[0]],
                Margin = new Thickness(300, 10, 0, 0),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            ansButton1.Click += AnsButtonClick;
            ansButton2 = new Button
            {
                Content = anslist[drawn[1]],
                Margin = new Thickness(300, 10, 0, 0),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            ansButton2.Click += AnsButtonClick;
            ansButton3 = new Button
            {
                Content = anslist[drawn[2]],
                Margin = new Thickness(0, 10, 300, 0),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            ansButton3.Click += AnsButtonClick;
            ansButton4 = new Button
            {
                Content = anslist[drawn[3]],
                Margin = new Thickness(0, 10, 300, 0),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            ansButton4.Click += AnsButtonClick;
            stackPanel1.Children.Add(ansButton1);
            stackPanel1.Children.Add(ansButton2);
            stackPanel2.Children.Add(ansButton3);
            stackPanel2.Children.Add(ansButton4);
            MainGrid.Children.Add(stackPanel1);
            MainGrid.Children.Add(stackPanel2);
            DisplayTextBlock = new TextBlock
            {

                Margin = new Thickness(0, 10, 0, 100),
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 30,
                Style = (Style)FindResource("CustomTextStyle")
            };
            MainGrid.Children.Add(DisplayTextBlock);
            DisplayQuestion();
        }       
        private void AnsButtonClick(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string ans = clickedButton.Content.ToString();
                bool correctness = controller.AnsButtonClick(ans, index);
                if (correctness)
                {

                    MessageBox.Show("Odpowiedź prawidłowa");
                    DisplayTextBlock.Text = "";
                    NewSet();
                }
                else
                {
                    MessageBox.Show("Odpowiedź błędna");
                }

            }
        }
        private void DisplayQuestion()
        {
            DisplayTextBlock.Text = controller.DisplayQuestion(index);
        }
    }
}
