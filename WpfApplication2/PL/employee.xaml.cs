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
    /// Interaction logic for employee.xaml
    /// </summary>
    public partial class employee : Window
    {
        BL.clsemp Emp = new BL.clsemp();
        public employee()
        {
            InitializeComponent();
            cmb1.ItemsSource= Emp.Get_All_admin().DefaultView;
            cmb1.DisplayMemberPath = "empadminname";
            cmb1.SelectedValuePath = "empadminno";
           
            cmb2.ItemsSource = Emp.Get_All_position().DefaultView;   
            cmb2.DisplayMemberPath = "empposition_name";
            cmb2.SelectedValuePath= "empposition_no";

            employe.ItemsSource = Emp.Get_All_emp().DefaultView;
            txtid.Text = Emp.maxemp().Rows[0][0].ToString();
            Addbtn.IsEnabled = true;
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
           
        }

        private void extclick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clearclick(object sender, RoutedEventArgs e)
        {
            txtid.Text = Emp.maxemp().Rows[0][0].ToString();
            txtname.Clear();
            cmb2.ItemsSource = Emp.Get_All_position().DefaultView;
            cmb1.ItemsSource = Emp.Get_All_admin().DefaultView;
            Addbtn.IsEnabled = true;          
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
        }

        private void deleteclick(object sender, RoutedEventArgs e)
        {
          
         
            
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    Emp.Deletemp(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtid.Text = Emp.maxemp().Rows[0][0].ToString();
                    txtname.Clear();
                    employe.ItemsSource = Emp.Get_All_emp().DefaultView;
                    cmb2.ItemsSource = Emp.Get_All_position().DefaultView;
                    cmb1.ItemsSource = Emp.Get_All_admin().DefaultView;
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void updateclick(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "" || cmb1.Text == "" || cmb2.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                Emp.Updatemp(Convert.ToInt32(txtid.Text), txtname.Text, Convert.ToInt32(cmb2.SelectedValue), Convert.ToInt32(cmb1.SelectedValue));
                MessageBox.Show("Update Seccess", "Update Product ", MessageBoxButton.OK, MessageBoxImage.Information);
                txtid.Text = Emp.maxemp().Rows[0][0].ToString();
                txtname.Clear();
                employe.ItemsSource = Emp.Get_All_emp().DefaultView;
                cmb2.ItemsSource = Emp.Get_All_position().DefaultView;
                cmb1.ItemsSource = Emp.Get_All_admin().DefaultView;
            }
        }

        private void addclick(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "" || cmb1.Text == "" || cmb2.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                
                Emp.Addemp(Convert.ToInt32(txtid.Text), txtname.Text,Convert.ToInt32(cmb2.SelectedValue),Convert.ToInt32(cmb1.SelectedValue));
                MessageBox.Show("Add Seccess", "Add Product ", MessageBoxButton.OK, MessageBoxImage.Information);

                txtid.Text = Emp.maxemp().Rows[0][0].ToString();
                txtname.Clear();
                employe.ItemsSource = Emp.Get_All_emp().DefaultView;
                cmb2.ItemsSource = Emp.Get_All_position().DefaultView; 
                cmb1.ItemsSource = Emp.Get_All_admin().DefaultView;

            }
        }

        private void employe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                    cmb1.Text = dr[2].ToString();
                    cmb2.Text = dr[3].ToString();
                }
               Addbtn.IsEnabled = false;
               Deletebtn.IsEnabled = true;
               Updatebtn.IsEnabled = true;
            }
        }

      
    }
}
