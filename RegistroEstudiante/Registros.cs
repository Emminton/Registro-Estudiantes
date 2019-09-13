using RegistroEstudiante.BLL;
using RegistroEstudiante.Entidades;
using RegistroEstudiante.UI.Consultas;
using RegistroEstudiante.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiante
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegEstudiantes estu = new RegEstudiantes();

            estu.MdiParent = this;
            estu.Show();

        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Inscripcion inscrip = new Inscripcion();
            inscrip.MdiParent = this;
            inscrip.Show();
        }
    }
}

