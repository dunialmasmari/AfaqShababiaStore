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
    /// Interaction logic for postition.xaml
    /// </summary>
    public partial class postition : Window
    {
        BL.clsemp Emp = new BL.clsemp();
        public postition()
        {
            InitializeComponent();
            date.Text = Convert.ToString(DateTime.Now);
            position.ItemsSource = Emp.Get_All_position().DefaultView;
            txtid.Text = Emp.maxposition().Rows[0][0].ToString();
           
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void positionfrm(object sender, RoutedEventArgs e)
        {

            if (txtname.Text != ""  )
            {
                
                Addbtn.IsEnabled = false;
            }
        }

        private void addposition(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                Emp.Addposition(Convert.ToInt32(txtid.Text), txtname.Text);


                MessageBox.Show("Add Seccess", "Add Department ", MessageBoxButton.OK, MessageBoxImage.Information);

                txtid.Text = Emp.maxposition().Rows[0][0].ToString();
                txtname.Clear();
                position.ItemsSource = Emp.Get_All_position().DefaultView;

            }
        }

        private void updateposition(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                Emp.Updateposition(Convert.ToInt32(txtid.Text), txtname.Text);
                MessageBox.Show("Update Seccess", "Update Department ", MessageBoxButton.OK, MessageBoxImage.Information);

                txtid.Text = Emp.maxposition().Rows[0][0].ToString();
                position.ItemsSource = Emp.Get_All_position().DefaultView;
                txtname.Clear();

            }
        }

        private void deleteposition(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    Emp.Deleteposition(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtid.Text = Emp.maxposition().Rows[0][0].ToString();
                    position.ItemsSource = Emp.Get_All_position().DefaultView;
                    txtname.Clear();
                }


                else
                {
                    MessageBox.Show("Delete Cancled", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }
        }

        private void cleartxt(object sender, RoutedEventArgs e)
        {
            txtname.Clear();
            txtid.Text = Emp.maxposition().Rows[0][0].ToString();
        }

        private void position_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
                if (sender !=null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid !=null && grid.SelectedItems !=null && grid.SelectedItems.Count==1)
                    {
                        DataGridRow d= grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        DataRowView dr = (DataRowView)d.Item;
                        txtid.Text = dr[0].ToString();
                        txtname.Text = dr[1].ToString();
                    }
                
            }
           
           // object item = position.SelectedItem;
          //  txtid.Text = Convert.ToString(position.SelectedCells[0].Column.GetCellContent(item));
           
        }

    }
}
