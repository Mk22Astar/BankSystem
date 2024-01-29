using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace BankSystem
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnAutho_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-58EEUTC\SQLEXPRESS;initial catalog=22.106-pr5;integrated security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM [User] WHERE Login = '{tbLogin.Text}' AND password = '{PassBox.Password}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string login = reader.GetString(1);
                                string password = reader.GetString(2);
                                if (password == PassBox.Password)
                                {
                                    Frame frame = new Frame();
                                    frame.Navigate(new Window2());
                                    this.Content = frame;
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }
    }
}

