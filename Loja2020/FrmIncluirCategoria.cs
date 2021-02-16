﻿using System;
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
    public partial class FrmIncluirCategoria : Form
    {
        public FrmIncluirCategoria()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();

        private void cmdIncluir_Click(object sender, EventArgs e)
        {
            categoria.Nome = txtNome.Text;
            
            categoria.IncluirDados();

            MessageBox.Show("Registro incluido com sucesso");

            txtNome.Clear();
        }
    }
}
