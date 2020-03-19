using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.MODELO;
using WebFrases.DAL;

namespace WebFrases
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Session["email"].ToString();

            if (email != "joao@decisionit.com.br")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                AtualizaGrid();
            }
            
        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            btSalvar.Text = "Inserir";
        }

        private void AtualizaGrid()
        {
            GridView2.DataBind();
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                dalUsuario dal = new dalUsuario();
                usuario obj = new usuario();
                String msg = "";
                obj.nome = txtNome.Text;
                obj.email = txtEmail.Text;
                obj.senha = txtSenha.Text;

                if (btSalvar.Text == "Inserir")
                {
                    dal.Inserir(obj);
                    msg = ("<script> alert('O código gerado foi: " + obj.id.ToString() + "')</script>");
                }
                else
                {
                    //alterar
                    obj.id = Convert.ToInt32(txtId.Text);
                    dal.Alterar(obj);
                    msg = ("<script> alert('Registro alterado corretamente!')</script>");
                }
                this.LimparCampos();
                AtualizaGrid();

            }
            catch (Exception erro)
            {

                Response.Write("<script> alert('" + erro.Message + "')</script>");
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }
    }
}