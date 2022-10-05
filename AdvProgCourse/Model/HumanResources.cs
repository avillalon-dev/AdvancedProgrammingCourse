namespace Model
{
    public delegate double SalaryFunction(Person person);

    public class HumanResources
    {
        #region Fields

        private List<Person> _people;

        private List<SalaryFunction> _salaryFunctions;

        #endregion

        #region Properties

        public int Count { get { return _people.Count; } }

        #endregion

        public HumanResources()
        {
            _people = new List<Person>();
            _salaryFunctions = new List<SalaryFunction>();
        }

        public HumanResources(List<SalaryFunction> salaryFunctions)
        {
            _people = new List<Person>();
            _salaryFunctions = salaryFunctions;
        }

        /// <summary>
        /// Adiciona un trabajador.
        /// </summary>
        /// <param name="name">
        /// Nombre del trabajador.
        /// </param>
        /// <param name="birthDate"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="department"></param>
        public void AddWorker(string name, DateTime birthDate, string email, int phoneNumber, Departments department)
        {
            var worker = new Worker(name, birthDate, email, phoneNumber, department);
            worker.Activated += WorkerActivated;
            _people.Add(worker);
        }

        public void AddStudent()
        {
        }

        public void Activate()
        {
            foreach (Person person in _people)
            {
                try
                {
                    person.Activate();
                }
                catch (NotImplementedException ex)
                {
                }
            }
        }

        public void Activate(int id)
        { 
        }

        #region EventHandler

        private void WorkerActivated(object? sender, int e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
