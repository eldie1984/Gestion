﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaBus
{
    class Usuarios:conexion
    {
        private string usuario;
        private string contraseña;

        public Usuarios()
        {
            usuario = string.Empty;
            contraseña = string.Empty;
            this.sql = string.Empty;
        }
        public string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Contraseña
        {
            get {return this.contraseña; }
            set { this.contraseña = value; }
        }
        public bool Buscar()
        {
            bool Resultado = false;
            
            this.sql = string.Format(@"select usua_logins from transportados.usuario where usua_username='{0}' and usua_password = '{1}'", this.usuario, this.contraseña);
            this.comandosSql = new SqlCommand(this.sql,this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            if (Reg.Read())
            {
                if (Convert.ToInt32(Reg[0]) < 3)
                {
                    Resultado = true;
                    this.mensaje = "Bienvenido Datos correctos";
                }
                else
                {
                    this.mensaje = "Usuario Inhabilitado";
                }
            }
            else
            {
                
                this.mensaje= "Usuario/Contraseña invalidos";
            }
            this.cnn.Close();        
            return Resultado;
        }
        public bool fail_login()
        {
            bool Resultado = false;
            Int32 result = 0;
            this.sql = string.Format(@"update transportados.usuario
                                       set usua_logins=usua_logins+1
                                           where usua_username= '{0}'", this.usuario);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            result = this.comandosSql.ExecuteNonQuery();
            if (result > 0)
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }
            this.cnn.Close();
            return Resultado;
        }
        public bool reset_login()
        {
            bool Resultado = false;
            Int32 result = 0;
            this.sql = string.Format(@"update transportados.usuario
                                       set usua_logins=0
                                           where usua_username= '{0}'", this.usuario);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            result = this.comandosSql.ExecuteNonQuery();
            if (result > 0)
            {
                Resultado = true;
            }
            else
            {
                Resultado = false;
            }
            this.cnn.Close();
            return Resultado;
        }
            
    }
}
