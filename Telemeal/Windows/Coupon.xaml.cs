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

namespace Telemeal.Windows
{
    /// <summary>
    /// Interaction logic for Coupon.xaml
    /// </summary>
    public partial class Coupon : Window
    {
        public Coupon()
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            this.Close();
        }
    }
}
