﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaBus.Abm_Micro
{
    public partial class MicroFormBaja : Form
    {
        public static MicroFormBaja f1;
        public MicroFormBaja()
        {
            InitializeComponent();

            MicroFormBaja.f1 = this;
        }
        public DateTimePicker inicio
        {
            get
            {
                return dateTimePicker1;
            }
        }
        public DateTimePicker fin
        {
            get
            {
                return dateTimePicker2;
            }
        }

        private void MicroFormBaja_Load(object sender, EventArgs e)
        {
            llenacombobox();
            this.textBox1.Text = modificacion.f1.TextBox1.Text;
        }
        public void llenacombobox()
        {
             var tipoBaja = new[] { "Fuera de servicio", "Fin vida útil"};
            comboBox1.DataSource = tipoBaja;
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            funciones pasajes = new funciones();
            if (pasajes.contarPasajesVendidos(dateTimePicker1.Value, dateTimePicker2.Value, this.textBox1.Text) == 0)
                /*el micro no tiene pasajes vendidos asique todo ok*/
            {
                MessageBox.Show("Micro sin viajes asignados");
                
            }
            else
                /*preguntar si se cancelan los viajes existentes o se busca un micro sustituto*/
            {
                Abm_Micro.buscaMicro buscarMicro = new Abm_Micro.buscaMicro();
                buscarMicro.MdiParent = this;
                buscarMicro.Show();
            }
                        
            if (comboBox1.SelectedText == "Fuera de servicio")
                pasajes.bajaServicioMicro(dateTimePicker1.Value, this.textBox1.Text);
            else
                pasajes.bajaTecnicaMicro(dateTimePicker1.Value, dateTimePicker2.Value, this.textBox1.Text);
        }

    }
}