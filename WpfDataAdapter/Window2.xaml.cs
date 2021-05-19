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
using System.Data;
using System.Data.SqlClient;

namespace WpfDataAdapter
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter("SELECT KupacId as ID, ImeKompanije as Firma, KontaktOsoba as Kontakt FROM Prodaja.Kupci", Konekcija.cnnTSQL2018);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Prodaja.Kupci", Konekcija.cnnTSQL2018);

            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();

            try
            {
                da.Fill(ds,"Kupci");
                DataTable tbl = ds.Tables["Kupci"];
                DataRow prviRed = tbl.Rows[2];
                //sb.AppendLine("ID: " + prviRed["ID"].ToString());
                //sb.AppendLine("Firma: " + prviRed["Firma"].ToString());
                //sb.AppendLine("Kontakt: " + prviRed["Kontakt"].ToString());

                //sb.AppendLine("ID: " + prviRed[0].ToString());
                //sb.AppendLine("Firma: " + prviRed[1].ToString());
                //sb.AppendLine("Kontakt: " + prviRed[2].ToString());

                foreach (DataColumn kolona in tbl.Columns)
                {
                    if (Convert.IsDBNull(prviRed[kolona])) //null
                    {
                        sb.AppendLine(kolona.ColumnName.PadRight(50, '.')+" : NULL");
                    }
                    else
                    {
                        sb.AppendLine(kolona.ColumnName.PadRight(50, '.') + prviRed[kolona]);
                    }
                }

                TextBlock1.Text = sb.ToString();
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(TextBoxID.Text, out int id))
            {
                MessageBox.Show("Unesite ceo broj");
                TextBoxID.Clear();
                TextBoxID.Focus();
                return;
            }


            SqlDataAdapter da = new SqlDataAdapter("SELECT KupacId as Id, ImeKompanije as Firma, KontaktOsoba as Kontakt FROM Prodaja.Kupci", Konekcija.cnnTSQL2018);

            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;//preuz info o primary key

            DataSet ds = new DataSet(); //netipizirani ds
            DataRow dr = null;

            try
            {
                da.Fill(ds, "Kupci");
                DataTable tbl = ds.Tables[0];

                dr = tbl.Rows.Find(id);

            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return;
            }

            StringBuilder sb = new StringBuilder();

            if (dr!=null)
            {
                sb.AppendLine(dr[0].ToString());    
                sb.AppendLine(dr[1].ToString());    
                sb.AppendLine(dr[2].ToString());

            }
            else
            {
                sb.AppendLine("Ne postoji kupac ciji je id: " + id);
            }
            TextBlock1.Text = sb.ToString();
        }
    }
}
