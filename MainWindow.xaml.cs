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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string connectionString = Properties.Settings.Default.KP1ConnectionString;
        private void InfAvtor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создатель: Чесноков Н.А.");
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Table<Sotr> users = db.GetTable<Sotr>();
                    var seluser = (from u in users
                                   where u.Login == txtLogin.Text && u.Password == txtPassword.Password
                                   select u).FirstOrDefault();
                    if (seluser != null)
                    {
                        MessageBox.Show("Добро пожаловать! " + seluser.Name + " " + seluser.Otchestvo);
                        Uchet w = new Uchet();
                        w.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя нет");
                    }
                }
            }

            catch
            {
                throw;
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Registr w = new Registr();
            w.ShowDialog();//замысел
        }
    }

}
