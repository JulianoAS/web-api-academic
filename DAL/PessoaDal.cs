using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;


namespace DAL
{

    
    public class PessoaDal
    {
        Scon con = new Scon();

        public void Incluir(Pessoa pessoa)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            try
            {
                sql.Append("INSERT INTO tbPessoas(Nome) Values (@Nome)");
                cmd.CommandText = sql.ToString();
                cmd.Connection = con.GetCon();
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                con.DbOpen();
                cmd.ExecuteNonQuery();
            }
            catch (Exception Erro)
            {
                throw Erro;
            }
            finally
            {
                con.DbClose();
            }
        }

        public void Deletar(Pessoa pessoa)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            try
            {
                sql.Append("Delete FROM tbPessoas ");
                sql.Append("WHERE ID= @ID");
                cmd.CommandText = sql.ToString();
                cmd.Connection = con.GetCon();
                cmd.Parameters.AddWithValue("@ID", pessoa.Id);
                con.DbOpen();
                cmd.ExecuteNonQuery();
            }
            catch (Exception Erro)
            {
                throw Erro;
            }
            finally
            {
                con.DbClose();
            }
        }

        public void Atualizar(Pessoa pessoa)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            try
            {
                sql.Append("Update tbPessoas ");
                sql.Append("SET Nome =@Nome ");
                sql.Append("WHERE ID= @ID");
                cmd.CommandText = sql.ToString();
                cmd.Connection = con.GetCon();
                cmd.Parameters.AddWithValue("@ID", pessoa.Id);
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                con.DbOpen();
                cmd.ExecuteNonQuery();
            }
            catch (Exception Erro)
            {
                throw Erro;
            }
            finally
            {
                con.DbClose();
            }
        }


        public List<Pessoa> ListPessoa()
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();            
            SqlDataReader dr;
            List<Pessoa> listpessoa = new List<Pessoa>();

            try
            {
                sql.Append("SELECT Id,Nome FROM tbPessoas ");
                cmd.Connection = con.GetCon();
                cmd.CommandText = sql.ToString();
                con.DbOpen();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.Id = Convert.ToInt32(dr["Id"].ToString());
                    pessoa.Nome = dr["Nome"].ToString();
                    listpessoa.Add(pessoa);                    
                }
                dr.Close();               

                return listpessoa;

            }
            catch(Exception Erro)
            {
                throw Erro;

            }
            finally
            {
                con.DbClose();

            }


        }


        public void LerPessoa(Pessoa pessoa)
        {
            {
                StringBuilder sql = new StringBuilder();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
             

                try
                {
                    sql.Append("SELECT Id,Nome FROM tbPessoas ");
                    sql.Append("WHERE ID= @ID");
                    cmd.Connection = con.GetCon();
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", pessoa.Id);
                    con.DbOpen();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        pessoa.Id = Convert.ToInt32(dr["Id"].ToString());
                        pessoa.Nome = dr["Nome"].ToString();
                        
                    }
                    dr.Close();

                }
                catch (Exception Erro)
                {
                    throw Erro;

                }
                finally
                {
                    con.DbClose();

                }


            }
        }
    }
}
