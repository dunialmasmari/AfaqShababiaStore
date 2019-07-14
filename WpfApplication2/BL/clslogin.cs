using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication2.BL
{
    class clslogin
    {
        public DataTable LOGIN(string ID, string PWD)
        {
            DAL.DAL DAL = new DAL.DAL();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("loginpw", param);
            DAL.Close();
            return Dt;


        }
    }
}
