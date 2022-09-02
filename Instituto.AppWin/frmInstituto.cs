using Instituto.Dominio;
using Instituto.Logic;
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
    public partial class frmInstituto : Form
    {
        public frmInstituto()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        public void cargarDatos()
        {
            var listado = AlumnoBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var alumnos in listado)
            {
                dgvListado.Rows.Add(alumnos.ID, alumnos.Nombre, alumnos.Apellido, alumnos.Distrito,
                    alumnos.Fecha_Nacimiento, alumnos.DNI, alumnos.Celular);
            }
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoAlumno = new Alumnos();
            var frm = new frmInstitutoEdit(nuevoAlumno);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = AlumnoBL.Insertar(nuevoAlumno);
                if (exito)
                {
                    MessageBox.Show("El alumno a sido registrado", "Instituto", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    cargarDatos();

                }
                else
                {
                    MessageBox.Show("No se ha podido registrar al alumno", "Instituto", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }

        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var Id = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var AlumnoEditar = AlumnoBL.BuscarPorId(Id);
                var frm = new frmInstitutoEdit(AlumnoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = AlumnoBL.Actualizar(AlumnoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El Alumno ha sido actualizado", "Instituto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido actualizado", "Instituto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void eliminarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var Id = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("Realmente desea eliminar " + nombreProducto + "?",
                    "Instituto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = AlumnoBL.Eliminar(Id);
                    if (exito)
                    {
                        MessageBox.Show("El alumno ha sido eliminado", "Instituto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar", "Instituto",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
