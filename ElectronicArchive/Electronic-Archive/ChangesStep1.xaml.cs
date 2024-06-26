﻿using System;
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
    /// <summary>
    /// Логика взаимодействия для ChangesStep1.xaml
    /// </summary>
    public partial class ChangesStep1 : Window
    {
        public ChangesStep1()
        {
            InitializeComponent();
        }

        private void changes_Click(object sender, RoutedEventArgs e)
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
                    DNValue.DN_value = DNV.Text;
                    ChangesStep2 changesStep2 = new ChangesStep2();
                    changesStep2.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
