using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace Loja2020
{
    class ConexaoDados
    {
        private string campos;
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cd = new SqlCommand();

        public string Campos { get => campos; set => campos = value; }

        private void Conectar()
        {
            string s = "";
            s = @"Server=.\SQLEXPRESS;Database=Loja2020;UID=sa;PWD=123456;";
            cn.ConnectionString = s;
            cn.Open();
        }

        public void Incluir(string sql)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;
            cd.ExecuteNonQuery();
            cn.Close();
        }
        public void ExecutarFoto(string sql, byte[] parametroFoto)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;
            cd.Parameters.Clear();
            cd.Parameters.Add("@BINARIO", SqlDbType.Image);
            if(parametroFoto==null)
            {
                cd.Parameters["@BINARIO"].Value = SqlBinary.Null;
            }
            cd.Parameters["@BINARIO"].Value = parametroFoto;
            cd.ExecuteNonQuery();
            cn.Close();
        }

        public void Alterar(string sql)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;
            cd.ExecuteNonQuery();
            cn.Close();
        }

        public void Excluir(string sql)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;
            cd.ExecuteNonQuery();
            cn.Close();
        }

        public void Consultar(string sql)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;

            SqlDataReader dr = cd.ExecuteReader();

            campos = "";

            if (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Campos += dr[i].ToString() + ";";
                }

            }


            cn.Close();
        }

        public void ConsultarFoto(string sql, byte[] ParametroFoto)
        {
            Conectar();
            cd.Connection = cn;
            cd.CommandText = sql;
            SqlDataReader dr = cd.ExecuteReader();

            campos = "";

            if (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Campos += dr[i].ToString() + ";";
                }

            }


            cn.Close();
        }

        public void FecharConexao()
        {
            cn.Close();
        }

        public DataSet Listar(string sql)
        {
            Conectar();

            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            cn.Close();
            return ds;
        }
    }
}
