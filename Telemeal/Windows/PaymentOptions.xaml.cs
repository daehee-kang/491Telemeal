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
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : Window
    {
        private double dueAmount;
        public PaymentOptions(double due)
        {
            dueAmount = due;
            InitializeComponent();
            AmountDue.Text = "$" + string.Format("{0:F2}", dueAmount);
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var cashpmt = new CashPmt();
            cashpmt.Closed += Window_Closed;
            cashpmt.Show();
            this.Hide();
        }

        private void Paypal_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var ppalpmt = new PaypalPmt();
            ppalpmt.Closed += Window_Closed;
            ppalpmt.Show();
            this.Hide();
        }

        private void CreditCard_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var ccpmt = new CardPmt();
            ccpmt.Closed += Window_Closed;
            ccpmt.Show();
            this.Hide();
        }

        private void Coupon_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var cpn = new Coupon();
            cpn.Closed += Window_Closed;
            cpn.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
