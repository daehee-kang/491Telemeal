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
using Telemeal.Model;
using System.Data.SQLite;

namespace Telemeal.Windows
{
    /// <summary>
    /// Interaction logic for FoodDBTestWindow.xaml
    /// </summary>
    public partial class FoodDBTestWindow : Window
    {
        dbConnection conn = new dbConnection();

        public FoodDBTestWindow()
        {
            InitializeComponent();
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string name = TableName.Text;
            conn.CreateFoodTable(name);
        }

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string tableName = fTable.Text;
            Food food = new Food
            {
                FoodID = int.Parse(fID.Text),
                Name = fName.Text,
                Price = double.Parse(fPrice.Text),
                Description = fDesc.Text,
                Img = fImg.Text,
                MainCtgr = (Main_Category)int.Parse(fMain.Text),
                SubCtgr = (Sub_Category)int.Parse(fSub.Text)
            };
            conn.InsertFood(tableName, food);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            conn.Close();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            string name = dbName.Text;
            SQLiteDataReader reader = conn.ViewFoodTable(name);
            while (reader.Read())
            {
                ShowData.Text += string.Format($"Name: {reader["name"]}, Price: {reader["price"]}, Desc: {reader["desc"]}\n");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            conn.DeleteTable(NameDelete.Text);
        }
    }
}
