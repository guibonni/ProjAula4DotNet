using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula4
{
    public partial class CadastroCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDDLEstado();
                LoadGrid();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            int idEstado = int.Parse(DDLEstado.SelectedValue.ToString());

            bdaula4Entities context = new bdaula4Entities();

            cidade cidade = new cidade()
            {
                descricao = TxtDescricao.Text,
                estado = context.estado.First<estado>(v => v.id == idEstado)
            };

            context.cidade.Add(cidade);
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
            bdaula4Entities context = new bdaula4Entities();

            var dados = (from c in context.cidade
                         from e in context.estado.Where(x => x.id == c.idEstado)
                         select new
                         {
                             Id = c.id,
                             Nome = c.descricao,
                             Estado = e.descricao
                         }).ToList();

            GVCidade.DataSource = dados;
            GVCidade.DataBind();
        }

        private void LoadDDLEstado()
        {
            DDLEstado.DataSource = new bdaula4Entities().estado.ToList<estado>();
            DDLEstado.DataValueField = "id";
            DDLEstado.DataTextField = "descricao";
            DDLEstado.DataBind();
        }

        private void SendMessage(string message)
        {
            LblMsg.Text = message;
        }
    }
}