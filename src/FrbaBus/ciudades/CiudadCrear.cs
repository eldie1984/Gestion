﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.ciudades
{
    public partial class CiudadCrear : Form
    {
        public CiudadCrear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result;
            funciones dataCiudad = new funciones();
            result = dataCiudad.insertarCiudad(this.textBox1.Text);
            if (result == true)
            {
                MessageBox.Show("Ciudad Creada correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}