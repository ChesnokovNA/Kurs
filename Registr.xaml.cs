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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        string connectionString = Properties.Settings.Default.KP1ConnectionString;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //проверка пароля
                string s = txtPass.Text;
                char[] array = s.ToCharArray(); // раскладываем строку парля на знаки
                int d = s.Length;
                int k = 0;
                int u = 0;
                int b = 0;
                char p = '$';
                char j = '!';
                char f = '@';
                char h = '%';
                char z = '^';
                char x = '#';

                // проверка на Верхний регистр
                for (int i = 0; i < d; i++)
                {
                    if (char.IsUpper(array[i]))//вычисляем регистр
                        k++;
                }
                // проверка на число
                for (int i = 0; i < d; i++)
                {
                    if (char.IsNumber(array[i]))//вычисляем числа
                        u++;
                }
                // проверка на знак
                for (int i = 0; i < d; i++)
                {//вычисляем знак
                    if (Convert.ToChar(p) == (array[i]) || Convert.ToChar(j) ==
                    (array[i]) || Convert.ToChar(h) == (array[i]) || Convert.ToChar(z) == (array[i]) ||
                    Convert.ToChar(f) == (array[i]) || Convert.ToChar(x) == (array[i]))
                        b++;
                }
                if ((k >= 1) && (txtPass.Text.Length >= 6) && (u >= 1) && (b >= 1))
                    using (DataContext db = new DataContext(connectionString))
                    {
                        Sotr user = new Sotr();
                        user.Login = txtLog.Text;
                        user.Password = txtPass.Text;
                        user.Familia = txtFam.Text;
                        user.Name = txtName.Text;
                        user.Otchestvo = txtOtch.Text;
                        user.Rol = txtRol.Text;
                        user.Status = true;
                        db.GetTable<Sotr>().InsertOnSubmit(user);
                        db.SubmitChanges();
                        MessageBox.Show("Добавлен в базу данных");
                        Uchet w = new Uchet();
                        w.Show();
                        this.Close();
                    }
                else
                {
                    MessageBox.Show("Пароль должен содержать $ ! @ # ^ %, как минимум 1 цифру, как минимум одну заглавную букву");
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}
