using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEstudiante.UI.Consultas
{
    public partial class ConsultarEstudiante : Form
    {
        public ConsultarEstudiante()
        {
            InitializeComponent();
        }


        private void EstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Registro estudia = new Registro();
           
            estudia.Show();
        }

        private void InscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Inscripcion inscripcio = new Inscripcion();
            inscripcio.MdiParent = this;
            inscripcio.Show();
        }
    }
}
