using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication2.BL
{
    class items
    {

        public void Addcategory(int ID, string Name, string abb)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@categoryno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@categoryname", SqlDbType.NVarChar, 50);
            param[1].Value = Name;


            param[2] = new SqlParameter("@abbreviation", SqlDbType.NVarChar, 10);
            param[2].Value = abb;
           
            DAL.ExecuteCommand("Add_category", param);
            DAL.Close();





        }
        public void Updatecategory(int ID, string Name, string abb)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@categoryno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@categoryname", SqlDbType.NVarChar, 50);
            param[1].Value = Name;


            param[2] = new SqlParameter("@abbreviation", SqlDbType.NVarChar, 10);
            param[2].Value = abb;


            DAL.ExecuteCommand("Update_category", param);
            DAL.Close();





        }
        public void Deletecategory(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("Deletecategory", param);
            DAL.Close();

        }
        public DataTable maxcategory()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_category", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_category()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_Category", null);
            DAL.Close();
            return Dt;



        }


        public void Addstore(int ID, string Name,string loc)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@storeno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@storename", SqlDbType.NVarChar, 25);
            param[1].Value = Name;

             param[2] = new SqlParameter("@storeloc", SqlDbType.NVarChar, 50);
            param[2].Value = loc;




            DAL.ExecuteCommand("Add_store", param);
            DAL.Close();





        }
        public void Updatestore(int ID, string Name, string loc)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@storeno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@storename", SqlDbType.NVarChar, 25);
            param[1].Value = Name;

            param[2] = new SqlParameter("@storeloc", SqlDbType.NVarChar, 50);
            param[2].Value = loc;



            DAL.ExecuteCommand("Update_store", param);
            DAL.Close();





        }
        public void Deletestore(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("Deletestore", param);
            DAL.Close();

        }
        public DataTable maxstore()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_store", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_store()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_store", null);
            DAL.Close();
            return Dt;



        }


        public void Addunit(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@unitno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@unitname", SqlDbType.NVarChar, 20);
            param[1].Value = Name;




            DAL.ExecuteCommand("Add_unit", param);
            DAL.Close();





        }
        public void Updateunit(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@unitno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@unitname", SqlDbType.NVarChar, 20);
            param[1].Value = Name;



            DAL.ExecuteCommand("Update_unit", param);
            DAL.Close();





        }
        public void Deleteunit(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("Deleteunit", param);
            DAL.Close();

        }
        public DataTable maxunit()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_unit", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_unit()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_unit", null);
            DAL.Close();
            return Dt;



        }


        public void Addproject(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@projectno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@projectname", SqlDbType.NVarChar, 25);
            param[1].Value = Name;




            DAL.ExecuteCommand("Add_project", param);
            DAL.Close();





        }
        public void Updateproject(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@projectno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@projectname", SqlDbType.NVarChar, 25);
            param[1].Value = Name;



            DAL.ExecuteCommand("Update_project", param);
            DAL.Close();





        }
        public void Deleteproject(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("Deleteproject", param);
            DAL.Close();

        }
        public DataTable maxproject()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_project", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_project()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_project", null);
            DAL.Close();
            return Dt;



        }


        public void Additem(string ID, string Name, int Min, int Catno)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@item_no", SqlDbType.NVarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@item_name", SqlDbType.NVarChar, 50);
            param[1].Value = Name;

            param[2] = new SqlParameter("@item_min", SqlDbType.Int);
            param[2].Value = Min;
            param[3] = new SqlParameter("@categoryno", SqlDbType.Int);
            param[3].Value = Catno;

            DAL.ExecuteCommand("Add_item", param);
            DAL.Close();





        }
        public void Updateitem(string ID, string Name, int Min, int Catno)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@item_no", SqlDbType.NVarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@item_name", SqlDbType.NVarChar, 50);
            param[1].Value = Name;

            param[2] = new SqlParameter("@item_min", SqlDbType.Int);
            param[2].Value = Min;
            param[3] = new SqlParameter("@categoryno", SqlDbType.Int);
            param[3].Value = Catno;

            DAL.ExecuteCommand("Update_item", param);
            DAL.Close();

        }
        public void Deleteitem(string ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar ,50);
            param[0].Value = ID;

            DAL.ExecuteCommand("Deleteitem", param);
            DAL.Close();

        }
        public DataTable maxitem(int catid)
        {

            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@catno", SqlDbType.Int);
            param[0].Value = catid;


            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_item", param);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_items()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_items", null);
            DAL.Close();
            return Dt;



        }
    }
}
