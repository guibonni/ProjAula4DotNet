using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula4
{
    public partial class CadastroEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            estado estado = new estado()
            {
                descricao = TxtDescricao.Text
            };

            bdaula4Entities context = new bdaula4Entities();

            context.estado.Add(estado);
            context.SaveChanges();

            LoadGrid();

            SendMessage("Registro inserido!");

            TxtDescricao.Text = "";
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void LoadGrid()
        {
            GVEstado.DataSource = new bdaula4Entities().estado.ToList<estado>();
            GVEstado.DataBind();
        }

        private void SendMessage(string message)
        {
            LblMsg.Text = message;
        }
    }
}