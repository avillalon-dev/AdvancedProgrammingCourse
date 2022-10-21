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
        /// <param name="department">
        /// Departamento al que pertenece el trabajador.
        /// </param>
        /// <returns>
        /// Un objeto <see cref="Worker"/> con la información del trabajador
        /// </returns>
        public Worker CreateWorker(string name, Departments department)
        {
            var worker = new Worker(name, department);
            Add(worker);
            return worker;
        }
    }
}
