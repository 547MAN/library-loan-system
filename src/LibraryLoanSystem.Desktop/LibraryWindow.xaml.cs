using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryLoanSystem.Desktop
{
    /// <summary>
    /// Interaction logic for LibraryWindow.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        public LibraryWindow()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();

            loginWindow.Show();
            
            Close();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchResultTextBlock.Text = "Please enter a search term. \n For example 'The Hobbit'";
                SearchTextBox.Clear();
                SearchTextBox.Focus();
                return;
            }
            SearchResultTextBlock.Text = $"You searched for: {SearchTextBox.Text}";
        }
    }  
}

