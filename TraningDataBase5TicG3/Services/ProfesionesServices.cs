using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TraningDataBase5TicG3.Infraestructure;
using TraningDataBase5TicG3.Models;

namespace TraningDataBase5TicG3.Services
{
    public class ProfesionesServices: IProfesionesService
    {
        private readonly TestDbMensageriaEntities db = null;

        public ProfesionesServices()
        {
            this.db = new TestDbMensageriaEntities();
        }

        public List<profesiones> GetAll()
        {
            return this.db.profesiones.ToList();
        }

        public profesiones GetByName (string name)
        {
            return this.db.profesiones.Where(p => p.stValor.Equals(name)).FirstOrDefault();
        }
        /// <summary>
        /// Este metodo se encarga de buscar mediante un Id
        /// </summary>
        /// <param name="id">Identificador de db</param>
        /// <returns>Regresa una Profesion</returns>
        public profesiones GetById(int? id)
        {
            return this.db.profesiones.SingleOrDefault(p => p.id == id);
        }

        /// <summary>
        /// Este metodo se encarga de guardar en base de datos
        /// </summary>
        /// <param name="profesion">Una entidad de base de datos</param>
        /// <returns>Un valor boolean True/False</returns>
        public bool Create(profesiones profesion)
        {
            var transaccion = this.db.Database.BeginTransaction();
            this.db.profesiones.Add(profesion);
            this.db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        /// <summary>
        /// Se encarga de editar un registro en la db
        /// </summary>
        /// <param name="profesion">Una entidad profesrion de db</param>
        /// <returns>Regresa un valor True or false</returns>
        public bool Edit(profesiones profesion)
        {
            var transaccion = this.db.Database.BeginTransaction();
            db.Entry(profesion).State = EntityState.Modified;
            db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        public bool detele(profesiones profesion)
        {
            var transaccion = this.db.Database.BeginTransaction();
            db.profesiones.Remove(profesion);
            db.SaveChanges();
            transaccion.Commit();
            return true;
        }

        public void Close()
        {
            this.db.Dispose();
        }

    }
}