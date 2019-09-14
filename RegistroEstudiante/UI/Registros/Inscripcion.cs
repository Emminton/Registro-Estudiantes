using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudiante.Entidades;
using RegistroEstudiante.BLL;
using System.Windows.Forms;


namespace RegistroEstudiante.UI.Consultas
{
    public partial class Inscripcion : Form
    {
        public Inscripcion()
        {
            InitializeComponent();
        }
        private void LlenarCampo(InscripcionEntidades inscripcion)
        {

            InscripcionnumericUpDown1.Value = inscripcion.IDinscripcion;
            inscripcion.fecha = Convert.ToDateTime(FechadateTimePicker1 );
            EstudiantenumericUpDown2.Value = inscripcion.IDestudiante;
            ComentariotextBox1.Text = inscripcion.comentario;
            MontotextBox2.Text = Convert.ToString(inscripcion.monto);
            DepositotextBox3.Text =Convert.ToString( inscripcion.deposito);
            BalancetextBox4.Text = Convert.ToString(inscripcion.balance);

           
        }
        private InscripcionEntidades LLenaClase()
        {
            InscripcionEntidades inscripcion = new InscripcionEntidades();
            inscripcion.IDinscripcion = Convert.ToInt32(InscripcionnumericUpDown1.Value);
            inscripcion.IDestudiante = Convert.ToInt32(EstudiantenumericUpDown2.Value);
            inscripcion.comentario = ComentariotextBox1.Text;
            inscripcion.fecha = Convert.ToDateTime(FechadateTimePicker1.Value);
            inscripcion.monto = Convert.ToInt32(MontotextBox2.Text);
            inscripcion.deposito = Convert.ToInt32(DepositotextBox3.Text);
            inscripcion.balance = Convert.ToInt32(BalancetextBox4.Text);
            return inscripcion;
        }

        private void Limpiar()
        {
            InscripcionnumericUpDown1.Value = 0;
            EstudiantenumericUpDown2.Value = 0;
            FechadateTimePicker1.Value = DateTime.Now;         
            ComentariotextBox1.Text = string.Empty;          
            MontotextBox2.Text = string.Empty;
            DepositotextBox3.Text = string.Empty;
            BalancetextBox4.Text = string.Empty;
            TuErrorProvider1.Clear();

        }

        private void Editarbutton1_Click(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            InscripcionEntidades inscripcion = InscripcionBLL.Buscar((int)InscripcionnumericUpDown1.Value);
            return (inscripcion != null);
        }

        private void Guardarbutton2_Click(object sender, EventArgs e)
        {
            InscripcionEntidades inscripcion;
            bool paso = false;

            if (!Validar())
                return;
            inscripcion = LLenaClase();

            //determina si es guardar oh modificar

            if (InscripcionnumericUpDown1.Value == 0)
                paso = InscripcionBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se pudo modificar la inscripcion que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                paso = InscripcionBLL.Modificar(inscripcion);


            }

            //informar el resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "fallo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Eliminarbutton3_Click(object sender, EventArgs e)
        {
            TuErrorProvider1.Clear();

            int id;
            int.TryParse(InscripcionnumericUpDown1.Text, out id);
            int.TryParse(EstudiantenumericUpDown2.Text, out id);


            Limpiar();

            if (InscripcionBLL.Eliminar(id))
                MessageBox.Show("Eliminado", " Con Exito..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                TuErrorProvider1.SetError(InscripcionnumericUpDown1, "No se puede eliminar un inscripcion que no existe");

            
            if (InscripcionBLL.Eliminar(id))
                MessageBox.Show("Eliminado", " Con Exito..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                TuErrorProvider1.SetError(EstudiantenumericUpDown2, "No se puede eliminar un estudiante que no existe");
        }

        private void Buscarbutton4_Click(object sender, EventArgs e)
        {
            int id;
            InscripcionEntidades inscripcion = new InscripcionEntidades();
            int.TryParse(InscripcionnumericUpDown1.Text, out id);
            int.TryParse(EstudiantenumericUpDown2.Text, out id);

            Limpiar();

            inscripcion = InscripcionBLL.Buscar(id);

            if (inscripcion != null)
            {
                MessageBox.Show("Inscripcion encontrado.");
                LlenarCampo(inscripcion);

            }
            else
            {
                MessageBox.Show("Inscripcion no encontrada.");
            }
        }

        private bool Validar()
        {
            bool paso = true;
            TuErrorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(InscripcionnumericUpDown1.Text))
            {
                TuErrorProvider1.SetError(InscripcionnumericUpDown1, "El campode del ID no puede estar vacio...");
                InscripcionnumericUpDown1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(EstudiantenumericUpDown2.Text))
            {
                TuErrorProvider1.SetError(EstudiantenumericUpDown2, "El campode del ID no puede estar vacio...");
                EstudiantenumericUpDown2.Focus();
                paso = false;
            }

            if (ComentariotextBox1.Text == string.Empty)
            {
                TuErrorProvider1.SetError(ComentariotextBox1, "El campo Comentario no puede estar vacio...");
                ComentariotextBox1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(FechadateTimePicker1.Text))
            {
                TuErrorProvider1.SetError(FechadateTimePicker1, "El campode la cedula no puede estar vacio...");
                FechadateTimePicker1.Focus();
                paso = false;
            }

            //condicion del monto
            if (string.IsNullOrWhiteSpace(MontotextBox2.Text))
            {
                TuErrorProvider1.SetError(MontotextBox2, "El campo de celular no puede estar vacio...");
                MontotextBox2.Focus();
                paso = false;
            }
            //condicion del deposito
            if (string.IsNullOrWhiteSpace(DepositotextBox3.Text))
            {
                TuErrorProvider1.SetError(DepositotextBox3, "El campo de celular no puede estar vacio...");
                DepositotextBox3.Focus();
                paso = false;
            }
            //condicion del balancce
            if (string.IsNullOrWhiteSpace(BalancetextBox4.Text))
            {
                TuErrorProvider1.SetError(BalancetextBox4, "El campo de celular no puede estar vacio...");
                BalancetextBox4.Focus();
                paso = false;
            }

            return paso;
        }
        
    }
}
