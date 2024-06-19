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

namespace Electronic_Archive
{
    /// <summary>
    /// Логика взаимодействия для ChangesStep2.xaml
    /// </summary>
    public partial class ChangesStep2 : Window
    {
        public ChangesStep2()
        {
            InitializeComponent();

            LoadChangesData();

            Trash.IsEnabled = false;
        }

        private void ChangesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataGridColumn column in ChangesGrid.Columns)
            {
                column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
            }
        }

        public void LoadChangesData()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Changes WHERE ДН ='" + DNValue.DN_value + "'", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<changes> changesList = new List<changes>();

                foreach (DataRow row in dataTable.Rows)
                {
                    changes changesItem = new changes
                    {
                        ID = Convert.ToInt32(row["ID_changes"]),
                        DN = row["ДН"].ToString(),
                        Номер_извещения = row["Номер_извещения"].ToString(),
                        Дата = row["Дата"].ToString(),
                        Изменения = row["Изменения"].ToString(),
                        Литера = row["Литера"].ToString()
                    };

                    changesList.Add(changesItem);
                }

                ChangesGrid.ItemsSource = changesList;
            }
        }

        public class changes
        {
            public int ID { get; set; }
            public string DN { get; set; }
            public string Номер_извещения { get; set; }
            public string Дата { get; set; }
            public string Изменения { get; set; }
            public string Литера { get; set; }

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
            if (IsAllTextBoxesFilled())
            {
                AddChanges();
            }
            else
            {
                var warning = new Warning();
                bool? result = warning.ShowDialog();

                if (result == true)
                {
                    AddChanges();
                }
                else if (result == false)
                {
                    // Действия при выборе "Нет"
                    warning.Close(); // Закрытие пользовательского окна сообщения
                }
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

        int _id;
        string _dn;

        private void ChangesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChangesGrid.SelectedItem != null)
            {
                changes selectedCard = (changes)ChangesGrid.SelectedItem;
                _dn = selectedCard.DN;
                _id = selectedCard.ID;
                Trash.IsEnabled = true;
            }
            else
            {
                Trash.IsEnabled = false; // Отключение кнопки Trash, если строка не выделена
            }
        }

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
                    string query = "DELETE FROM Changes WHERE ДН = @DN and ID_changes = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DN", _dn);
                        command.Parameters.AddWithValue("@ID", _id);
                        command.ExecuteNonQuery();
                    }
                }

                LoadChangesData();
            }
            else if (result == false)
            {
                // Действия при выборе "Нет"
                warning2.Close(); // Закрытие пользовательского окна сообщения
            }
        }

        public void AddChanges()
        {
            string _DN = DNValue.DN_value;

            string _NumIzv;
            string _Date;
            string _Changes;
            string _Litera;

            _NumIzv = Convert.ToString(NumIzv.Text);
            _Date = Convert.ToString(DateChange.Text);
            _Changes = Convert.ToString(Description.Text);
            _Litera = Convert.ToString(Litera.Text);

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Archive;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Changes (ДН, Номер_извещения, Дата, Изменения, Литера) VALUES('" + _DN + "', '" + _NumIzv + "', '" + _Date + "', '" + _Changes + "', '" + _Litera + "')", connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            NumIzv.Text = "";
            DateChange.Text = "";
            Description.Text = "";
            Litera.Text = "";

            LoadChangesData();
        }
    }
}
