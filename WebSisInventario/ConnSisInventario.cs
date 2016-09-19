using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebSisInventario
{
    public class ConnSisInventario
    {

        //declaracion de variable de conexión:
        public SqlConnection con;
        public DataSet ds = new DataSet();
        public SqlDataAdapter da;
        public SqlCommand comando;
        public DataTable dt;


        //Método que manda a llamar a la cadena de conexion del web.Config:

        public void Conectar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["ConnSisInventario"].ConnectionString;
            con = new SqlConnection(cadena);

        }
             //Método constructos dela conexio:
        public ConnSisInventario()
        {
            Conectar();
        }


        public bool Consultar1(string tabla, string campo1, string campo2, string campo3, string campo4)
        {
            string sql = "Select * from " + tabla + " Where " + campo1 + " = '" + campo2 + "' and " + campo3 + " = '" + campo4 +"'";


            con.Open();

            da = new SqlDataAdapter(sql,con);
            dt = new DataTable();
            da.Fill(dt);

            con.Close();

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else

            {
                return false;
            }


        }

   }
}