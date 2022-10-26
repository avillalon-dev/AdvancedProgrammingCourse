﻿namespace Model
{
    /// <summary>
    /// Modela la información asociada a una persona.
    /// </summary>
    public abstract class Person
    {
        #region Fields


        #endregion

        #region Properties

        /// <summary>
        /// Identificador de la persona.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Número de teléfono.
        /// </summary>
        public int PhoneNumber { get; set; }
        /// <summary>
        /// Indica el estado de activación de una persona en el sistema.
        /// </summary>
        public bool IsActive { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        protected Person()
        { }

        /// <summary>
        /// Inicializa un objeto <see cref="Person"/>
        /// </summary>
        /// <param name="name">
        /// Nombre de la persona.
        /// </param>
        protected Person(string name, DateTime birthDate, string email, int phoneNumber)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = false;
        }

        #endregion

        #region Methods

        public abstract bool Activate();
        public virtual bool ActivateAll()
        {
            IsActive = true;
            return true;
        }

        #endregion
    }

    /// <summary>
    /// Tipos de departamentos.
    /// </summary>
    public enum Departments
    {
        /// <summary>
        /// Automática
        /// </summary>
        Automation,
        /// <summary>
        /// 
        /// </summary>
        Telecommunication
    }

    /// <summary>
    /// Modela la información asociada a un trabajador.
    /// </summary>
    public class Worker : Person
    {
        #region Properties

        public Departments Department { get; set; }

        public double Salary { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        protected Worker()
        { }

        public Worker(string name, DateTime birthDate, string email, int phoneNumber, Departments department) 
            : base(name, birthDate, email, phoneNumber)
        {
            Department = department;
        }

        public override bool Activate()
        {
            // TODO: Implementar activar worker
            Activated.Invoke(null, Id);
            throw new NotImplementedException();
        }

        public override bool ActivateAll()
        {
            return base.ActivateAll();
        }

        public event EventHandler<int> Activated; 
    }

    /// <summary>
    /// Facultades
    /// </summary>
    public enum Faculty
    {
        /// <summary>
        /// Automática y Biomédica
        /// </summary>
        AutomationBiomedical,
        /// <summary>
        /// Telecomunicaciones
        /// </summary>
        Telecommunication
    }

    /// <summary>
    /// Modela la información asociada a un estudiante.
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Facultad a la que pertenece el estudiante
        /// </summary>
        public Faculty Faculty;

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        protected Student() : base()
        { }

        public Student(string name, DateTime birthDate, string email, int phoneNumber, Faculty faculty) 
            : base(name, birthDate, email, phoneNumber)
        {
            Faculty = faculty;
        }

        public override bool Activate()
        {
            throw new NotImplementedException();
        }
    }
}