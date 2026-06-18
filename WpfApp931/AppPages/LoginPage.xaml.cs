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
using WpfApp931.Models;

namespace WpfApp931.AppPages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var loginObj = ConnectionClass.test931Entities.Users
                .Where(x => x.Login == TbLogin.Text && x.Password == TbPassword.Password)
                .FirstOrDefault();
            if (loginObj == null) 
            {
                MessageBox.Show("Неверный логин или пароль", "Пользователь не найден",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CurrentUser.currentUser = loginObj;

            switch (loginObj.RoleId)
            {
                case 1:
                    NavigationService.Navigate(new AdminPage(loginObj));
                    break;
                case 2:
                    NavigationService.Navigate(new UserPage(loginObj));
                    break;
                default:
                    NavigationService.Navigate(new UserPage(loginObj));
                    break;
            }
        }
    }
}
