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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quizyy_wpf.Controller;
using Quizyy_wpf.Model;

namespace Quizyy_wpf.View
{
    /// <summary>
    /// Logika interakcji dla klasy FlashCardsView.xaml
    /// </summary>
    public partial class FlashCardsView : UserControl
    {
        private MainWindow mainWindow;
        private StackPanel? stackPanel;
        private Button? previousButton;
        private Button? nextButton;
        private Button? contextButton;
        private TextBlock? DisplayTextBlock;
        private FlashCardsController controller= new FlashCardsController();
        public FlashCardsView(MainWindow mainView)
        {
            mainWindow = mainView;
            InitializeComponent();

            OpenMode();
        }
        public void OpenMode()
        {
            mainWindow.backButton.Visibility = Visibility.Visible;     
            NewSet();
        }
        private void NewSet()
        {
            stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };

            previousButton = new Button
            {
                Content = "Poprzedni",
                Margin = new Thickness(100),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            previousButton.Click += PreviousButtonClick;

            nextButton = new Button
            {
                Content = "Następny",
                Margin = new Thickness(100),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            nextButton.Click += NextButtonClick;
            contextButton = new Button
            {
                Content = "Tłumaczenie",
                Margin = new Thickness(0, 150, 0, 0),
                Width = 180,
                Height = 30,
                Style = (Style)FindResource("CustomButtonStyle")
            };
            contextButton.Click += ContextButtonClick;

            stackPanel.Children.Add(previousButton);

            stackPanel.Children.Add(contextButton);

            stackPanel.Children.Add(nextButton);

            DisplayTextBlock = new TextBlock
            {
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 30,
                Style = (Style)FindResource("CustomTextStyle")
            };

            Grid.SetRow(stackPanel, 0);
            Grid.SetRow(DisplayTextBlock, 1);

            mainWindow.MainGrid.Children.Add(stackPanel);
            mainWindow.MainGrid.Children.Add(DisplayTextBlock);
			DisplayTextBlock.Text = controller.DisplayCurrentItem();
		}

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            controller.PreviousButtonClick();
			DisplayTextBlock.Text = controller.DisplayCurrentItem();
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
			controller.NextButtonClick();
			DisplayTextBlock.Text = controller.DisplayCurrentItem();
		}
        private void ContextButtonClick(object sender, RoutedEventArgs e)
        {
			DisplayTextBlock.Text = controller.ContextButtonClick();
		}

        
    }
}

