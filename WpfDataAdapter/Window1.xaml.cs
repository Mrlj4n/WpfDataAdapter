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

namespace WpfDataAdapter
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Prodaja.Kupci", Konekcija.cnnTSQL2018);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            SqlCommand insertCommand = cb.GetInsertCommand(true);//true -> parametri se zovu istu kao i kolone, fasle -> p1,p2,p3...

            TextBlock1.Text = insertCommand.CommandText;
        }
    }
}
