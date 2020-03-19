using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebFrases.MODELO;

namespace WebFrases.DAL
{
    public class dalUsuario
    {
        public void Inserir(usuario obj)
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
                cmd.CommandText = "Insert into usuarios (nome, email, senha) values (@nome, @email, @senha)";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("email", obj.email);
                cmd.Parameters.AddWithValue("senha", obj.senha);
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

        public void Alterar(usuario obj)
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
                cmd.CommandText = "update usuarios set nome = @nome, email = @email, senha = @senha where id = @id;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("email", obj.email);
                cmd.Parameters.AddWithValue("senha", obj.senha);
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
                cmd.CommandText = "delete from usuarios where id = " + cod.ToString();
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
                SqlDataAdapter da = new SqlDataAdapter("select * from usuarios", connString.ConnectionString);
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
                SqlDataAdapter da = new SqlDataAdapter("select * from usuarios where nome like '%" + valor + "%'", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public usuario GetRegistro(int id)
        {
            usuario obj = new usuario();

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
                cmd.CommandText = "select * from usuario where id = @id";
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.id = Convert.ToInt32(registro["id"]);
                    obj.nome = Convert.ToString(registro["nome"]);
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

        public void Login(usuario obj)
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

            cmd.Connection = con;
            cmd.CommandText = "select * from usuarios where email = @email and senha = @senha";
            cmd.Parameters.AddWithValue("email", obj.email);
            cmd.Parameters.AddWithValue("senha", obj.senha);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                obj.email = Convert.ToString(registro["email"]);
                obj.senha = Convert.ToString(registro["senha"]);
            }
            else
            {
                obj.email = "erroerroerroerroerroerroerroerro";
                obj.senha = "erroerrerroerroeroerrororeroerro";
            }
        }
    }
}