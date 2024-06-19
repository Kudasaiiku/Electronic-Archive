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

namespace Electronic_Archive
{
    /// <summary>
    /// Логика взаимодействия для CopyAccountingStep2.xaml
    /// </summary>
    public partial class CopyAccountingStep2 : Window
    {

        public CopyAccountingStep2()
        {
            InitializeComponent();

            LoadCopiesData();

            Trash.IsEnabled = false;
        }

        private void CopiesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataGridColumn column in CopiesGrid.Columns)
            {
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
        }

        List<copies> copiesList = new List<copies>();

        public void LoadCopiesData()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Copies WHERE ДН ='" + DNValue.DN_value + "'", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                copiesList = new List<copies>();

                foreach (DataRow row in dataTable.Rows)
                {
                    copies copiesItem = new copies
                    {
                        ID = Convert.ToInt32(row["ID_copies"]),
                        DN = row["ДН"].ToString(),
                        Дата = row["Дата"].ToString(),
                        Наряд = row["Наряд"].ToString(),
                        Абонент = row["Абонент"].ToString(),
                        Поступило = row["Поступило"].ToString(),
                        Списано = row["Списано"].ToString()
                    };

                    copiesList.Add(copiesItem);
                }

                CopiesGrid.ItemsSource = copiesList;
            }
        }

        public class copies
        {
            public int ID { get; set; }
            public string DN { get; set; }
            public string Дата { get; set; }
            public string Наряд { get; set; }
            public string Абонент { get; set; }
            public string Поступило { get; set; }
            public string Списано { get; set; }

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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string _DN = DNValue.DN_value;

            string _Date;
            string _Base;
            string _Abonent;
            string _In;
            string _Out;

            _Date = Convert.ToString(Date.Text);
            _Base = Convert.ToString(Base.Text);
            _Abonent = Convert.ToString(Abonent.Text);
            _In = Convert.ToString(In.Text);
            _Out = Convert.ToString(Out.Text);

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Copies (ДН, Дата, Наряд, Абонент, Поступило, Списано) VALUES('" + _DN + "', '" + _Date + "', '" + _Base + "', '" + _Abonent + "', '" + _In + "', '" + _Out + "')", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            Date.Text = "";
            Base.Text = "";
            Abonent.Text = "";
            In.Text = "";
            Out.Text = "";

            LoadCopiesData();
        }


        int _id;
        string _dn;

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
                    string query = "DELETE FROM Copies WHERE ДН = @DN and ID_copies = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DN", _dn);
                        command.Parameters.AddWithValue("@ID", _id);
                        command.ExecuteNonQuery();
                    }
                }

                LoadCopiesData();
            }
            else if (result == false)
            {
                // Действия при выборе "Нет"
                warning2.Close(); // Закрытие пользовательского окна сообщения
            }
        }

        private void CopiesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CopiesGrid.SelectedItem != null)
            {
                copies selectedCard = (copies)CopiesGrid.SelectedItem;
                _dn = selectedCard.DN;
                _id = selectedCard.ID;
                Trash.IsEnabled = true;
            }
            else
            {
                Trash.IsEnabled = false; // Отключение кнопки Trash, если строка не выделена
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search.Text))
                SearchLabel.Visibility = Visibility.Visible;
            else
                SearchLabel.Visibility = Visibility.Hidden;

            FilterDataGrid(Search.Text);
        }

        private void FilterDataGrid(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                CopiesGrid.ItemsSource = copiesList;
                return;
            }

            string[] searchTerms = searchValue.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<copies> filteredData = copiesList;

            foreach (string term in searchTerms)
            {
                filteredData = filteredData.Where(c =>
                    c.Дата.Contains(term) ||
                    c.Наряд.Contains(term) ||
                    c.Абонент.Contains(term)
                );
            }

            CopiesGrid.ItemsSource = filteredData;
        }
    }
}
