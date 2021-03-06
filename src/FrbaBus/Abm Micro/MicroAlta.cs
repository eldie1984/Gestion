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
    public partial class MicroAlta : Form
    {
        public string cadenaConexion;
        protected string sql;
        protected Int32 resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;
        protected string mensaje;

        public static MicroAlta Malta;
        public MicroAlta()
        {
            InitializeComponent();
            MicroAlta.Malta = this;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            funciones patente = new funciones();
            if (!patente.noExistePatente(patenteBox.Text))
            {
                MessageBox.Show("La patente ingresada ya existe!");
            }
            else
            {
                bool res = patente.insertar_micro(servicioCombo.Text, Convert.ToInt32(butacaCombo.Value), Convert.ToInt32(kgText.Text), marcaCombo.Text, modeloBox.Text, patenteBox.Text, Convert.ToInt32(textBox1.Text));
                if (res)
                    this.mensaje = "Datos correctos";
                else
                    this.mensaje = "Mmmm Lo siento, no se pudo crear el micro";

                MessageBox.Show(mensaje);
            }

        }

        
        private void MicroAlta_Load(object sender, EventArgs e)
        {
            llenacombobox();
        }

         public void llenacombobox()
        {
            Formularios combos = new Formularios();
            DataSet servicio = combos.llenaComboboxTipo();
            //DataSet modelo = combos.llenaComboboxModelo();
            DataSet marca = combos.llenaComboboxMarca();
            //da.Fill(ds_origen, "Ciudad");
            marcaCombo.DataSource = marca.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            marcaCombo.DisplayMember = "micr_marca";
            marcaCombo.ValueMember = "micr_marca";
            
            servicioCombo.DataSource = servicio.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            servicioCombo.DisplayMember = "tipo_nombre";
            servicioCombo.ValueMember = "tipo_id";
            //Int32 value = ((KeyValuePair<string, int>)comboBox1.SelectedItem).Value;
            //MessageBox.Show(value.ToString());

        }

    }
}
