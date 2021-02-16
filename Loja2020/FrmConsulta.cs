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
    public partial class FrmConsulta : Form
    {
        public FrmConsulta()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();
        Produto produto = new Produto();

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            categoria.Nome = "";
            dataGridView1.DataSource = categoria.ListarDados().Tables[0];
            produto.Idcategoria = int.Parse(dataGridView1.Rows[0].Cells[0].Value.ToString());
            dataGridView2.DataSource = produto.ListarDadosPorIDCategoria().Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Rows[0].Selected = true;

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Rows[0].Selected = true;

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() !="")
            {
            produto.Idcategoria = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            dataGridView2.DataSource = produto.ListarDadosPorIDCategoria().Tables[0];
            }
        }
    }
}
