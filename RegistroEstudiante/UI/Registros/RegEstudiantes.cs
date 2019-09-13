using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudiante.BLL;
using RegistroEstudiante.Entidades;
using System.Windows.Forms;

namespace RegistroEstudiante.UI.Registros
{
    public partial class RegEstudiantes : Form
    {
        public RegEstudiantes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            ID_numericUpDown1.Value = 0;
            Matricula_maskedTextBox1.Text = string.Empty;
            Nombre_textBox2.Text = string.Empty;
            Apellido_textBox3.Text = string.Empty;
            Nacimiento_dateTimePicker1.Value = DateTime.Now;
            Cedula_maskedTextBox1.Text = string.Empty;
            Telefono_maskedTextBox1.Text = string.Empty;
            Celular_maskedTextBox1.Text = string.Empty;
            Email_textBox7.Text = string.Empty;
            Sexo_comboBox2.Text = string.Empty;
            Balance_textBox8.Text = string.Empty;
            MyErrorProvider1.Clear();

        }
        //evento del boton para limpar todos los componentes
        private void Editar_button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenarCampo(Estudiante estudiante)
        {

            ID_numericUpDown1.Value = estudiante.ID;
            Matricula_maskedTextBox1.Text = estudiante.matricula;
            Nombre_textBox2.Text = estudiante.nombre;
            Apellido_textBox3.Text = estudiante.apellido;
            estudiante.nacimiento = Convert.ToDateTime(Nacimiento_dateTimePicker1.Text);
            Cedula_maskedTextBox1.Text = estudiante.Cedula;
            Telefono_maskedTextBox1.Text = estudiante.telefono;
            Celular_maskedTextBox1.Text = estudiante.celular;
            Email_textBox7.Text = estudiante.email;
            Sexo_comboBox2.Text = estudiante.sexo;
            Balance_textBox8.Text = Convert.ToString(estudiante.balance);
        }

        private Estudiante LLenaClase()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.ID = Convert.ToInt32(ID_numericUpDown1.Value);
            estudiante.matricula = Matricula_maskedTextBox1.Text;
            estudiante.nombre = Nombre_textBox2.Text;
            estudiante.apellido = Apellido_textBox3.Text;
            estudiante.nacimiento = Convert.ToDateTime(Nacimiento_dateTimePicker1.Value);
            estudiante.Cedula = Cedula_maskedTextBox1.Text;
            estudiante.telefono = Telefono_maskedTextBox1.Text;
            estudiante.celular = Celular_maskedTextBox1.Text;
            estudiante.email = Email_textBox7.Text;
            estudiante.sexo = Sexo_comboBox2.Text;
            estudiante.balance = Convert.ToInt32(Balance_textBox8.Text);
            return estudiante;
        }

        private void Guardar_button3_Click(object sender, EventArgs e)
        {
            Estudiante estudiante;
            bool paso = false;

            if (!Validar())
                return;
            estudiante = LLenaClase();

            //determina si es guardar oh modificar

            if (ID_numericUpDown1.Value == 0)
                paso = EstudianteBLL.Guardar(estudiante);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se pudo modificar el Estudiante que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                paso = EstudianteBLL.Modificar(estudiante);
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

        private bool ExisteEnLaBaseDeDatos()
        {
            Estudiante estudiante = EstudianteBLL.Buscar((int)ID_numericUpDown1.Value);
            return (estudiante != null);
        }

        private void Eliminar_button4_Click(object sender, EventArgs e)
        {
            MyErrorProvider1.Clear();

            int id;
            int.TryParse(ID_numericUpDown1.Text, out id);

            Limpiar();

            if (EstudianteBLL.Eliminar(id))
                MessageBox.Show("Eliminado", " Con Exito..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider1.SetError(ID_numericUpDown1, "No se puede eliminar un estudiante que no existe");
        }

        private void Buscar_button1_Click(object sender, EventArgs e)
        {
            int id;
            Estudiante estudiante = new Estudiante();
            int.TryParse(ID_numericUpDown1.Text, out id);

            Limpiar();

            estudiante = EstudianteBLL.Buscar(id);

            if (estudiante != null)
            {
                MessageBox.Show("Estudiante encontrado.");
                LlenarCampo(estudiante);

            }
            else
            {
                MessageBox.Show("Estudiante no encontrado.");
            }

        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(ID_numericUpDown1.Text))
            {
                MyErrorProvider1.SetError(ID_numericUpDown1, "El campode del ID no puede estar vacio...");
                ID_numericUpDown1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Matricula_maskedTextBox1.Text))
            {
                MyErrorProvider1.SetError(Matricula_maskedTextBox1, "El campode del ID no puede estar vacio...");
                Matricula_maskedTextBox1.Focus();
                paso = false;
            }

            if (Nombre_textBox2.Text == string.Empty)
            {
                MyErrorProvider1.SetError(Nombre_textBox2, "El campo nombre no puede estar vacio...");
                Nombre_textBox2.Focus();
                paso = false;
            }

            if (Apellido_textBox3.Text == string.Empty)
            {
                MyErrorProvider1.SetError(Apellido_textBox3, "El campo apellido no debe estar vacio...");
                Apellido_textBox3.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Nacimiento_dateTimePicker1.Text))
            {
                MyErrorProvider1.SetError(Nacimiento_dateTimePicker1, "El campode la cedula no puede estar vacio...");
                Nacimiento_dateTimePicker1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Cedula_maskedTextBox1.Text))
            {
                MyErrorProvider1.SetError(Cedula_maskedTextBox1, "El campode la cedula no puede estar vacio...");
                Cedula_maskedTextBox1.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(Telefono_maskedTextBox1.Text))
            {
                MyErrorProvider1.SetError(Telefono_maskedTextBox1, "El campo del telefono no puede estar vacio...");
                Telefono_maskedTextBox1.Focus();
                paso = false;

            }

            if (string.IsNullOrWhiteSpace(Celular_maskedTextBox1.Text))
            {
                MyErrorProvider1.SetError(Celular_maskedTextBox1, "El campo de celular no puede estar vacio...");
                Celular_maskedTextBox1.Focus();
                paso = false;
            }

            if (Email_textBox7.Text == string.Empty)
            {
                MyErrorProvider1.SetError(Email_textBox7, "El campo de Email no puede estar vacio...");
                Email_textBox7.Focus();
                paso = false;

            }

            if (Sexo_comboBox2.Text == string.Empty)
            {
                MyErrorProvider1.SetError(Sexo_comboBox2, "El campo de Email no puede estar vacio...");
                Sexo_comboBox2.Focus();
                paso = false;

            }
            if (string.IsNullOrWhiteSpace(Balance_textBox8.Text))
            {
                MyErrorProvider1.SetError(Balance_textBox8, "El campo de celular no puede estar vacio...");
                Balance_textBox8.Focus();
                paso = false;
            }

            return paso;
        }

       
    }
}
