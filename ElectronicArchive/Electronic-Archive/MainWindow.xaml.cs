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

// Добавленные using.
using System.Data.SqlClient;
using System.Data;
using Electronic_Archive.DataBase;

namespace Electronic_Archive
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод входа в аккаунт.
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            // Проверка заполненности полей.
            if (IsAllTextBoxesFilled())
            {
                // Проверка данных.
                var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.Логин == LoginBox.Text && u.Пароль == PasswordBox.Text);

                if (CurrentUser != null)
                {
                    // Переход в основное меню.
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Проверка на заполненность всех TextBox.
        private bool IsAllTextBoxesFilled()
        {
            foreach (var element in grid.Children)
            {
                if (element is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Вызывается команда, связанная с кнопкой "Войти"
                Enter_Click(sender, e);
            }
        }
    }
}
