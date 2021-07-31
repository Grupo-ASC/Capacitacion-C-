using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Capacitacion
{
    public partial class Form1 : Form
    {
        Conexion cn = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            insertarEmpleado();
            txtPuesto.Text = "";
            txtDepartamento.Text = "";
            txtNombre.Text = "";
        }
        //metodo para insertar.
        void insertarEmpleado()
        {
            try
            {
                string cadena = "INSERT INTO empleados (nombre_completo, puesto, departamento, estado) " +
                "VALUES ('" + txtNombre.Text + "', '" + txtPuesto.Text + "', '" + txtDepartamento.Text + "', '1');";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo " + Error);
            }          
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Ayudas-Capacitación/AyudasCapacitacion.chm", "Capacitacion-General.html");
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Reportes frm = new Reportes.Reportes();
            frm.Show();
        }
    }
}
