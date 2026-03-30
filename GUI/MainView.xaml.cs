using ShowroomApp.Services;
using ShowroomApp.Shared;
using System.Windows;

namespace ShowroomApp.GUI
{
    public partial class MainView : Window
    {
        private readonly AccountService _accountService;

        public MainView()
        {
            InitializeComponent();
            _accountService = new AccountService();
            LoadUserContext();
        }

        private void LoadUserContext()
        {
            txtWelcome.Text = $"Welcome, {CurrentUser.Username}\nRole: {CurrentUser.Role}";
            
            // Only Admin can manage employees
            if (CurrentUser.Role != "Admin")
            {
                btnEmployee.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new EmployeeView());
        }

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SupplierView());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            _accountService.Logout();
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}