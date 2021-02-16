using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Loja2020
{
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();
        Produto produto = new Produto();
        private int codigo;
        private string status = "Navegando";

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DataSource = categoria.ListarDados().Tables[0];

            status = "Navegando";
            HabilitaControle();
            
        }

        private void HabilitaControle()
        {
            cmdNovo.Enabled = (status == "Navegando");
            cmdLocalizar.Enabled = (status == "Navegando");
            cmdSalvar.Enabled = (status == "Editando" || status == "Inserindo");
            cmdExcluir.Enabled = (status == "Editando");

            if (status == "Inserindo" || status == "Editando")
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox)
                        ctr.Enabled = true;

                    if (ctr is ComboBox)
                        ctr.Enabled = true;

                    if (ctr is DateTimePicker)
                        ctr.Enabled = true;
                }
            }
            else
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is TextBox)
                        ctr.Enabled = false;
                    if (ctr is ComboBox)
                        ctr.Enabled = false;
                    if (ctr is DateTimePicker)
                        ctr.Enabled = false;
                }
            }
        }

        private void LimpaControle()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }
        }
        private void cmdNovo_Click(object sender, EventArgs e)
        {
            LimpaControle();
            status = "Inserindo";
            HabilitaControle();
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigo = int.Parse(cmbCategoria.SelectedValue.ToString());
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            produto.Nome = txtNome.Text;
            produto.Estoque = float.Parse(txtEstoque.Text);
            produto.DataValidade = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            produto.Idcategoria = codigo;
            if (txtPreco.Text != "")
                produto.Preco = float.Parse(txtPreco.Text);
            else
                produto.Preco = 0;

            if (status == "Inserindo")
            {
                produto.IncluirDadosFoto();
                MessageBox.Show("Registro incluido com sucesso!!!");
            }
            if (status == "Editando")
            {
                produto.AlterarDadosFoto();
                MessageBox.Show("Registro alterado com sucesso!!!");
            }

            status = "Navegando";
            HabilitaControle();

        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja excluir esse registro?", "Alerta", MessageBoxButtons.YesNo))
            {
                if (status == "Editando")
                {
                    produto.Idcategoria = codigo;
                    produto.ExcluirDados();
                    MessageBox.Show("Excluido com sucesso!!!");
                    LimpaControle();
                    status = "Navegando";
                    HabilitaControle();
                }
            }
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarProduto f = new FrmLocalizarProduto();
            f.ShowDialog();
            produto.Idproduto = f.id;
            produto.ConsultarDados();
            txtNome.Text = produto.Nome;
            txtEstoque.Text = produto.Estoque.ToString();
            dateTimePicker1.Text = produto.DataValidade;

            categoria.Idcategoria = produto.Idcategoria;
            categoria.ConsultarDados();
            cmbCategoria.Text = categoria.Nome;
            if(!(produto.Foto is null))
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(produto.Foto, 0, produto.Foto.Length);
                pictureBox1.Image = Image.FromStream(ms);
            }
            status = "Editando";
            HabilitaControle();
        }

        private void cmdImagem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(nome);
                ConverteFoto();
                status = "Inserindo";
            }
        }
        private void ConverteFoto()
        {
            if(pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] foto_array = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(foto_array, 0, foto_array.Length);
                produto.Foto = foto_array;
            }
        }
    }
}
