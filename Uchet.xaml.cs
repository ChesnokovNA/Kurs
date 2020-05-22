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
using Microsoft.Office.Interop.Excel;


namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для Uchet.xaml
    /// </summary>
    public partial class Uchet : System.Windows.Window
    {
        public Uchet()
        {
            InitializeComponent();
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            if (dtgrdRedact.SelectedItem != null)
            {
                btnRed.IsEnabled = true;
                txtNameIzd.Text = ((Izdelie)dtgrdRedact.SelectedItem).Nameizd;
                txtMaterial.Text = ((Izdelie)dtgrdRedact.SelectedItem).Material;
                txtDiam.Text = Convert.ToString(((Izdelie)dtgrdRedact.SelectedItem).Diametr);
                txtTolsch.Text = Convert.ToString(((Izdelie)dtgrdRedact.SelectedItem).Tolschnastenki);
                txtProf.Text = Convert.ToString(((Izdelie)dtgrdRedact.SelectedItem).Profpoperchsech);

            }
            else
            {
                MessageBox.Show("Выберите поставщика для изменения");
            }
            btnRed.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext(Properties.Settings.Default.KP1ConnectionString))
                {
                    Izdelie q = db.GetTable<Izdelie>().FirstOrDefault();
                    q.Nameizd = txtNameIzd.Text;
                    q.Material = txtMaterial.Text;
                    q.Diametr = Convert.ToInt32(txtDiam.Text);
                    q.Tolschnastenki = Convert.ToInt32(txtTolsch.Text);
                    q.Profpoperchsech = Convert.ToInt32(txtProf.Text);
                    db.SubmitChanges();
                    dtgrdRedact.ItemsSource = db.GetTable<Izdelie>();
                }
                txtNameIzd.Text = "";
                txtMaterial.Text = "";
                txtDiam.Text = "";
                txtTolsch.Text = "";
                txtProf.Text = "";
                btnSave.Visibility = Visibility.Hidden;
                btnRed.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.KP1ConnectionString))
            {
                dtgrdRedact.ItemsSource = db.GetTable<Izdelie>();
                grdBrak.ItemsSource = db.GetTable<Brak>();
                grdataSklad.ItemsSource = db.GetTable<Sklad>();
            }

        }

        private void btnNewBrak_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtNamIzd.Text != "")
                {
                    using (DataContext db = new DataContext(Properties.Settings.Default.KP1ConnectionString))
                    {
                        Brak newBrak = new Brak();
                        newBrak.Nameizd = txtNamIzd.Text;
                        db.GetTable<Brak>().InsertOnSubmit(newBrak);
                        db.SubmitChanges();
                        db.GetTable<Izdelie>();
                        grdBrak.ItemsSource = db.GetTable<Brak>();//обновление датагрида

                    }
                    txtNamIzd.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (DataContext db = new DataContext(Properties.Settings.Default.KP1ConnectionString))
                {
                    Table<Sklad> q = db.GetTable<Sklad>();
                    var srcTable = q.Where(p => p.Nameizd.Contains(txtPoisk.Text));
                    grdataSklad.ItemsSource = srcTable;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");

            }
        }

        private void btnOtchetObsch_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];



            for (int i = 0; i < grdataSklad.Columns.Count; i++)
            {
                for (int j = 0; j < grdataSklad.Items.Count; j++)
                {
                    TextBlock text = grdataSklad.Columns[i].GetCellContent(grdataSklad.Items[j]) as TextBlock;
                    Range range = (Range)ws.Cells[j + 3, i + 1];
                    range.Value2 = text.Text;
                }
            }
            for (int i = 0; i < grdataSklad.Columns.Count; i++)
            {
                Range range = ws.Cells[2, i + 1];
                ws.Cells[2, i + 1].font.bold = true;
                range.Value2 = grdataSklad.Columns[i].Header;
            }
            ws.Columns.AutoFit();
            ws.Range["A1:A1"].Value = "Складской отчёт учёта выпуска изделий создан" + DateTime.Now.ToShortDateString();
            app.Visible = true;
            app.WindowState = XlWindowState.xlNormal;
        }

        private void Otchvet_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];



            for (int i = 0; i < grdBrak.Columns.Count; i++)
            {
                for (int j = 0; j < grdBrak.Items.Count; j++)
                {
                    TextBlock text = grdBrak.Columns[i].GetCellContent(grdBrak.Items[j]) as TextBlock;
                    Range range = (Range)ws.Cells[j + 3, i + 1];
                    range.Value2 = text.Text;
                }
            }
            for (int i = 0; i < grdBrak.Columns.Count; i++)
            {
                Range range = ws.Cells[2, i + 1];
                ws.Cells[2, i + 1].font.bold = true;
                range.Value2 = grdBrak.Columns[i].Header;
                string j = Convert.ToString(grdBrak.Columns.Count);
            }
            ws.Columns.AutoFit();
            ws.Range["A1:A1"].Value = "Складской отчёт учёта лий создан" + DateTime.Now.ToShortDateString();
            app.Visible = true;
            app.WindowState = XlWindowState.xlNormal;
        }
    }
}
