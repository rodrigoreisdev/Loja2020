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
    public partial class FrmLocalizarProduto : Form
    {
        public FrmLocalizarProduto()
        {
            InitializeComponent();
        }

        private Produto produto = new Produto();
        public int id;
        private void FrmLocalizarProduto_Load(object sender, EventArgs e)
        {
            produto.Nome = "";
            dataGridView1.DataSource = produto.ListarDados().Tables[0];
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Rows[0].Selected = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            produto.Nome = txtPesquisa.Text;
            dataGridView1.DataSource = produto.ListarDados().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
