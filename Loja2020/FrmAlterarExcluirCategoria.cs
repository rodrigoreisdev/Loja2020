using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja2020
{
    public partial class FrmAlterarExcluirCategoria : Form
    {
        public FrmAlterarExcluirCategoria()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();

        private void FrmAlterarExcluirCategoria_Load(object sender, EventArgs e)
        {
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DataSource = categoria.ListarDados().Tables[0];
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            cmdEditar.Enabled = false;
            cmdExcluir.Enabled = false;
            cmdAlterar.Enabled = true;

            txtCategoria.Enabled = true;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoria.Idcategoria = int.Parse(cmbCategoria.SelectedValue.ToString());

            categoria.ConsultarDados();

            txtCategoria.Text = categoria.Nome;
        }

        private void cmdAlterar_Click(object sender, EventArgs e)
        {
            categoria.Nome = txtCategoria.Text;
            categoria.AlterarDados();

            MessageBox.Show("Edição concluída");

            cmbCategoria.DataSource = categoria.ListarDados().Tables[0];

            cmdEditar.Enabled = true;
            cmdExcluir.Enabled = true;
            cmdAlterar.Enabled = false;
            txtCategoria.Enabled = false;
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            categoria.ExcluirDados();

            MessageBox.Show("Categoria excluida com sucesso");

            txtCategoria.Text = "";
            cmbCategoria.DataSource = categoria.ListarDados().Tables[0];
        }
    }
}
