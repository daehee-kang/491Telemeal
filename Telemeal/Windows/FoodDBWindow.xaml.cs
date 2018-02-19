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
//using System.Windows.Shapes;
using Telemeal.Model;
using System.Data.SQLite;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Windows.Markup;
using System.Data;

namespace Telemeal.Windows
{
    /// <summary>
    /// Interaction logic for FoodDBTestWindow.xaml
    /// </summary>



    public partial class FoodDBTestWindow : Window
    {
        private static string ERROR_CODE_MRF = "Missing Required Fields: ID, Name, Price, Category";
        private static string ERROR_CODE_IDT = "Invalid Datatype: ";
        dbConnection conn = new dbConnection();
        List<Food> lFood = new List<Food>();
        Sub_Category[] sub_list = new Sub_Category[] { Sub_Category.Drink, Sub_Category.Appetizer, Sub_Category.Main, Sub_Category.Dessert };

        public FoodDBTestWindow()
        {
            InitializeComponent();
            foreach(Sub_Category s in sub_list)
            {
                cbAddCategory.Items.Add(s);
                cbEditCategory.Items.Add(s);
            }

            PopulateCBEditFoodID();
        }

        private void PopulateCBEditFoodID()
        {
            conn.DeleteFoodByName("Food", "");
            SQLiteDataReader reader = conn.ViewTable("Food");
            while (reader.Read())
            {
                IDataRecord record = reader as IDataRecord;
                int id = (int)record[0];
                string name = (string)record[1];
                double price = (double)record[2];
                string desc = (string)record[3];
                string image = (string)record[4];
                Main_Category main = (Main_Category)record[5];
                Sub_Category sub = (Sub_Category)record[6];
                Food food = new Food
                {
                    FoodID = id,
                    Name = name,
                    Price = price,
                    Description = desc,
                    Img = image,
                    MainCtgr = main,
                    SubCtgr = sub
                };

                lFood.Add(food);
                cbEditFoodID.Items.Add(food.FoodID);
            }
            reader.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            conn.Close();
        }

        private void bAddFoodItem_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string tableName = "Food";
            try
            {
                int fID = int.Parse(tbAddNumber.Text);
                string fName = tbAddName.Text;
                double fPrice = double.Parse(tbAddPrice.Text);
                string fDesc = tbAddDesc.Text;
                string fImg = TelemealPath(tbAddImage.Text);
                Main_Category fMainCtgr = Main_Category.All;
                Sub_Category fSubCtgr = (Sub_Category)Enum.Parse(typeof(Sub_Category), cbAddCategory.Text);

                Food food = new Food
                {
                    FoodID = fID,
                    Name = fName,
                    Price = fPrice,
                    Description = fDesc,
                    Img = fImg,
                    MainCtgr = fMainCtgr,
                    SubCtgr = fSubCtgr
                };
                conn.InsertFood(tableName, food);
                lFood.Add(food);
                cbEditFoodID.Items.Add(food.FoodID);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ERROR_CODE_IDT);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ERROR_CODE_MRF);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bAddImage_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string imgFile = "";
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../"));
            ofd.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg|JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            ofd.FilterIndex = 4;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                try
                {
                    imgFile = ofd.FileName;
                    tbAddImage.Text = imgFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void bViewFoodItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button b = sender as Button;
                ViewDB viewDB = new ViewDB();
                viewDB.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cBox = sender as ComboBox;
            int id = 0;
            if (cBox.SelectedIndex != -1)
            {
                id = int.Parse(cBox.SelectedItem.ToString());
                Food food = lFood.Where(v => v.FoodID == id).First();
                tbEditName.Text = food.Name;
                tbEditPrice.Text = food.Price.ToString();
                tbEditDesc.Text = food.Description;
                tbEditImage.Text = food.Img;
                cbEditCategory.Text = food.SubCtgr.ToString();
            }
        }

        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (int)cbEditFoodID.SelectedValue;
                string name = tbEditName.Text;
                double price = double.Parse(tbEditPrice.Text);
                string desc = tbEditDesc.Text;
                string img = TelemealPath(tbEditImage.Text);
                Main_Category main = Main_Category.All;
                Sub_Category sub = (Sub_Category)Enum.Parse(typeof(Sub_Category), cbEditCategory.Text);
                Food food = new Food
                {
                    FoodID = id,
                    Name = name,
                    Price = price,
                    Description = desc,
                    Img = img,
                    MainCtgr = main,
                    SubCtgr = sub
                };
                conn.UpdateFood("Food", food);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bEditImage_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string imgFile = "";
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../"));
            ofd.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg|JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            ofd.FilterIndex = 4;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                try
                {
                    imgFile = ofd.FileName;
                    tbEditImage.Text = imgFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(cbEditFoodID.Text);
                conn.DeleteFoodByID("Food", id);
                cbEditFoodID.SelectedIndex = -1;
                tbEditName.Clear();
                tbEditImage.Clear();
                tbEditDesc.Clear();
                tbEditPrice.Clear();
                cbEditCategory.SelectedIndex = -1;

                cbEditFoodID.Items.Clear();
                lFood.Clear();

                PopulateCBEditFoodID();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string TelemealPath(string path)
        {
            string relPath = "";
            int counter = 0;
            bool pathFound = false;
            String[] split = path.Split('\\');

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "Telemeal")
                {
                    counter = i;
                    pathFound = true;
                    break;
                }
            }

            if (pathFound)
            {
                for (int i = counter; i < split.Length; i++)
                {
                    relPath += "/";
                    relPath += split[i];
                    if (i == counter)
                    {
                        relPath += ";component";
                    }
                }
            }

            return relPath;
        }
    }
}

