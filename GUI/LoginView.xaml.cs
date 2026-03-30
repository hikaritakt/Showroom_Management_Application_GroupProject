using ShowroomApp.Services;
using System;
using System.Windows;

namespace ShowroomApp.GUI
{
    public partial class LoginView : Window
    {
        private readonly AccountService _accountService;

        public LoginView()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            try
            {
                bool success = _accountService.Login(username, password);
                if (success)
                {
                    MainView mainView = new MainView();
                    mainView.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
