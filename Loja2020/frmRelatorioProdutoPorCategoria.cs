using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Loja2020
{
    public partial class frmRelatorioProdutoPorCategoria : Form
    {
        int i;
        Produto po = new Produto();
        float soma = 0;
        public frmRelatorioProdutoPorCategoria()
        {
            InitializeComponent();
        }

        private void frmRelatorioProdutoPorCategoria_Load(object sender, EventArgs e)
        {
           
        }
        

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

        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            i = 0;
        }
        private void Imprimir(object sender, PrintPageEventArgs ev)
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
            linha = "Lista de Produtos por Categorias";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);
            contador += 4;

            

            DataSet ds = po.ListarDadosProdutoPorCategoria();

            if (ds.Tables[0] != null)
            {
                while (i < ds.Tables[0].Rows.Count && contador < linhaPorPagina)
                {
                    DataRow item = ds.Tables[0].Rows[i];
                    
                    //Subtitulo
                    linha = "Código";
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

                    linha = "Categoria";
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    linha = "Produto";
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    linha = "Preço";
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    contador++;

                    //Dados
                    linha = item["idProduto"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda, posicaoVertical);

                    linha = item["Categoria"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    linha = item["Produto"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);

                    linha = item["Preco"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsquerda + 200, posicaoVertical);
                    soma += float.Parse(item["Preco"].ToString());

                    contador += 2;
                    i++;
                }

                if (contador < linhaPorPagina)
                {
                    linha = "Valor total: " + soma;
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
    }
}
