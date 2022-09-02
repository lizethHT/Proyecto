using Instituto.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instituto.AppWin
{
    public partial class frmInstitutoEdit : Form
    {
        Alumnos alumno;
        public frmInstitutoEdit( Alumnos alumnos)
        {
            InitializeComponent();
            this.alumno = alumnos;
        }

        private void frmInstitutoEdit_Load(object sender, EventArgs e)
        {
            if (alumno.ID > 0)
            {
                asignarControles();
            }
        }

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            this.alumno.Nombre = txtNombre.Text;
            this.alumno.Apellido = txtApellido.Text;
            this.alumno.Distrito = txtDistrito.Text;
            this.alumno.Fecha_Nacimiento = DateTime.Parse(txtFN.Text);
            this.alumno.DNI = int.Parse(txtDNI.Text);
            this.alumno.Celular = int.Parse(txtCelular.Text);
        }

        private void asignarControles()
        {
            txtNombre.Text = alumno.Nombre;
            txtApellido.Text = alumno.Apellido;
            txtDistrito.Text = alumno.Distrito;
            txtFN.Text = alumno.Fecha_Nacimiento.ToString();
            txtDNI.Text = alumno.DNI.ToString();
            txtCelular.Text = alumno.Celular.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
