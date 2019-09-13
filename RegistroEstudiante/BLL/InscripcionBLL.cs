using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Entidades;
using System.Data.Entity;

namespace RegistroEstudiante.BLL
{
    public class InscripcionBLL
    {

        //PERMITE GUARDAR UN ESTUDIANTE EN LA BASE DE DATOS
        public static bool Guardar(InscripcionEntidades inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.inscripcion.Add(inscripcion) != null)

                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();//siempre hay que cerrar la conexion
            }
            return paso;
        }
        //este metodo modifica
        public static bool Modificar(InscripcionEntidades inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }

        //este metodo eliminar una entidad en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.inscripcion.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        //este metodo para buscar una persona
        public static InscripcionEntidades Buscar(int id)
        {
            Contexto db = new Contexto();
            InscripcionEntidades inscripcion = new InscripcionEntidades();
            try
            {
                inscripcion = db.inscripcion.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }
            return inscripcion;

        }
        //permite extraer una lista de estudiante de la base de datos
        public static List<InscripcionEntidades> GetList(Expression<Func<InscripcionEntidades, bool>> inscripcion)
        {
            List<InscripcionEntidades> Lista = new List<InscripcionEntidades>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.inscripcion.Where(inscripcion).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
