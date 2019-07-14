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

namespace WpfApplication2.PL
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main(string x)
        {
            InitializeComponent();
            DT.Text = "TODAY IS: " + DateTime.Now;
            MN.Text = "PC :" + Environment.MachineName;
            EN.Text = " USER NAME :" + x + "";
        }

        private void position(object sender, RoutedEventArgs e)
        {
            postition p = new postition();
            p.Show();
        }

        private void adminstration(object sender, RoutedEventArgs e)
        {
            adminstration a = new adminstration();
            a.Show();
        }

        private void project(object sender, RoutedEventArgs e)
        {
            Projectsform p = new Projectsform();
            p.Show();

        }

        private void employee(object sender, RoutedEventArgs e)
        {
            employee r = new employee();
            r.Show();
        

        }

        private void usermng(object sender, RoutedEventArgs e)
        {
            user s = new user();
            s.Show();
        }

        private void itemsmng(object sender, RoutedEventArgs e)
        {
            ItemsmanagementForm d = new ItemsmanagementForm();
            d.Show();
        }

        private void unitmng(object sender, RoutedEventArgs e)
        {
            unitmngform u = new unitmngform();
            u.Show();
        }

        private void storemng(object sender, RoutedEventArgs e)
        {
            Storemngform s = new Storemngform();
            s.Show();
        }

        private void catmng(object sender, RoutedEventArgs e)
        {
            categorymngform c = new categorymngform();
            c.Show();
        }

      
    }
}
