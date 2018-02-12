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
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        private static string ADMINID = "1234";
        private StringBuilder id = new StringBuilder();
        private string pw;
        public EmployeeLogin()
        {
            InitializeComponent();
            //EmployeeID.Password = "1234";
            pw = EmployeeID.Password;
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('1');
            pw += '1';

        }
        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('2');
        }
        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('3');
        }
        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('4');
        }
        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('5');
        }
        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('6');
        }
        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('7');
        }
        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('8');
        }
        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('9');
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (id.Length > 0)
            {
                id.Remove(id.Length - 1, 1);
            }
        }
        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            id.Append('0');
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if(ADMINID.Equals(id.ToString()))
            {
                var manOption = new ManagerOptions();
                manOption.Closed += Window_Closed;
                manOption.Show();
                this.Hide();
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void EmployeeID_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
