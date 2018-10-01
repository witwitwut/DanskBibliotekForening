using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IO
{
    public class ClassDB
    {
        private SqlConnection myConnection;
        
        public ClassDB()
        {

        }
        public ClassDB(string inConString)
        {
            SetCon(inConString);
        }
        protected void SetCon(string strCon)
        {
            myConnection = new SqlConnection(strCon);
        }


        protected void OpenDB()
        {
            try
            {
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                else
                {
                    if (myConnection == null)
                    {
                        MessageBox.Show("Der er ikke oprettet nogen 'Connectionstring'");
                    }
                    else
                    {
                        CloseDB();
                        OpenDB();
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }        
        protected void CloseDB()
        {
            try
            {
                myConnection.Close();
            }
            catch (SqlException)
            {

                throw;
            }
        }

        protected void FunctionExecuteNonQuery(string strSql)
        {
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    com.ExecuteNonQuery();
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        protected DataTable DbReturnDataTable(string strsql)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strsql, myConnection))
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    OpenDB();
                    da.Fill(dtRes);                    
                }
                CloseDB();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dtRes;
        }
        protected string DbReturnString(string strSql)
        {
            string res = "";
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        res = reader.GetValue(0).ToString();
                    }
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;
        }

        protected List<string> DbReturnListString(string strSql)
        {
            List<string> ListRes = new List<string>();

            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    com.CommandText = strSql;
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ListRes.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                }
                CloseDB();
            }
            catch (SqlException)
            {

                throw;
            }
            return ListRes;
        }

        protected bool DbReturnBool(string strSql)
        {
            bool res = false;
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        res = Convert.ToBoolean(reader.GetValue(0).ToString());
                    }
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;
        }
    }
}
