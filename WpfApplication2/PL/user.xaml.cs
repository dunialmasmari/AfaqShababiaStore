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
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication2.PL
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Window
    {
        BL.clsemp Emp = new BL.clsemp();
        public user()
        {
            InitializeComponent();
            cmb1.ItemsSource = Emp.Get_All_autho().DefaultView;
            cmb1.DisplayMemberPath = "Autho_typename";
            cmb1.SelectedValuePath = "Autho_typeno";

            users.ItemsSource = Emp.Get_All_user().DefaultView;
            txtid.Text = Emp.maxuser().Rows[0][0].ToString();
            Addbtn.IsEnabled = true;
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "" || cmb1.Text == "" || txtpw.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                Emp.Adduser(Convert.ToInt32(txtid.Text), txtname.Text, txtpw.Text, Convert.ToInt32(cmb1.SelectedValue));
                MessageBox.Show("Add Seccess", "Add Product ", MessageBoxButton.OK, MessageBoxImage.Information);

                txtid.Text = Emp.maxemp().Rows[0][0].ToString();
                txtname.Clear();
                txtpw.Clear();
                users.ItemsSource = Emp.Get_All_emp().DefaultView;
               
                cmb1.ItemsSource = Emp.Get_All_admin().DefaultView;

            }
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "" || cmb1.Text == "" || txtpw.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                Emp.Updateuser(Convert.ToInt32(txtid.Text), txtname.Text, txtpw.Text, Convert.ToInt32(cmb1.SelectedValue));
                MessageBox.Show("Update Seccess", "Update Product ", MessageBoxButton.OK, MessageBoxImage.Information);
                txtid.Text = Emp.maxemp().Rows[0][0].ToString();
                txtname.Clear();
                users.ItemsSource = Emp.Get_All_user().DefaultView;
                txtpw.Clear();
                cmb1.ItemsSource = Emp.Get_All_autho().DefaultView;
                Addbtn.IsEnabled = true;
                Deletebtn.IsEnabled = false;
                Updatebtn.IsEnabled = false;
            }

        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtpw.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    Emp.Deleteuser(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtid.Text = Emp.maxuser().Rows[0][0].ToString();
                    txtname.Clear();
                    users.ItemsSource = Emp.Get_All_user().DefaultView;
                    txtpw.Clear();
                    cmb1.ItemsSource = Emp.Get_All_autho().DefaultView;
                    Addbtn.IsEnabled = true;
                    Deletebtn.IsEnabled = false;
                    Updatebtn.IsEnabled = false;
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void user_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow d = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    DataRowView dr = (DataRowView)d.Item;
                    txtid.Text = dr[0].ToString();
                    txtname.Text = dr[1].ToString();
                    txtpw.Text = dr[2].ToString();
                    cmb1.Text = dr[3].ToString();
                   
                }
                Addbtn.IsEnabled = false;
                Deletebtn.IsEnabled = true;
                Updatebtn.IsEnabled = true;
            }
        }

        private void clearclick(object sender, RoutedEventArgs e)
        {
            txtid.Text = Emp.maxuser().Rows[0][0].ToString();
            txtname.Clear();
            
            cmb1.ItemsSource = Emp.Get_All_autho().DefaultView;
            Addbtn.IsEnabled = true;
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
        }

        private void Exitclick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
