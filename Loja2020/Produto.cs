using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja2020
{
    class Produto
    {
        private int idproduto;
        private string nome;
        private float estoque;
        private string dataValidade;
        private int idcategoria;
        private float preco;
        private byte[] foto;

        public int Idproduto { get => idproduto; set => idproduto = value; }
        public string Nome { get => nome; set => nome = value; }
        public float Estoque { get => estoque; set => estoque = value; }
        public string DataValidade { get => dataValidade; set => dataValidade = value; }
        public int Idcategoria { get => idcategoria; set => idcategoria = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public float Preco { get => preco; set => preco = value; }

        ConexaoDados dados = new ConexaoDados();

        public void IncluirDados()
        {
            string sql = "";
            sql += "Insert into TabelaProduto (Produto,Estoque,DataValidade,idCategoria) values ('" + Nome + "'," + Estoque.ToString().Replace(",", ".") + ",'" + DataValidade + "'," + Idcategoria + "," + Preco.ToString().Replace(",", ".") + ")";
            dados.Incluir(sql);
        }
        public void IncluirDadosFoto()
        {
            string sql = "";
            sql += "Insert into TabelaProduto (Produto,Estoque,DataValidade,idCategoria,Preco,foto) values ('" + Nome + "'," + Estoque.ToString().Replace(",", ".") + ",'" + DataValidade + "'," + Idcategoria + "," + Preco.ToString().Replace(",",".") +",@BINARIO)"; 
            dados.ExecutarFoto(sql,Foto);
        }

        public void AlterarDados()
        {
            string sql = "";
            sql += "Update TabelaProduto SET Produto = '" + Nome + "', Estoque = " + Estoque.ToString().Replace(",", ".") + ", DataValidade = '"+DataValidade+ "' , idCategoria = "+ Idcategoria + ", Preco = "+ Preco.ToString().Replace(",", ".") +  " Where idProduto = " + Idproduto.ToString();
            dados.Alterar(sql);
        }

        public void AlterarDadosFoto()
        {
            string sql = "";
            sql += "Update TabelaProduto SET Produto = '" + Nome + "', Estoque = " + Estoque.ToString().Replace(",", ".") + ", DataValidade = '" + DataValidade + "' , idCategoria = " + Idcategoria + ", Preco = " + Preco.ToString().Replace(",", ".") + "Foto = @BINARIO" + " Where idProduto = " + Idproduto.ToString();
            dados.Alterar(sql);
        }
        public void ExcluirDados()
        {
            string sql = "Delete from TabelaProduto Where idProduto = " + Idproduto.ToString();
            dados.Excluir(sql);
        }
        public DataSet ListarDados()
        {
            string sql = "";
            sql = "select * from TabelaProduto where Produto LIKE '" + Nome + "%'";
            return dados.Listar(sql);
        }
        public DataSet ListarDadosProdutoPorCategoria()
        {
            string sql = "";
            sql = "select c.Categoria from TabelaCategoria c inner join TabelaProduto p on c.idCategoria = p.idCategoria where p.Produto LIKE '" + Nome + "%' Order by idCategoria";
            return dados.Listar(sql);
        }

        public DataSet ListarDadosPorIDCategoria()
        {
            string sql = "";
            sql = "select * from TabelaProduto where idCategoria = " + Idcategoria.ToString();
            return dados.Listar(sql);
        }
        public void ConsultarDados()
        {
            string sql = "";
            sql += "Select * from TabelaProduto where idProduto = " + Idproduto.ToString();
            dados.ConsultarFoto(sql, foto);
            string[] auxiliar = dados.Campos.Split(';');
            Nome = auxiliar[1];
            Estoque = float.Parse(auxiliar[2]);
            DataValidade = auxiliar[3];
            Idcategoria = int.Parse(auxiliar[4]);
        }

    }
}
