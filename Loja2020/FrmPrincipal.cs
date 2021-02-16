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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncluirCategoria F = new FrmIncluirCategoria();
            F.ShowDialog();
        }

        private void incluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProduto F = new FrmProduto();
            F.ShowDialog();
        }

        private void alterarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlterarExcluirCategoria F = new FrmAlterarExcluirCategoria();
            F.ShowDialog();
        }

        private void produtosPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsulta fc = new FrmConsulta();
            fc.ShowDialog();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio();
            frm.Show();
        }

        private void produtoPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioProdutoPorCategoria frm = new frmRelatorioProdutoPorCategoria();
            frm.Show();
        }
    }
}
