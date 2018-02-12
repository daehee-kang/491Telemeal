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
            string name = viewTableName.Text;
            SQLiteDataReader reader = conn.ViewTable(name);
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

        private void fTable_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintTableName.Visibility = Visibility.Visible;
            if (fTable.Text.Length > 0)
            {
                hintTableName.Visibility = Visibility.Hidden;
            }
        }

        private void fID_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodID.Visibility = Visibility.Visible;
            if (fID.Text.Length > 0)
            {
                hintFoodID.Visibility = Visibility.Hidden;
            }
        }

        private void fName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodName.Visibility = Visibility.Visible;
            if (fName.Text.Length > 0)
            {
                hintFoodName.Visibility = Visibility.Hidden;
            }
        }

        private void fPrice_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodPrice.Visibility = Visibility.Visible;
            if (fPrice.Text.Length > 0)
            {
                hintFoodPrice.Visibility = Visibility.Hidden;
            }
        }

        private void fDesc_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodDesc.Visibility = Visibility.Visible;
            if (fDesc.Text.Length > 0)
            {
                hintFoodDesc.Visibility = Visibility.Hidden;
            }
        }

        private void fImg_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodImg.Visibility = Visibility.Visible;
            if (fImg.Text.Length > 0)
            {
                hintFoodImg.Visibility = Visibility.Hidden;
            }
        }

        private void fMain_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodCtgrMain.Visibility = Visibility.Visible;
            if (fMain.Text.Length > 0)
            {
                hintFoodCtgrMain.Visibility = Visibility.Hidden;
            }
        }

        private void fSub_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintFoodCtgrSub.Visibility = Visibility.Visible;
            if (fSub.Text.Length > 0)
            {
                hintFoodCtgrSub.Visibility = Visibility.Hidden;
            }
        }

        private void viewTableName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintViewTableName.Visibility = Visibility.Visible;
            if (viewTableName.Text.Length > 0)
            {
                hintViewTableName.Visibility = Visibility.Hidden;
            }
        }

        private void NameDelete_SelectionChanged(object sender, RoutedEventArgs e)
        {
            hintTableDelete.Visibility = Visibility.Visible;
            if (NameDelete.Text.Length > 0)
            {
                hintTableDelete.Visibility = Visibility.Hidden;
            }
        }
    }
}
