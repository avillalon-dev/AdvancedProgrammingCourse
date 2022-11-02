using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Implementa métodos para la administración de los trabajadores
    /// en la base de datos.
    /// </summary>
    public partial class DBRepository : IWorkerRepository
    {
        /// <summary>
        /// Crea un trabajador en la base de datos.
        /// </summary>
        /// <param name="name">
        /// Nombre del trabajador
        /// </param>
        /// <param name="birthDate">
        /// Fecha de nacimiento.
        /// </param>
        /// <param name="email">
        /// Correo del trabajador.
        /// </param>
        /// <param name="phoneNumber">
        /// Número de teléfono.
        /// </param>
        /// <param name="department">
        /// Departamento al que pertenece el trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        public Worker CreateWorker(string name, DateTime birthDate, string email, int phoneNumber, Departments department)
        {
            var worker = new Worker(name, birthDate, email, phoneNumber, department);
            Add(worker);
            return worker;
        }
        /// <summary>
        /// Actualiza un trabajador en la base de datos.
        /// </summary>
        /// <param name="worker">
        /// Un objeto <see cref="Worker"/> con la información del trabajador.
        /// </param>
        public void UpdateWorker(Worker worker)
        {
            Update(worker);
        }
        /// <summary>
        /// Elimina un trabajador de la base de datos.
        /// </summary>
        /// <param name="worker">
        /// Un objeto <see cref="Worker"/> con la información del trabajador.
        /// </param>
        public void DeleteWorker(Worker worker)
        {
            Delete(worker);
        }
        /// <summary>
        /// Obtiene un trabajador de la base de datos a partir del nombre.
        /// </summary>
        /// <param name="name">
        /// Nombre del trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        public Worker FindWorker(string name)
        {
            return Get<Worker>(w => w.Name == name).First();
        }
        /// <summary>
        /// Obtiene un trabajador de la base de datos.
        /// </summary>
        /// <param name="id">
        /// Identificador del trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        public Worker GetWorker(int id)
        {
            return GetByID<Worker>(id);
        }
        /// <summary>
        /// Obtiene los trabajadores de la base de datos.
        /// </summary>
        /// <returns>
        /// Colección de <see cref="Worker"/>.
        /// </returns>
        public List<Worker> GetWorkers()
        { 
            return Get<Worker>();
        }
    }
}
