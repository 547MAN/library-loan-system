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

        private readonly string[] books =
        {
            "The Hobbit",
            "Hobbits did nothing wrong",
            "The Hobbits are guilty",
            "Hobbits are special",
            "Hobbits are ordinary",
            "End of Hobbit Debate",
            "19",
            "1984",
            "Pride and Prejudice",
            "To Kill a Mockingbird",
            "The Great Gatsby"
        };
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();

            loginWindow.Show();
            
            Close();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
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

            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                PerformSearch();
            }
        }

        private void PerformSearch()
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

            // Search for term, store up to 5 matching results in an array, then display them on separate lines.
            string[] matchingBooks = books
                .Where(book => book.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Take(5)
                .ToArray();

            if (matchingBooks.Length > 0)
            {
                SearchResultTextBlock.Text = string.Join(Environment.NewLine, matchingBooks);
            }
            else
            {
                SearchResultTextBlock.Text = "No Matching books found.";
            }
        }
    }
}

