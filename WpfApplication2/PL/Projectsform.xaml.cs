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

namespace WpfApplication2.PL
{
    /// <summary>
    /// Interaction logic for Projectsform.xaml
    /// </summary>
    public partial class Projectsform : Window
    {
        BL.items I = new BL.items();
        public Projectsform()
        {
            InitializeComponent();
            projectdg.ItemsSource = I.Get_All_project().DefaultView;
            txtid.Text = I.maxproject().Rows[0][0].ToString();
            Addbtn.IsEnabled = true;
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
        }

        private void project_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                Addbtn.IsEnabled = false;
                Deletebtn.IsEnabled = true;
                Updatebtn.IsEnabled = true;
            }
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                I.Updateproject(Convert.ToInt32(txtid.Text), txtname.Text);
                MessageBox.Show("Update Seccess", "Update Product ", MessageBoxButton.OK, MessageBoxImage.Information);
                txtid.Text = I.maxproject().Rows[0][0].ToString();
                txtname.Clear();
                projectdg.ItemsSource = I.Get_All_project().DefaultView;


                Addbtn.IsEnabled = true;
                Deletebtn.IsEnabled = false;
                Updatebtn.IsEnabled = false;
            }
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == "" || txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if (MessageBox.Show("Do you realy want to delete this Department ?", "Delete Department", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    I.Deleteproject(Convert.ToInt32(txtid.Text));
                    MessageBox.Show("Delete successful", "Delete Department", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtid.Text = I.maxproject().Rows[0][0].ToString();
                    txtname.Clear();
                    projectdg.ItemsSource = I.Get_All_project().DefaultView;
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

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtid.Text = I.maxproject().Rows[0][0].ToString();
            txtname.Clear();


            Addbtn.IsEnabled = true;
            Deletebtn.IsEnabled = false;
            Updatebtn.IsEnabled = false;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("You Cant do anything if the boxes are empty  ", "Warning  ", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {

                I.Addproject(Convert.ToInt32(txtid.Text), txtname.Text);
                MessageBox.Show("Add Seccess", "Add Product ", MessageBoxButton.OK, MessageBoxImage.Information);

                txtid.Text = I.maxproject().Rows[0][0].ToString();
                txtname.Clear();

                projectdg.ItemsSource = I.Get_All_project().DefaultView;



            }
        }
    }
}
