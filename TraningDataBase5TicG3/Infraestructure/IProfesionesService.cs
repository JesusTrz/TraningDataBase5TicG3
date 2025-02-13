using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraningDataBase5TicG3.Models;

namespace TraningDataBase5TicG3.Infraestructure
{
    public interface IProfesionesService
    {
        void Close();

        /// <summary>
        /// Este metodo se encarga de guardar en base de datos
        /// </summary>
        /// <param name="profesiones">Una entidad de base de datos</param>
        /// <returns>Un valor boolean True/False</returns>
        bool Create(profesiones profesiones);
        bool detele(profesiones profesion);

        /// <summary>
        /// Se encarga de editar un registro en la db
        /// </summary>
        /// <param name="profesion">Una entidad profesrion de db</param>
        /// <returns>Regresa un valor True or false</returns>
        bool Edit(profesiones profesion);
        List<profesiones> GetAll();
        profesiones GetById(int? id);
        profesiones GetByName(string name);
    }
}
