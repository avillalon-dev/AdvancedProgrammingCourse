using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Define las funcionalidades para la administración de trabajadores.
    /// </summary>
    public interface IWorkerRepository : IRepository
    {
        /// <summary>
        /// Crea un trabajador en el soporte de datos.
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
        Worker CreateWorker(string name, DateTime birthDate, string email, int phoneNumber, Departments department);
        /// <summary>
        /// Actualiza un trabajador en el soporte de datos.
        /// </summary>
        /// <param name="worker">
        /// Un objeto <see cref="Worker"/> con la información del trabajador.
        /// </param>
        void UpdateWorker(Worker worker);
        /// <summary>
        /// Elimina un trabajador en el soporte de datos.
        /// </summary>
        /// <param name="worker">
        /// Un objeto <see cref="Worker"/> con la información del trabajador.
        /// </param>
        void DeleteWorker(Worker worker);
        /// <summary>
        /// Obtiene un trabajador en el soporte de datos a partir del nombre.
        /// </summary>
        /// <param name="name">
        /// Nombre del trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        Worker FindWorker(string name);
        /// <summary>
        /// Obtiene un trabajador en el soporte de datos.
        /// </summary>
        /// <param name="id">
        /// Identificador del trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        Worker GetWorker(int id);
        /// <summary>
        /// Obtiene los trabajadores del soporte de datos.
        /// </summary>
        /// <returns>
        /// Colección de <see cref="Worker"/>.
        /// </returns>
        List<Worker> GetWorkers();
    }
}
