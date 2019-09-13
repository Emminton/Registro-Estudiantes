using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace RegistroEstudiante.Entidades
{
    public class InscripcionEntidades
    {
        [Key]
        public int IDinscripcion { get; set; }
        public DateTime fecha { get; set; }
        public int IDestudiante { get; set; }
        public string comentario { get; set; }
        public decimal monto { get; set; }
        public decimal deposito { get; set; }

        public decimal balance { get; set; }

        public InscripcionEntidades(int dinscripcion, DateTime fecha, int destudiante, string comentario, decimal monto, decimal deposito, decimal balance)
        {
            IDinscripcion = dinscripcion;
            this.fecha = fecha;
            IDestudiante = destudiante;
            this.comentario = comentario;
            this.monto = monto;
            this.deposito = deposito;
            this.balance = balance;
        }

        public InscripcionEntidades()
        {
        }
    }
}
