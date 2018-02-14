using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using Telemeal.Model;

namespace Telemeal.Windows
{
    /// <summary>
    /// Interaction logic for ViewDB.xaml
    /// </summary>
    public partial class ViewDB : Window
    {
        dbConnection conn = new dbConnection();
        public ViewDB()
        {
            InitializeComponent();
            SQLiteDataReader reader = conn.ViewTable("Food");
            while (reader.Read())
            {
                IDataRecord record = reader as IDataRecord;
                tbDataView.Text += String.Format($"{record[0]}, {record[1]}, {record[2]}, {record[3]}, {record[4]}, {record[5]}, {record[6]}\n");
            }
        }
    }
}
