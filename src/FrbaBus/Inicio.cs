﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Compra_de_Pasajes.Buscar_viaje Comprar = new Compra_de_Pasajes.Buscar_viaje();
            Comprar.MdiParent = this;
            Comprar.admin = false;
            Comprar.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
              Login.Login_usu login = new Login.Login_usu();
              login.MdiParent = this;
            login.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canje_de_Ptos.canje canje = new Canje_de_Ptos.canje();
            canje.MdiParent = this;
            canje.Show();
        }
    }
}
