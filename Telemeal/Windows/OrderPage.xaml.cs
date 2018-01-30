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

namespace Telemeal.Windows
{
    public partial class OrderPage : Window
    { 
        List<Food> foods = new List<Food>();
        List<Button> buttons = new List<Button>();
        double tax = 0.1;
        double total = 0;

        public OrderPage()
        {
            InitializeComponent();

            this.totalTBox.Text = total.ToString();
            this.taxTBox.Text = string.Format("{0:F2}", total * tax);
            this.subtotalTBox.Text = string.Format("{0:F2}", (total + Double.Parse(taxTBox.Text)));

            foods.Add(new Food() { FoodID = 1, Name = "Hamburger", Price = 2.50, Img = "/Telemeal;component/hamburger.png", FdCtgr = Food_Category.Main });
            foods.Add(new Food() { FoodID = 2, Name = "Cheeseburger", Price = 3.00, Img = "", FdCtgr = Food_Category.Main });
            foods.Add(new Food() { FoodID = 3, Name = "Double Double Burger", Price = 4.00, Img = "", FdCtgr = Food_Category.Main });
            foods.Add(new Food() { FoodID = 4, Name = "French Fries", Price = 1.50, Img = "", FdCtgr = Food_Category.Appetizer });
            foods.Add(new Food() { FoodID = 5, Name = "Animal Fries", Price = 3.00, Img = "", FdCtgr = Food_Category.Appetizer });
            foods.Add(new Food() { FoodID = 6, Name = "sm Drink", Price = 1.50, Img = "", FdCtgr = Food_Category.Drink });
            foods.Add(new Food() { FoodID = 7, Name = "lg Drink", Price = 2.00, Img = "", FdCtgr = Food_Category.Drink });
            foods.Add(new Food() { FoodID = 8, Name = "Milkshake", Price = 3.00, Img = "", FdCtgr = Food_Category.Dessert });
            foods.Add(new Food() { FoodID = 9, Name = "Cookie", Price = 1.00, Img = "", FdCtgr = Food_Category.Dessert });

            foreach(Food f in foods)
            {
                Button b = new Button();
                WrapPanel wp = new WrapPanel();
                /*
                Image image = new Image
                {
                    Source = new BitmapImage(new Uri(f.Img))
                };
                wp.Children.Add(image);
                */
                TextBlock name = new TextBlock
                {
                    Text = f.Name
                };
                wp.Children.Add(name);

                TextBlock desc = new TextBlock
                {
                    Text = f.Description
                };
                wp.Children.Add(desc);

                TextBlock price = new TextBlock
                {
                    Text = f.Price.ToString()
                };
                wp.Children.Add(price);

                b.Content = wp;

                buttons.Add(b);

                Menu.Children.Add(b);
            }

            /*
            DataAccess db = new DataAccess();
            foods = db.GetFoods();

            Menu.ItemsSource = foods;
            Menu.DisplayMemberPath = "Name"; 
            */
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var pmtscr = new PaymentOptions(total * (1 + tax));
            pmtscr.Closed += Window_Closed;
            pmtscr.Show();
            this.Hide();
        }

        private void Appetizer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dessert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {

        }

        /*
        private void Menu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ItemCart.DisplayMemberPath = "Name";
            PriceCart.DisplayMemberPath = "Price";
            var item = ItemsControl.ContainerFromElement(Menu, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                var content = item.Content as Food;
                var fd = new Food() { FoodID = content.FoodID, Name = content.Name, Price = content.Price, Description = content.Description, FdCtgr = content.FdCtgr };
                ItemCart.Items.Add(fd);
                PriceCart.Items.Add(fd);
                total += ((Food)item.Content).Price;
            }
            this.totalTBox.Text = string.Format("{0:F2}", total);
            this.taxTBox.Text = string.Format("{0:F2}", total * tax);
            this.subtotalTBox.Text = string.Format("{0:F2}", (total + Double.Parse(taxTBox.Text)));
        }
        */

        private void ItemCart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Food selected = ItemCart.SelectedItem as Food;
            int index = ItemCart.SelectedIndex;
            if (ItemCart.SelectedItem != null)
            {
                ItemCart.Items.RemoveAt(index);
                PriceCart.Items.RemoveAt(index);
                total -= selected.Price;
            }
            this.totalTBox.Text = string.Format("{0:F2}", total);
            this.taxTBox.Text = string.Format("{0:F2}", total * tax);
            this.subtotalTBox.Text = string.Format("{0:F2}", (total + Double.Parse(taxTBox.Text)));
        }
    }
}
