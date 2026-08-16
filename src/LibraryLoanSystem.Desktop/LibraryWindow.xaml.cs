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
            // Remove leading and trailing whitespace.
            string searchTerm = SearchTextBox.Text.Trim();

            // Reduce repeated spaces to a single space.
            while (searchTerm.Contains("  "))
            {
                searchTerm = searchTerm.Replace("  ", " ");
            }

            SearchResultTextBlock.Text = $"You searched for: {searchTerm}";
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Clear();
            SearchResultTextBlock.Text = string.Empty;
            SearchTextBox.Focus();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchResultTextBlock.Text = string.Empty;

            ClearSearchButton.Visibility = string.IsNullOrEmpty(SearchTextBox.Text)
                ? Visibility.Collapsed : Visibility.Visible;
        }
    }  
}

