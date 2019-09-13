using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Entidades
{
    public class Estudiante
    {
        [Key]
        public int ID { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public string Cedula { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public decimal balance { get; set; }

        public Estudiante(int iD, string matricula, string nombre, string apellido, DateTime nacimiento, string cedula, string telefono, string celular, string email, string sexo, decimal balance)
        {
            ID = iD;
            this.matricula = matricula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacimiento = nacimiento;
            this.Cedula = cedula;
            this.telefono = telefono;
            this.celular = celular;
            this.email = email;
            this.sexo = sexo;
            this.balance = balance;
        }

        public Estudiante()
        {
        }
    }
}
