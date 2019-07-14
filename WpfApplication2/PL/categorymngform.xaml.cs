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
    /// Interaction logic for categorymngform.xaml
    /// </summary>
    public partial class categorymngform : Window
    {
        BL.items s= new BL.items();
        public categorymngform()
        {
            InitializeComponent();
            date.Text = Convert.ToString(DateTime.Now);
            category.ItemsSource = s.Get_All_category().DefaultView;
            txtid.Text = s.maxcategory().Rows[0][0].ToString();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtabb.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                s.Addcategory(Convert.ToInt32(txtid.Text), txtname.Text,txtabb.Text);


                MessageBox.Show("Add Seccess", "Add Department ", MessageBoxButton.OK, MessageBoxImage.Information);
                category.ItemsSource = s.Get_All_category().DefaultView;
                txtid.Text = s.maxcategory().Rows[0][0].ToString();
                txtname.Clear();
                txtabb.Clear();

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void category_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                    txtabb.Text = dr[2].ToString();
                }
            }

        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == ""|| txtabb.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                s.Updatecategory(Convert.ToInt32(txtid.Text), txtname.Text,txtabb.Text);
                MessageBox.Show("Update Seccess", "Update Department ", MessageBoxButton.OK, MessageBoxImage.Information);

                category.ItemsSource = s.Get_All_category().DefaultView;
                txtid.Text = s.maxcategory().Rows[0][0].ToString();
                txtname.Clear();
                txtabb.Clear();

            }
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtabb.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    s.Deletecategory(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    category.ItemsSource = s.Get_All_category().DefaultView;
                    txtid.Text = s.maxcategory().Rows[0][0].ToString();
                    txtname.Clear();
                    txtabb.Clear();
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtname.Text != "" || txtabb.Text!="")
            {

                Addbtn.IsEnabled = false;
            }
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtid.Text = s.maxcategory().Rows[0][0].ToString();
            txtname.Clear();
            txtabb.Clear();
        }
    }
}
