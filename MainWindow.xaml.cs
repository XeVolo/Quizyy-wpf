﻿using Quizyy.Controller;
using Quizyy_wpf.Controller;
using Quizyy_wpf.View;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quizyy;

namespace Quizyy_wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string welcomeText1 = "Witaj w Quizyy\n" +
			"Wybierz tryb gry z którym chciałbyś się zmierzyć\n";
        private string introText1 = "Szybkie wprowadzenie:\n" +
            "Quizyy to prosta gra edukacyjna w której zmierzysz się z quizami w różnej formie \n" +
            "Fiszki to wyświetlane pojęcie i ukryta definicja\n" +
            "Dopasowanie pojęć polega na połączeniu w pary pasujących do siebie opcji\n" +
            "Podanie odpowiedzi polega na ręcznym wpisaniu odpowiedzi do zadanego pytania\n" +
            "Wybór odpowiedzi polega na wybraniu jednej poprawnej odpowiedzi spośród podanych\n";
		public MainWindow()
		{
            Program.CloseConsole();
			InitializeComponent();
			GenerateButtons();
		}
        

		public void GenerateButtons()
		{
            backButton.Visibility = Visibility.Collapsed;
            string[] buttonLabels = { "Fiszki", "Dopasowanie pojęć", "Podanie odpowiedzi", "Wybór odpowiedzi" };

			StackPanel buttonPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center,
				Margin = new Thickness(0, 0, 0, 0)
			};

			for (int i = 0; i < buttonLabels.Length; i++)
			{
                Button button = new Button
                {
                    Content = buttonLabels[i],
                    Margin = new Thickness(10),
                    Width = 180,
                    Height = 30,                  
                    Style = (Style)FindResource("CustomButtonStyle"),
                    
                    
                    
                };
                switch (i)
				{
					case 0:                    
                        button.Click += FlashCards;	
                        break;
					case 1:
						button.Click += Fit;                     
                        break;
					case 2:
						button.Click += Write;                       
                        break;
					case 3:
						button.Click += Choose;                   
                        break;
				}

				 buttonPanel.Children.Add(button);
			}
			Button cons = new Button
			{
				Content = "Konsola",
				Margin = new Thickness(700,500,0,0),
				Width = 180,
				Height = 30,
				Style = (Style)FindResource("CustomButtonStyle"),

			};
			cons.Click += ConsoleOpen;

			MainGrid.Children.Add(buttonPanel);
			MainGrid.Children.Add(cons);
			welcomeText.Text = welcomeText1;
            introText.Text = introText1;
			welcomeText.Visibility = Visibility.Visible;
			introText.Visibility = Visibility.Visible;
		}
        private void ConsoleOpen(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.MainWindow.Hide();
                Program.OpenConsole();
                MainController builder = new MainController();
                Program.CloseConsole();
                Application.Current.MainWindow.Show();
                GenerateButtons();
            }catch (Exception ex)
            {

            }

		}
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = null;
            MainGrid.Children.Clear();
			GenerateButtons();

        }
        private void FlashCards(object sender, RoutedEventArgs e)
        {
			welcomeText.Visibility = Visibility.Collapsed;
			introText.Visibility = Visibility.Collapsed;
			MainGrid.Children.Clear();
            contentControl.Content = new FlashCardsView(this); 
        }
        private void Choose(object sender, RoutedEventArgs e)
        {
			welcomeText.Visibility = Visibility.Collapsed;
			introText.Visibility = Visibility.Collapsed;
			MainGrid.Children.Clear();
            contentControl.Content = new ChooseView(this);
        }
        private void Fit(object sender, RoutedEventArgs e)
        {
			welcomeText.Visibility = Visibility.Collapsed;
			introText.Visibility = Visibility.Collapsed;
			MainGrid.Children.Clear();
            contentControl.Content = new FitView(this);
        }
        private void Write(object sender, RoutedEventArgs e)
        {
			welcomeText.Visibility = Visibility.Collapsed;
			introText.Visibility = Visibility.Collapsed;
			MainGrid.Children.Clear();
            contentControl.Content = new WriteView(this);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Q)
            {
                MainGrid.Children.Clear();
                contentControl.Content = new EasterEggView(this);
            }
            else if (e.Key == Key.Escape)
            {
                contentControl.Content = null;
                MainGrid.Children.Clear();
                GenerateButtons();
            }
            
        }


    }
}