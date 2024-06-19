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
using System.IO;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Win32;
using System.Reflection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Electronic_Archive
{
    public partial class MainMenu : Window, INotifyPropertyChanged
    {

        private string searchQuery;
        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                PerformSearch();
            }
        }

        // Загрузка таблицы Cards.
        public MainMenu()
        {
            InitializeComponent();

            DataBaseConnection();

            LoadFileData();

            DataContext = this;

            Trash.IsEnabled = false;
        }

        // Выравнивание таблицы Cards.
        private void CardsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataGridColumn column in CardsGrid.Columns)
            {
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
        }

        // Подключение таблицы Cards.
        public void DataBaseConnection()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Cards", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Card> cardList = new List<Card>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Card card = new Card
                    {
                        DN = row["ДН"].ToString(),
                        Название = row["Название"].ToString(),
                        Подразделение = Convert.ToInt32(row["Подразделение"]),
                        Вид_документа = row["Вид_документа"].ToString(),
                        Знак_заказчика = row["Знак_заказчика"].ToString(),
                        Номер_решения = row["Номер_решения"].ToString(),
                        A0 = Convert.ToInt32(row["A0"]),
                        A1 = Convert.ToInt32(row["A1"]),
                        A2 = Convert.ToInt32(row["A2"]),
                        A3 = Convert.ToInt32(row["A3"]),
                        A4 = Convert.ToInt32(row["A4"]),
                        Другое = row["Другое"].ToString(),
                        Количество = Convert.ToInt32(row["Количество"]),
                        Подлинник = row["Подлинник"].ToString(),
                        Дубликат = row["Дубликат"].ToString(),
                        ИН_подлинник = Convert.ToInt32(row["ИН_подлинник"]),
                        ИН_дубликат = Convert.ToInt32(row["ИН_дубликат"]),
                        Дата_подлинник = row["Дата_подлинник"].ToString(),
                        Дата_дубликат = row["Дата_дубликат"].ToString(),
                        Литера = row["Литера"].ToString()
                    };

                    cardList.Add(card);
                }

                CardsGrid.ItemsSource = cardList;
            }
        }

        // Создание новой карточки.
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            NewCard newCard = new NewCard();
            newCard.ShowDialog();

            DataBaseConnection();

            CardsGrid_Loaded(sender, e);

            LoadFileData();
        }

        // Загрузка файла в FilesGrid.
        private void LoadFileData()
        {
            // Получаем путь к папке LoadedFiles
            string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            string targetFolderPath = System.IO.Path.Combine(appFolderPath, "LoadedFiles");

            // Получаем пути всех файлов в папке LoadedFiles
            string[] filePaths = Directory.GetFiles(targetFolderPath);

            // Создаем коллекцию объектов для хранения данных файлов
            List<FileData> fileDataList = new List<FileData>();

            // Для каждого файла получаем его имя и время создания
            foreach (string filePath in filePaths)
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                DateTime creationTime = File.GetCreationTime(filePath);

                // Создаем объект FileData и добавляем его в коллекцию
                fileDataList.Add(new FileData(fileName, creationTime, filePath));
            }

            // Устанавливаем коллекцию fileDataList в качестве источника данных для DataGrid
            FilesGrid.ItemsSource = fileDataList;
        }

        public class FileData
        {
            public string FileName { get; set; }
            public DateTime CreationTime { get; set; }
            public string FilePath { get; set; }

            public FileData(string fileName, DateTime creationTime, string filePath)
            {
                FileName = fileName;
                CreationTime = creationTime;
                FilePath = filePath;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditingStep1 editingStep1 = new EditingStep1();
            editingStep1.ShowDialog();

            DataBaseConnection();

            CardsGrid_Loaded(sender, e);

            LoadFileData();
        }

        private void FilesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что двойной щелчок был на строке, а не на заголовке
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem != null)
            {
                // Получаем выбранную модель данных
                var selectedFile = dataGrid.SelectedItem as FileData;

                // Получаем путь к файлу
                string filePath = selectedFile.FilePath;

                // Проверяем, что путь к файлу не пустой и файл существует
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    // Открываем файл с помощью соответствующего приложения
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("Файл не существует или путь к файлу недействителен.");
                }
            }
        }

        private void Copies_Click(object sender, RoutedEventArgs e)
        {
            CopyAccountingStep1 copyingStep1 = new CopyAccountingStep1();
            copyingStep1.ShowDialog();
        }

        private void Changes_Click(object sender, RoutedEventArgs e)
        {
            ChangesStep1 changesStep1 = new ChangesStep1();
            changesStep1.ShowDialog();
        }

        private void Exploitation_Click(object sender, RoutedEventArgs e)
        {
            ExploitationStep1 exploitationStep1 = new ExploitationStep1();
            exploitationStep1.ShowDialog();
        }

        private void Annul_Click(object sender, RoutedEventArgs e)
        {
            Annul annul = new Annul();
            annul.ShowDialog();

            DataBaseConnection();

            CardsGrid_Loaded(sender, e);
        }

        public class Card
        {
            public string DN { get; set; }
            public string Название { get; set; }
            public int Подразделение { get; set; }
            public string Вид_документа { get; set; }
            public string Знак_заказчика { get; set; }
            public string Номер_решения { get; set; }
            public int A0 { get; set; }
            public int A1 { get; set; }
            public int A2 { get; set; }
            public int A3 { get; set; }
            public int A4 { get; set; }
            public string Другое { get; set; }
            public int Количество { get; set; }
            public string Подлинник { get; set; }
            public string Дубликат { get; set; }
            public int ИН_подлинник { get; set; }
            public int ИН_дубликат { get; set; }
            public string Дата_подлинник { get; set; }
            public string Дата_дубликат { get; set; }
            public string Литера { get; set; }
        }

        private void CardsGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            // Проверяем, что двойной щелчок был на строке, а не на заголовке
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem != null)
            {
                // Получаем выбранную модель данных
                var selectedCard = dataGrid.SelectedItem as Card;

                // Получаем значение ДН
                string dn = selectedCard.DN;

                // Устанавливаем контекст лицензирования для библиотеки OfficeOpenXml
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Загружаем шаблон Excel-файла
                string templateFilePath = "C:\\Users\\deadi\\OneDrive\\Рабочий стол\\ElectronicArchive\\Electronic-Archive\\bin\\Debug\\Шаблон карточки.xlsx";
                FileInfo templateFile = new FileInfo(templateFilePath);

                using (var package = new ExcelPackage(templateFile))
                {
                    // Получаем лист с данными
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Лист1"];

                    // Получаем данные из таблицы Cards
                    using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                    {
                        connection.Open();

                        // Запрос для таблицы Cards
                        string cardsQuery = "SELECT * FROM Cards WHERE ДН = @DN";

                        using (SqlCommand command = new SqlCommand(cardsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DN", dn);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Вставляем данные в указанные ячейки Excel-файла
                                    worksheet.Cells["Z2"].Value = reader["ДН"];
                                    worksheet.Cells["H2"].Value = reader["Название"];
                                    worksheet.Cells["D5"].Value = reader["Подразделение"];
                                    worksheet.Cells["N5"].Value = reader["Вид_документа"];
                                    worksheet.Cells["A2"].Value = reader["Знак_заказчика"];
                                    worksheet.Cells["G1"].Value = reader["Номер_решения"];
                                    worksheet.Cells["AC5"].Value = reader["Другое"];
                                    worksheet.Cells["AI8"].Value = reader["Количество"];
                                    worksheet.Cells["AI9"].Value = reader["Количество"];
                                    worksheet.Cells["S5"].Value = reader["Подлинник"];
                                    worksheet.Cells["W5"].Value = reader["Дубликат"];
                                    worksheet.Cells["Y8"].Value = reader["ИН_подлинник"];
                                    worksheet.Cells["Y9"].Value = reader["ИН_дубликат"];
                                    worksheet.Cells["AD8"].Value = reader["Дата_подлинник"];
                                    worksheet.Cells["AD9"].Value = reader["Дата_дубликат"];
                                    worksheet.Cells["AI10"].Value = reader["Литера"];
                                }
                            }
                        }
                    }

                    // Получаем данные из таблицы Exploitation
                    using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                    {
                        connection.Open();

                        // Запрос для таблицы Exploitation
                        string exploitationQuery = "SELECT * FROM Exploitation WHERE ДН = @DN";

                        using (SqlCommand command = new SqlCommand(exploitationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DN", dn);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int rowIndex = 11;
                                int columnN = 14; // Начальная колонка 'N'

                                while (reader.Read() && rowIndex <= 100)
                                {
                                    // Вставляем данные в указанные ячейки Excel-файла
                                    worksheet.Cells[rowIndex, columnN].Value = reader["Обозначение"];

                                    rowIndex++;
                                }
                            }
                        }
                    }

                    // Получаем данные из таблицы Copies
                    using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                    {
                        connection.Open();

                        // Запрос для таблицы Copies
                        string copiesQuery = "SELECT * FROM Copies WHERE ДН = @DN";

                        using (SqlCommand command = new SqlCommand(copiesQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DN", dn);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int rowIndex = 11;

                                while (reader.Read() && rowIndex <= 100)
                                {
                                    // Вставляем данные в указанные ячейки Excel-файла
                                    worksheet.Cells[rowIndex, 1].Value = reader["Дата"];
                                    worksheet.Cells[rowIndex, 4].Value = reader["Наряд"];
                                    worksheet.Cells[rowIndex, 8].Value = reader["Поступило"];
                                    worksheet.Cells[rowIndex, 11].Value = reader["Списано"];

                                    rowIndex++;
                                }
                            }
                        }
                    }

                    // Получаем данные из таблицы Changes
                    using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                    {
                        connection.Open();

                        // Запрос для таблицы Changes
                        string changesQuery = "SELECT * FROM Changes WHERE ДН = @DN";

                        using (SqlCommand command = new SqlCommand(changesQuery, connection))
                        {
                            command.Parameters.AddWithValue("@DN", dn);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int rowIndex = 13;
                                int numeration = 1; // Начальная нумерация

                                while (reader.Read() && rowIndex <= 100)
                                {
                                    // Вставляем данные в указанные ячейки Excel-файла
                                    worksheet.Cells[rowIndex, 20].Value = numeration++;
                                    worksheet.Cells[rowIndex, 21].Value = reader["Номер_извещения"];
                                    worksheet.Cells[rowIndex, 25].Value = reader["Дата"];
                                    worksheet.Cells[rowIndex, 28].Value = reader["Изменения"];
                                    worksheet.Cells[rowIndex, 33].Value = reader["Литера"];

                                    rowIndex++;
                                }
                            }
                        }
                    }

                    // Сохраняем измененный файл
                    var saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo modifiedFile = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(modifiedFile);
                        MessageBox.Show("Excel файл успешно сохранен.");
                    }
                }
            }
        }

        private void CellContextMenu_CopyValue(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem;
            ContextMenu contextMenu = menuItem?.Parent as ContextMenu;
            DataGridCell cell = contextMenu?.PlacementTarget as DataGridCell;

            if (cell != null && cell.Content is TextBlock textBlock)
            {
                string cellValue = textBlock.Text;

                Clipboard.SetText(cellValue); // Копирование значения в буфер обмена
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.ShowDialog();
        }

        private void PerformSearch()
        {
            // Удаление нежелательных символов из поискового запроса
            string cleanedQuery = Regex.Replace(SearchQuery, @"[^а-яА-Я0-9]", "");

            // Приведение поискового запроса и значений столбцов к нижнему регистру
            string lowerCaseQuery = cleanedQuery.ToLower();

            // Фильтрация данных в CardsGrid
            foreach (var item in CardsGrid.Items)
            {
                var row = CardsGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    var card = item as Card;
                    if (card != null && CleanString(card.DN).ToLower().Contains(lowerCaseQuery))
                    {
                        row.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        row.Visibility = Visibility.Collapsed;
                    }
                }
            }

            // Фильтрация данных в FilesGrid
            foreach (var item in FilesGrid.Items)
            {
                var row = FilesGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    var file = item as FileData;
                    if (file != null && CleanString(file.FileName).ToLower().Contains(lowerCaseQuery))
                    {
                        row.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        row.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private string CleanString(string input)
        {
            return Regex.Replace(input, @"[^а-яА-Я0-9]", "");
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search.Text))
                SearchLabel.Visibility = Visibility.Visible;
            else
                SearchLabel.Visibility = Visibility.Hidden;

            SearchQuery = (sender as TextBox).Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _DN;

        private void Trash_Click(object sender, RoutedEventArgs e)
        {
            var warning2 = new Warning2();
            bool? result = warning2.ShowDialog();

            if (result == true)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
                {
                    connection.Open();

                    // Запрос в БД.
                    string query = "DELETE FROM Copies WHERE ДН = @DN; DELETE FROM Cards WHERE ДН = @DN; DELETE FROM Changes WHERE ДН = @DN; DELETE FROM Annul WHERE ДН = @DN; DELETE FROM Exploitation WHERE ДН = @DN;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DN", _DN);
                        command.ExecuteNonQuery();
                    }
                }

                CardsGrid_Loaded(sender, e);
                DataBaseConnection();
            }
            else if (result == false)
            {
                // Действия при выборе "Нет"
                warning2.Close(); // Закрытие пользовательского окна сообщения
            }
        }

        private void CardsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CardsGrid.SelectedItem != null)
            {
                Card selectedCard = (Card)CardsGrid.SelectedItem;
                _DN = selectedCard.DN;
                Trash.IsEnabled = true; // Включение кнопки Trash при выделении строки
            }
            else
            {
                Trash.IsEnabled = false; // Отключение кнопки Trash, если строка не выделена
            }
        }
    }
}

