using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Scon
    {
        private SqlConnection con = new SqlConnection("Data Source = JUBSWHOCODES\\SQLEXPRESS ; Initial Catalog = Academic; User ID = sa; Password = jrfami09");

        public SqlConnection GetCon()
        {
            return con;

        }

        public void DbOpen()
        {
            try
            {
                con.Open();
            }
            catch (Exception Erro)
            {                
                throw Erro;
            }



        }
        public void DbClose()
        {
            try
            {

                con.Close();
            }
            catch (Exception Erro)
            {
                throw Erro;
            }
            finally
            {
                con.Close();

            }


        }
    }
}
