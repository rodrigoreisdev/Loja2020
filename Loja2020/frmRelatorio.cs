using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace Loja2020
{
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
        }
        int i;
        Categoria ca = new Categoria();

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "Relatório de Categorias";
            pd.BeginPrint += Pd_BeginPrint;
            pd.PrintPage += Imprimir;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }
        private void Pd_BeginPrint (object sender, PrintEventArgs e)
        {
            i = 0;
        }
        private void Imprimir (object sender, PrintPageEventArgs ev)
        {
            //configurações da pagina

            float linhaPorPagina = 0;
            float posicaoVertical = 0;
            float contador = 0;
            float margemEsquerda = 20;
            float margemSuperior = 20;
            float alturaFonte = 0;
            string linha = "";

            Font fonte = new Font("Arial", 14);
            alturaFonte = fonte.GetHeight(ev.Graphics);
            linhaPorPagina = Convert.ToInt32(ev.MarginBounds.Height / alturaFonte);

            //Titulo
            linha = "Lista de Categorias";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

            //Subtitulo
            linha = "Código";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

            linha = "Categoria";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

            contador += 1;

            linha = "________________________________________________________________________";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

            contador++;

            DataSet ds = ca.ListarDados();

            if (ds.Tables[0] != null)
            {
                while (i < ds.Tables[0].Rows.Count && contador < linhaPorPagina)
                {
                    DataRow item = ds.Tables[0].Rows[i];

                    linha = item["idCategoria"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

                    linha = item["Categoria"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    contador += 2;
                    i++;
                }

                if (contador < linhaPorPagina)
                {
                    linha = "Total de Categorias: " + i.ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);
                }
            }
            else MessageBox.Show("Tabela vazia");

            if (contador > linhaPorPagina)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

        }
    }
}
