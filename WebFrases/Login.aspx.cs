using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using WebFrases.DAL;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Label6.Visible = false;
        }

        private void LimparCampos()
        {
            txcNome.Text = "";
            txcEmail.Text = "";
            txcSenha.Text = "";
            txbEmail.Text = "";
            txbSenha.Text = "";
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            usuario obj = new usuario();
            dalUsuario dal = new dalUsuario();
            Boolean lo = false;
            obj.email = txbEmail.Text;
            obj.senha = txbSenha.Text;
            dal.Login(obj);

            String email = txbEmail.Text;
            String senha = txbSenha.Text;

            if (email == obj.email && senha == obj.senha)
            {
                Session["email"] = email;
                Session["senha"] = senha;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label6.Visible = true;
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            txcEmail.Text = txbEmail.Text;
            txcSenha.Text = txbSenha.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                dalUsuario dal = new dalUsuario();
                usuario obj = new usuario();

                obj.nome = txcNome.Text;
                obj.email = txcEmail.Text;
                obj.senha = txcSenha.Text;

                dal.Inserir(obj);
                
 
            }
            catch (Exception erro)
            {

                Response.Write("<script> alert('" + erro.Message + "')</script>");
            }

            this.LimparCampos();
            Panel2.Visible = false;
            Panel1.Visible = true;
        }
    }
}