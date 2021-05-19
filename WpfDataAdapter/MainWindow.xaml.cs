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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfDataAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string upit = "SELECT KupacId as ID, ImeKompanije as Firma, KontaktOsoba as Kontakt FROM Prodaja.Kupci";

            SqlDataAdapter da = new SqlDataAdapter(upit, Konekcija.cnnTSQL2018);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "Kupci");
                DataTable dt = ds.Tables["Kupci"];

                //DataGrid1.DataContext = dt;
                DataGrid1.ItemsSource = dt.DefaultView;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
            }


        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Type t = DataGrid1.SelectedItem.GetType();

            //MessageBox.Show(t.ToString());

            DataRowView drv = DataGrid1.SelectedItem as DataRowView;

            StringBuilder sb = new StringBuilder();

            //sb.AppendLine(drv["ID"].ToString());
            //sb.AppendLine(drv["Firma"].ToString());
            //sb.AppendLine(drv["Kontakt"].ToString());

            sb.AppendLine(drv[0].ToString());
            sb.AppendLine(drv[1].ToString());
            sb.AppendLine(drv[2].ToString());

            TextBlock1.Text = sb.ToString();
        }
    }
}
