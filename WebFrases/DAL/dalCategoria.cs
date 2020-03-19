using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebFrases.MODELO;

namespace WebFrases.DAL
{
    public class dalCategoria
    {
        public void Inserir(categoria obj)
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
                cmd.CommandText = "Insert into categorias (categoria) values (@categoria)";
                cmd.Parameters.AddWithValue("categoria", obj.nome);
                con.Open();
                obj.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
           
        }

        public void Alterar(categoria obj)
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
                cmd.CommandText = "update categorias set categoria = @categoria where id = @id;";
                cmd.Parameters.AddWithValue("categoria", obj.nome);
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
                cmd.CommandText = "delete from categorias where id = " + cod.ToString();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from categorias", connString.ConnectionString);
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
                SqlDataAdapter da = new SqlDataAdapter("select * from categorias where categoria like '%" + valor + "%'", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public categoria GetRegistro(int id)
        {
            categoria obj = new categoria();

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
                cmd.CommandText = "select * from categorias where id = @id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.id = Convert.ToInt32(registro["id"]);
                    obj.nome = Convert.ToString(registro["categoria"]);
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