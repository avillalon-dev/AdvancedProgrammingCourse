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
        /// <param name="department">
        /// Departamento al que pertenece el trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        Worker CreateWorker(string name, Departments department);
    }
}
