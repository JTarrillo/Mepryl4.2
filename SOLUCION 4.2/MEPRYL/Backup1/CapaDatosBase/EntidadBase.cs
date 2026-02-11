using System;
using System.Collections.Generic;
using System.Text;
using Comunes;
using System.Data.SqlClient;
using System.Reflection;

namespace CapaDatosBase
{
    public class EntidadBase
    {
        public Guid id = new Guid(Utilidades.ID_VACIO);
        public string codigo = "";
        public string EntidadNombre = "";
        public Dictionary<string, object> campos = new Dictionary<string, object>();

        public EntidadBase()
        { }
        public EntidadBase(string entNombre)
        {
            this.EntidadNombre = entNombre;
        }

        public string getRegistroBLOB()
        {
            string resultado = "";
            try
            {
                FieldInfo[] atributos = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

                foreach (FieldInfo f in atributos)
                {
                    //Si los atributos tienen el mismo nombre y mismo tipo.
                    if (f.FieldType.Name=="String")
                    {
                        resultado += " " + f.GetValue(this);
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return resultado;
        }
    }
}
