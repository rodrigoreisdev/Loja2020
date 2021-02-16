using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja2020
{
    class Categoria
    {
        private int idcategoria;
        private string nome;

        public int Idcategoria { get => idcategoria; set => idcategoria = value; }
        public string Nome { get => nome; set => nome = value; }

        ConexaoDados dados = new ConexaoDados();

        public void IncluirDados()
        {
            string sql = "";
            sql += "Insert into TabelaCategoria (Categoria) values ('" + Nome + "')";      
            dados.Incluir(sql);
        }

        public DataSet ListarDados()
        {
            string sql = "";
            sql = "Select * from TabelaCategoria";
            return dados.Listar(sql);
        }

        public void ConsultarDados()
        {
            string sql = "";
            sql += "Select Categoria from TabelaCategoria where idCategoria = " + Idcategoria.ToString();
            dados.Consultar(sql);
            string[] auxiliar = dados.Campos.Split(';');
            Nome = auxiliar[0];
        }

        public void AlterarDados()
        {
            string sql = "";
            sql += "Update TabelaCategoria SET Categoria = '" + Nome + "' Where idCategoria = " + Idcategoria.ToString();
            dados.Alterar(sql);
        }

        public void ExcluirDados()
        {
            string sql = "Delete from TabelaCategoria Where idCategoria = " + Idcategoria.ToString();
            dados.Excluir(sql);
        }
    }
}
