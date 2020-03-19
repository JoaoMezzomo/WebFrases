using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebFrases.MODELO;

namespace WebFrases.DAL
{
    public class dalFrases
    {
        public void Inserir(frase obj)
        {
            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            //Cria comando cmd sql	
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = con;
                cmd.CommandText = "Insert into frases (frase, autor, categoria) values (@frase, @autor, @categoria)";
                cmd.Parameters.AddWithValue("frase", obj.texto);
                cmd.Parameters.AddWithValue("autor", obj.autor);
                cmd.Parameters.AddWithValue("categoria", obj.categoria);
                con.Open();
                obj.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void Alterar(frase obj)
        {
            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            //Cria comando cmd sql	
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = con;
                cmd.CommandText = "update frases set frase = @frase, autor = @autor, categoria = @categoria where id = @id;";
                cmd.Parameters.AddWithValue("frase", obj.texto);
                cmd.Parameters.AddWithValue("autor", obj.autor);
                cmd.Parameters.AddWithValue("categoria", obj.categoria);
                cmd.Parameters.AddWithValue("id", obj.id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void Excluir(int cod)
        {
            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            //Cria comando cmd sql	
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = con;
                cmd.CommandText = "delete from frases where id = " + cod.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public DataTable Localizar()
        {
            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from frases", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public DataTable Localizar(String valor)
        {
            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from frases where frase like '%" + valor + "%'", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public frase GetRegistro(int id)
        {
            frase obj = new frase();

            //Capturar a String de Conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases1ConnectionString"];
            //Cria um Objeto de Conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            //Cria comando cmd sql	
            SqlCommand cmd = new SqlCommand();

            try
            {

                cmd.Connection = con;
                cmd.CommandText = "select * from frases where id = @id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.id = Convert.ToInt32(registro["id"]);
                    obj.texto = Convert.ToString(registro["texto"]);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
            return obj;
        }
    }
}