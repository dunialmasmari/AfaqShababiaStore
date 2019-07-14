using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication2.BL
{
    class clsemp
    {
        public void Addadmin(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@empadminno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@empadminname", SqlDbType.NVarChar, 25);
            param[1].Value = Name;



            DAL.ExecuteCommand("Add_empadmin", param);
            DAL.Close();





        }
        public void Updateadmin(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@empadminno", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@empadminname", SqlDbType.NVarChar, 25);
            param[1].Value = Name;



            DAL.ExecuteCommand("Update_empadmin", param);
            DAL.Close();





        }
        public void Deleteadmin(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("DeleteEmpadmin", param);
            DAL.Close();

        }
        public DataTable maxadmin()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_adminstration", null);
            DAL.Close();
            return Dt;

        }
           public DataTable Get_All_admin()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_empadmin", null);
            DAL.Close();
            return Dt;


     
    }



        public void Addposition(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@empposition_no", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@empposition_name", SqlDbType.NVarChar, 25);
            param[1].Value = Name;



            DAL.ExecuteCommand("Add_empposition", param);
            DAL.Close();





        }
        public void Updateposition(int ID, string Name)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@empposition_no", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@empposition_name", SqlDbType.NVarChar, 25);
            param[1].Value = Name;



            DAL.ExecuteCommand("Update_empposition", param);
            DAL.Close();





        }
        public void Deleteposition(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("DeleteEmpposition", param);
            DAL.Close();

        }
        public DataTable maxposition()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_position", null);
            DAL.Close();
            return Dt;

        }
        public DataTable Get_All_position()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_Empposition", null);
            DAL.Close();
            return Dt;


        }


        public void Addemp(int ID, string Name ,int position , int admin)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@EmpID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@EmpName", SqlDbType.NVarChar, 50);
            param[1].Value = Name;

            param[2] = new SqlParameter("@EmppositionID", SqlDbType.Int);
            param[2].Value = position;

            param[3] = new SqlParameter("@EmpadminID", SqlDbType.Int);
            param[3].Value = admin;




            DAL.ExecuteCommand("Add_Employee", param);
            DAL.Close();





        }
        public void Updatemp(int ID, string Name, int position, int admin)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@EmpID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@EmpName", SqlDbType.NVarChar, 50);
            param[1].Value = Name;

            param[2] = new SqlParameter("@EmppositionID", SqlDbType.Int);
            param[2].Value = position;

            param[3] = new SqlParameter("@EmpadminID", SqlDbType.Int);
            param[3].Value = admin;



            DAL.ExecuteCommand("Update_Employee", param);
            DAL.Close();





        }

        public void Deletemp(int ID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            DAL.ExecuteCommand("DeleteEmployee", param);
            DAL.Close();

        }
        public DataTable maxemp()
        {

            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Max_emp", null);
            DAL.Close();
            return Dt;

        }
              public DataTable Get_All_emp()
        {
            DAL.DAL DAL = new DAL.DAL();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_All_employee", null);
            DAL.Close();
            return Dt;


       
    }

              public void Adduser(int ID, string Name, string pw,int autho)
              {
                  DAL.DAL DAL = new DAL.DAL();
                  DAL.Open();
                  SqlParameter[] param = new SqlParameter[4];
                  param[0] = new SqlParameter("@UserID", SqlDbType.Int);
                  param[0].Value = ID;

                  param[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                  param[1].Value = Name;

                  param[2] = new SqlParameter("@UserPsw", SqlDbType.NVarChar, 10);   
                  param[2].Value = pw;

                  param[3] = new SqlParameter("@Autho_typno", SqlDbType.Int);
                  param[3].Value = autho;

                  
          
                  DAL.ExecuteCommand("Add_User", param);
                  DAL.Close();





              }
              public void Updateuser(int ID, string Name, string pw, int autho)
              {
                  DAL.DAL DAL = new DAL.DAL();
                  DAL.Open();
                  SqlParameter[] param = new SqlParameter[4];
                  param[0] = new SqlParameter("@UserID", SqlDbType.Int);
                  param[0].Value = ID;

                  param[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                  param[1].Value = Name;

                  param[2] = new SqlParameter("@UserPsw", SqlDbType.NVarChar, 10);
                  param[2].Value = pw;

                  param[3] = new SqlParameter("@Autho_typno", SqlDbType.Int);
                  param[3].Value = autho;



                  DAL.ExecuteCommand("Update_users", param);
                  DAL.Close();





              }
              public void Deleteuser(int ID)
              {
                  DAL.DAL DAL = new DAL.DAL();
                  DAL.Open();
                  SqlParameter[] param = new SqlParameter[1];
                  param[0] = new SqlParameter("@ID", SqlDbType.Int);
                  param[0].Value = ID;

                  DAL.ExecuteCommand("Deleteusers", param);
                  DAL.Close();

              }
              public DataTable maxuser()
              {

                  DAL.DAL DAL = new DAL.DAL();

                  DataTable Dt = new DataTable();
                  Dt = DAL.SelectData("Max_user", null);
                  DAL.Close();
                  return Dt;

              }
              public DataTable Get_All_user()
              {
                  DAL.DAL DAL = new DAL.DAL();

                  DataTable Dt = new DataTable();
                  Dt = DAL.SelectData("Get_All_users", null);
                  DAL.Close();
                  return Dt;



              }
              public DataTable Get_All_autho()
              {
                  DAL.DAL DAL = new DAL.DAL();

                  DataTable Dt = new DataTable();
                  Dt = DAL.SelectData("Get_All_Autho", null);
                  DAL.Close();
                  return Dt;



              }
    }
}
