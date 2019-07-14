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
    /// Interaction logic for ItemsmanagementForm.xaml
    /// </summary>
    public partial class ItemsmanagementForm : Window
    {
        BL.items s = new BL.items();
        public ItemsmanagementForm()
        {
            InitializeComponent();

            cmbcategory.ItemsSource = s.Get_All_category().DefaultView;
            cmbcategory.DisplayMemberPath = "categoryname";
            cmbcategory.SelectedValuePath = "categoryno";

            date.Text = Convert.ToString(DateTime.Now);
            item.ItemsSource = s.Get_All_items().DefaultView;
            txtid.Text = s.maxitem(Convert.ToInt32(cmbcategory.SelectedValue)).Rows[0][0].ToString();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtmin.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                s.Additem(txtid.Text, txtname.Text,Convert.ToInt32( txtmin.Text),Convert.ToInt32(cmbcategory.SelectedValue));


                MessageBox.Show("Add Seccess", "Add Department ", MessageBoxButton.OK, MessageBoxImage.Information);
                item.ItemsSource = s.Get_All_items().DefaultView;
                txtid.Clear();
                cmbcategory.ItemsSource = s.Get_All_category().DefaultView;
                txtname.Clear();
                txtmin.Clear();

            }

        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtmin.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                s.Updateitem(txtid.Text, txtname.Text, Convert.ToInt32(txtmin.Text), Convert.ToInt32(cmbcategory.SelectedValue));
                MessageBox.Show("Update Seccess", "Update Department ", MessageBoxButton.OK, MessageBoxImage.Information);

                item.ItemsSource = s.Get_All_items().DefaultView;
                txtid.Clear();
                cmbcategory.ItemsSource = s.Get_All_category().DefaultView;
                txtname.Clear();
                txtmin.Clear();

            }
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "" || txtmin.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    s.Deleteitem(txtid.Text);
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    item.ItemsSource = s.Get_All_items().DefaultView;
                    txtid.Clear();
                    cmbcategory.ItemsSource = s.Get_All_category().DefaultView;
                    txtname.Clear();
                    txtmin.Clear();
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtid.Clear();
            cmbcategory.ItemsSource = s.Get_All_category().DefaultView;
            txtname.Clear();
            txtmin.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtname.Text != "" || txtmin.Text != "")
            {

                Addbtn.IsEnabled = false;
            }
        }

        private void item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                    txtmin.Text = dr[2].ToString();
                }
            }
        }

        private void cmbcategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             txtid.Text = s.maxitem(Convert.ToInt32(cmbcategory.SelectedValue)).Rows[0][0].ToString();
        }

    }
}
