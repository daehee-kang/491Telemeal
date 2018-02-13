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
        private static string ADMINNAME = "Bryan Duong";
        private StringBuilder id = new StringBuilder();
        private string pw;
        public EmployeeLogin()
        {
            InitializeComponent();
            pw = EmployeeID.Password;
        }

        

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (id.Length > 0)
            {
                id.Remove(id.Length - 1, 1);
            }
        }
        
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (EmployeeID.Password == ADMINID && EmployeeName.Text == ADMINNAME)
            {
                //var foodDB = new FoodDBTestWindow();
                //foodDB.Closed += Window_Closed;
                //foodDB.Show();

                var manOption = new ManagerOptions();
                manOption.Closed += Window_Closed;
                manOption.Show();
                this.Hide();
            }


            /*if (ADMINID.Equals(id.ToString()))
            {
                //var foodDB = new FoodDBTestWindow();
                //foodDB.Closed += Window_Closed;
                //foodDB.Show();

                var manOption = new ManagerOptions();
                manOption.Closed += Window_Closed;
                manOption.Show();
                this.Hide();
            }*/
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
