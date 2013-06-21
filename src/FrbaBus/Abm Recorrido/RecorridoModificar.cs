﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class RecorridoModificar : Form
    {

        public string CiudOrig;
        public string CiudDest;
        public string RecoBaja;
        public Int32 Reco_id;
        public RecorridoModificar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            funciones ModCiti = new funciones();
            /*if (this.textBox1.Text != CiudNombre)
            {
                citiExist = ModCiti.CheckCity(this.textBox1.Text);
            }*/
            if (this.checkBox1.Checked)
            {
                ModCiti.ModifyReco(Reco_id, 1);
                MessageBox.Show("Ciudad dada de baja correctamente", "Modicar ciudad");
                this.Close();
            }
            else
            {
                ModCiti.ModifyReco(Reco_id, 0);
                MessageBox.Show("Ciudad modificada correctamente", "Modicar ciudad");
                this.Close();
            }


        }

        private void RecorridoModificar_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = CiudOrig;
            this.textBox2.Text = CiudDest;
            if (RecoBaja == "SI")
            {
                this.checkBox1.Checked = true;
            }
        }
    }
}
