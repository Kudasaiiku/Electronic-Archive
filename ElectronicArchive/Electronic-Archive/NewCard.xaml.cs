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
using System.Windows.Shapes;

// Добавленные using.
using System.Data.SqlClient;
using System.Data;
using Electronic_Archive.DataBase;
using System.IO;
using System.Text.RegularExpressions;


using Microsoft.Win32;

namespace Electronic_Archive
{
    public partial class NewCard : Window
    {

        public NewCard()
        {
            InitializeComponent();

        }

        // Путь для файла.
        string filePath;

        // Добавление новой записи в таблицу Cards.
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsAllTextBoxesFilled())
            {
                CreateCard();
            }
            else
            {
                var warning = new Warning();
                bool? result = warning.ShowDialog();

                if (result == true)
                {
                    CreateCard();
                }
                else if (result == false)
                {
                    // Действия при выборе "Нет"
                    warning.Close(); // Закрытие пользовательского окна сообщения
                }
            }
           
        }
        

        // Выбор файла для загрузки.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Получаем путь выбранного файла
                filePath = openFileDialog.FileName;

                // Получаем название файла
                string fileName = System.IO.Path.GetFileName(filePath);

                // Загружаем название файла в TextBlock
                fileNameTextBlock.Text = fileName;
                fileNameTextBlock.Visibility = Visibility.Visible;
            }
        }

        public void CreateCard()
        {
                Cards new_card = new Cards();
                new_card.ДН = DN.Text;

                string cardInput = DN.Text;
                var query = from r in AppData.db.Cards
                            where r.ДН == cardInput
                            select r;
                if (query.Any())
                {
                    MessageBox.Show("Такой децимальный номер уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string _DN;
                    string _Name;
                    string _TypeOfDocument;
                    string _Number;
                    string _Count;
                    string _A0;
                    string _A1;
                    string _A2;
                    string _A3;
                    string _A4;
                    string _Other;
                    string _Sign;
                    string _NumberOfDecision;
                    string _Litera;
                    string _Original;
                    string _InvOriginal;
                    string _DateOriginal;
                    string _Dublicate;
                    string _InvDublicate;
                    string _DateDublicate;

                    _DN = Convert.ToString(DN.Text);
                    _Name = Convert.ToString(Name.Text);
                    _TypeOfDocument = Convert.ToString(TypeOfDocument.Text);
                    _Number = Convert.ToString(Number.Text);
                    _Count = Convert.ToString(Count.Text);
                    _A0 = Convert.ToString(A0.Text);
                    _A1 = Convert.ToString(A1.Text);
                    _A2 = Convert.ToString(A2.Text);
                    _A3 = Convert.ToString(A3.Text);
                    _A4 = Convert.ToString(A4.Text);
                    _Other = Convert.ToString(Other.Text);
                    if (SignBox.IsChecked == true)
                        _Sign = "Да";
                    else
                        _Sign = "Нет";
                    _NumberOfDecision = Convert.ToString(NumberOfDecision.Text);
                    _Litera = Convert.ToString(Litera.Text);
                    if (OriginalBox.IsChecked == true)
                        _Original = "Да";
                    else
                        _Original = "Нет";
                    _InvOriginal = Convert.ToString(OInvBox.Text);
                    _DateOriginal = Convert.ToString(ODateBox.Text);
                    if (DublicateBox.IsChecked == true)
                        _Dublicate = "Да";
                    else
                        _Dublicate = "Нет";
                    _InvDublicate = Convert.ToString(DInvBox.Text);
                    _DateDublicate = Convert.ToString(DDateBox.Text);

                    using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("INSERT INTO Cards (ДН, Название, Подразделение, Вид_документа, Знак_заказчика, Номер_решения, A0, A1, A2, A3, A4, Другое, Количество, Подлинник, Дубликат, ИН_подлинник, ИН_дубликат, Дата_подлинник, Дата_дубликат, Литера)" +
                            "VALUES ('" + _DN + "', '" + _Name + "', '" + _Number + "', '" + _TypeOfDocument + "', '" + _Sign + "', '" + _NumberOfDecision + "', '" + _A0 + "', '" + _A1 + "', '" + _A2 + "', '" + _A3 + "', '" + _A4 + "', '" + _Other + "', '" + _Count + "', '" + _Original + "', '" + _Dublicate + "', '" + _InvOriginal + "', '" + _InvDublicate + "', '" + _DateOriginal + "', '" + _DateDublicate + "', '" + _Litera + "')", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    // Копирование файла в папку LoadedFiles.
                    if (!string.IsNullOrEmpty(fileNameTextBlock.Text))
                    {
                        // Получаем путь к выбранному файлу
                        string sourceFilePath = filePath;

                        string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                        string targetFolderPath = System.IO.Path.Combine(appFolderPath, "LoadedFiles");

                        // Создаем папку "LoadedFiles", если она еще не существует
                        if (!Directory.Exists(targetFolderPath))
                        {
                            Directory.CreateDirectory(targetFolderPath);
                        }

                        // Генерируем новый путь для скопированного файла
                        string targetFilePath = System.IO.Path.Combine(targetFolderPath, System.IO.Path.GetFileName(sourceFilePath));

                        // Копируем файл в целевую папку
                        File.Copy(sourceFilePath, targetFilePath, true);

                        // Опционально: обновляем текстовое поле для отображения нового пути
                        fileNameTextBlock.Text = targetFilePath;
                    }

                    this.Close();
                
            }
        }













        

        // Скрытие и показ новых textBox по нажатии на галочку.
        private void OriginalBox_Checked(object sender, RoutedEventArgs e)
        {
                OInv.Visibility = Visibility.Visible;
                OInvBox.Visibility = Visibility.Visible;
                ODate.Visibility = Visibility.Visible;
                ODateBox.Visibility = Visibility.Visible;
        }

        private void OriginalBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OInv.Visibility = Visibility.Hidden;
            OInvBox.Visibility = Visibility.Hidden;
            ODate.Visibility = Visibility.Hidden;
            ODateBox.Visibility = Visibility.Hidden;

        }

        // Скрытие и показ новых textBox по нажатии на галочку.
        private void DublicateBox_Checked(object sender, RoutedEventArgs e)
        {
                DInv.Visibility = Visibility.Visible;
                DInvBox.Visibility = Visibility.Visible;
                DDate.Visibility = Visibility.Visible;
                DDateBox.Visibility = Visibility.Visible;
            
        }

        private void DublicateBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DInv.Visibility = Visibility.Hidden;
            DInvBox.Visibility = Visibility.Hidden;
            DDate.Visibility = Visibility.Hidden;
            DDateBox.Visibility = Visibility.Hidden;

        }

        // Регулярное выражение для полей цифр.
        Regex inputRegex = new Regex(@"^[0-9]$");
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void A0_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void A1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void A2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void A3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void A4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
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

        private void OInvBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void DInvBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }
    }
}