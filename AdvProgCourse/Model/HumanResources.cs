namespace Model
{
    public delegate double SalaryFunction(Person person);

    public class HumanResources
    {
        #region Fields

        private List<SalaryFunction> _salaryFunctions;

        #endregion

        #region Properties

        public List<Person> People { get; }

        public int Count { get { return People.Count; } }

        #endregion

        public HumanResources()
        {
            People = new List<Person>();
            _salaryFunctions = new List<SalaryFunction>();
        }

        public HumanResources(List<SalaryFunction> salaryFunctions)
        {
            People = new List<Person>();
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
            var worker = new Worker(name, birthDate, email, phoneNumber, department)
            {
                BirthDate = birthDate,
                Email = email,
                PhoneNumber = phoneNumber
            };
            worker.Activated += WorkerActivated;
            People.Add(worker);
        }

        public void AddStudent()
        {
        }

        public void Activate()
        {
            foreach (Person person in People)
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
