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
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Electronic_Archive
{
    /// <summary>
    /// Логика взаимодействия для Annul.xaml
    /// </summary>
    public partial class Annul : Window, INotifyPropertyChanged
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

        public Annul()
        {
            InitializeComponent();

            LoadAnnulData();
        }

        public void LoadAnnulData()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Annul", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<annul> annulList = new List<annul>();

                foreach (DataRow row in dataTable.Rows)
                {
                    annul annulItem = new annul
                    {
                        ID = Convert.ToInt32(row["ID_annul"]),
                        DN = row["ДН"].ToString(),
                        Замены = row["Замены"].ToString(),
                        Комментарий = row["Комментарий"].ToString(),
                        Дата = row["Дата"].ToString(),
                        Карточка = row["Карточка"].ToString(),
                        Копии = row["Копии"].ToString(),
                        Применяемость = row["Применяемость"].ToString(),
                        Изменения = row["Изменения"].ToString()
                    };

                    annulList.Add(annulItem);
                }

                AnnulGrid.ItemsSource = annulList;
            }
        }
        public class annul
        {
            public int ID { get; set; }
            public string DN { get; set; }
            public string Замены { get; set; }
            public string Комментарий { get; set; }
            public string Дата { get; set; }
            public string Карточка { get; set; }
            public string Копии { get; set; }
            public string Применяемость { get; set; }
            public string Изменения { get; set; }
        }

        private void AnnulGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataGridColumn column in AnnulGrid.Columns)
            {
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
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

        private void AnnulBtn_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = DNV.Text;

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Cards WHERE ДН = @DN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DN", inputValue);

                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Значение не найдено!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string _DN;
                    string _YesNo;
                    string _Comment;
                    string _DateA;

                    _DN = Convert.ToString(DNV.Text);
                    _Comment = Convert.ToString(Comment.Text);
                    _DateA = Convert.ToString(DateA.Text);

                    if (YesBox.IsChecked == true)
                    {
                        _YesNo = "Да";

                        using (SqlCommand command1 = new SqlCommand("EXEC AnnulCardWithChange @DN = '" + _DN + "', @YesNo = '" + _YesNo + "', @Comment = '" + _Comment + "', @Date = '" + _DateA + "'", connection))
                        {
                            command1.ExecuteNonQuery();
                        }

                        DNValue.DN_value = _DN;
                        EditingStep2 editingStep2 = new EditingStep2();
                        editingStep2.ShowDialog();

                        CopyAccountingStep2 copyAccountingStep2 = new CopyAccountingStep2();
                        copyAccountingStep2.ShowDialog();

                        ChangesStep2 changesStep2 = new ChangesStep2();
                        changesStep2.ShowDialog();

                        ExploitationStep2 exploitationStep2 = new ExploitationStep2();
                        exploitationStep2.ShowDialog();

                        Comment.Text = "";
                        YesBox.IsChecked = false;

                        LoadAnnulData();
                    }   
                    else
                    {
                        _YesNo = "Нет";

                        using (SqlCommand command1 = new SqlCommand("EXEC AnnulCardWithoutChange @DN = '" + _DN + "', @YesNo = '" + _YesNo + "', @Comment = '" + _Comment + "', @Date = '" + _DateA + "'", connection))
                        {
                            command1.ExecuteNonQuery();
                        }


                        Comment.Text = "";
                        YesBox.IsChecked = false;

                        LoadAnnulData();
                    }
                }
            }
            
        }

        private void YesBox_Checked(object sender, RoutedEventArgs e)
        {
            Comment.Visibility = Visibility.Visible;
            labeltext.Visibility = Visibility.Visible;
        }

        private void YesBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Comment.Visibility = Visibility.Hidden;
            labeltext.Visibility = Visibility.Hidden;
        }

        private void Comment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comment.Text))
                labeltext.Visibility = Visibility.Visible;
            else
                labeltext.Visibility = Visibility.Hidden;
        }

        private void PerformSearch()
        {
            // Удаление нежелательных символов из поискового запроса
            string cleanedQuery = Regex.Replace(SearchQuery, @"[^а-яА-Я0-9]", "");

            // Приведение поискового запроса и значений столбцов к нижнему регистру
            string lowerCaseQuery = cleanedQuery.ToLower();

            // Фильтрация данных в CardsGrid
            foreach (var item in AnnulGrid.Items)
            {
                var row = AnnulGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    var annul = item as annul;
                    if (annul != null && CleanString(annul.DN).ToLower().Contains(lowerCaseQuery))
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
