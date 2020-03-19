using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.DAL;
using WebFrases.MODELO;

namespace WebFrases
{
    public partial class Frase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            GridView2.DataBind();
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtFrase.Text = "";
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                dalFrases dal = new dalFrases();
                frase obj = new frase();

                obj.texto = txtFrase.Text;
                obj.autor = Convert.ToInt32(ddlAutor.SelectedValue);
                obj.categoria = Convert.ToInt32(ddlCategoria.SelectedValue);

                dal.Inserir(obj);
               
                
                AtualizaGrid();

            }
            catch (Exception erro)
            {

                Response.Write("<script> alert('" + erro.Message + "')</script>");
            }

            this.LimparCampos();
        }
    }
}