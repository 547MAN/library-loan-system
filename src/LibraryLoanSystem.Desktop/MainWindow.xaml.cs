using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace LibraryLoanSystem.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Opens the link in the users default browser.
    private void CompanyLink_RequestNavigate(
        object sender,
        RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = e.Uri.AbsoluteUri,
            UseShellExecute = true
        });
    }

    //Opens new window, and closes old one. 
    //In this case, open Library window and closes Main window (used as login window)
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var libraryWindow = new LibraryWindow();
        
        libraryWindow.Show();

        Close();
    }
}

