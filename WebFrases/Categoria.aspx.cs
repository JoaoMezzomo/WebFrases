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
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
          
        }

        private void AtualizaGrid()
        {
            GridView2.DataBind();
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            btSalvar.Text = "Inserir";
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                dalCategoria dal = new dalCategoria();
                categoria obj = new categoria();
                String msg = "";
                obj.nome = txtNome.Text;

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