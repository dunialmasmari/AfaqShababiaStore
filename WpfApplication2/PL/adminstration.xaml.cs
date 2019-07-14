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
    /// Interaction logic for adminstration.xaml
    /// </summary>
    public partial class adminstration : Window
    {
        BL.clsemp Emp = new BL.clsemp();
        public adminstration()
        {
            InitializeComponent();
            date.Text = Convert.ToString(DateTime.Now);
            admin.ItemsSource = Emp.Get_All_admin().DefaultView;

            txtid.Text = Emp.maxadmin().Rows[0][0].ToString();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addadmin(object sender, RoutedEventArgs e)
        {

            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                Emp.Addadmin(Convert.ToInt32(txtid.Text), txtname.Text);


                MessageBox.Show("Add Seccess", "Add Department ", MessageBoxButton.OK, MessageBoxImage.Information);
                admin.ItemsSource = Emp.Get_All_admin().DefaultView;
                txtid.Text = Emp.maxadmin().Rows[0][0].ToString();
                txtname.Clear();

            }
        }

        private void updateadmin(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                Emp.Updateadmin(Convert.ToInt32(txtid.Text), txtname.Text);
                MessageBox.Show("Update Seccess", "Update Department ", MessageBoxButton.OK, MessageBoxImage.Information);
                admin.ItemsSource = Emp.Get_All_admin().DefaultView;
                txtid.Text = Emp.maxadmin().Rows[0][0].ToString();

                txtname.Clear();

            }
        }

        private void deleteadmin(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    Emp.Deleteadmin(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    admin.ItemsSource = Emp.Get_All_admin().DefaultView;
                    txtid.Text = Emp.maxadmin().Rows[0][0].ToString();

                    txtname.Clear();
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void Adminstration_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                }
            }
        }

        private void clearclick(object sender, RoutedEventArgs e)
        {
            txtid.Text = Emp.maxadmin().Rows[0][0].ToString();

            txtname.Clear();
        }
    }
    }

