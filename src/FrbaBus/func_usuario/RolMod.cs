﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.func_usuario
{
    public partial class RolMod : Form
    {
        public string nombre;

        public RolMod()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RolMod_Load(object sender, EventArgs e)
        {
            Formularios Func = new Formularios();
            this.textBox1.Text = this.nombre;
            DataSet RolxFunc_Lista = Func.RolxFunc(this.textBox1.Text);
            dataGridView1.DataSource = RolxFunc_Lista.Tables[0].DefaultView;


        }
    }
}
