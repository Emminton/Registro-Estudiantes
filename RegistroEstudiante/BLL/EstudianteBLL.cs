using System;
using System.Collections.Generic;
using System.Linq;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Entidades;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;

namespace RegistroEstudiante.BLL
{
    public class EstudianteBLL
    {
        //PERMITE GUARDAR UN ESTUDIANTE EN LA BASE DE DATOS
        public static bool Guardar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.estudiante.Add(estudiante) != null)

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
        public static bool Modificar(Estudiante estudiante)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiante).State = EntityState.Modified;
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
                var eliminar = db.estudiante.Find(id);
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
        public static Estudiante Buscar(int id)
        {
            Contexto db = new Contexto();
            Estudiante estudiante = new Estudiante();
            try
            {
                estudiante = db.estudiante.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }
            return estudiante;

        }
        //permite extraer una lista de estudiante de la base de datos
        public static List<Estudiante> GetList(Expression<Func<Estudiante, bool>> estudiante)
        {
            List<Estudiante> Lista = new List<Estudiante>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.estudiante.Where(estudiante).ToList();

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