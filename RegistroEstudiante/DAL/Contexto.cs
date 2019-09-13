using System;
using RegistroEstudiante.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RegistroEstudiante.DAL
{
    //heredamos de DbContext para que entEntityframework pueda hacer su amiga
    public class Contexto : DbContext
    {
        public DbSet<Estudiante> estudiante { get; set; }

        public DbSet<InscripcionEntidades> inscripcion { get; set; }

        public Contexto() : base("ConStr")
        {

        }
   }
}
