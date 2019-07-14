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
using System.Data;

namespace WpfApplication2.PL
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {  BL.clslogin log = new BL.clslogin();
        public Login()
        {
            InitializeComponent();
        }
        private void login_click(object sender, RoutedEventArgs e)
    {
         if (txtid.Text == "" || txtpwd.Password == "")
            {
                MessageBox.Show("Please fill the boxes..");
            }
            else
            {

                DataTable Dt = log.LOGIN(txtid.Text, txtpwd.Password);
                if (Dt.Rows.Count > 0)
                {





                    WpfApplication2.Properties.Settings.empname = Dt.Rows[0]["username"].ToString();
                    WpfApplication2.Properties.Settings.empno = Convert.ToInt32(Dt.Rows[0]["userpassword"]);
                    WpfApplication2.PL.main f = new WpfApplication2.PL.main(WpfApplication2.Properties.Settings.empname.ToString());
                    
                    f.Show();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Login Faild !");
                }

            }
    }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
