using Model;
using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class WorkerRepositoryTests
    {
        IWorkerRepository _repository;

        public WorkerRepositoryTests()
        {
            var connectionString = @"Data Source=ADRIANA-PC\SQLEXPRESS;AttachDBFilename=D:\cujae\Programación Avanzada\Código\DB\HumanResourcesDB.mdf;Initial Catalog=HumanResourcesDB;User ID=sa;Password=qwerty";
            _repository = new DBRepository(new ConnectionString(connectionString));
        }

        [DataTestMethod]
        [DataRow("sensor1", "m")]
        [DataRow("sensor2", "m")]
        [DataRow("sensor3", "m")]
        public void Can_CreateWorker_Test(string Xname, string engunit)
        {
            // arrange
            string name = "Juan";
            DateTime dateTime = new DateTime(2000, 10, 01);
            string email = "juan@cujae.cu";
            int phone = 55555555;
            Departments department = Departments.Automation;

            // act
            _repository.BeginTransaction();
            var worker = _repository.CreateWorker(name, dateTime, email, phone, department);
            _repository.CommitTransaction();

            // assert
            Assert.IsNotNull(worker);
            Assert.AreNotEqual(0, worker.Id);
            Assert.AreEqual(name, worker.Name);
            Assert.AreEqual(department, worker.Department);
        }

        [TestMethod]
        public void Can_UpdateWorker_Test()
        {
            // arrange
            _repository.BeginTransaction();
            var worker = _repository.FindWorker("Juan");
            _repository.CommitTransaction();

            var newEmail = "juanp@cujae.cu";
            worker.Email = newEmail;

            // act
            _repository.BeginTransaction();
            _repository.UpdateWorker(worker);
            _repository.PartialCommit();

            // assert
            var newWorker =_repository.GetWorker(worker.Id);
            _repository.CommitTransaction();
            Assert.IsNotNull(newWorker);
            Assert.AreNotEqual(0, newWorker.Id);
            Assert.AreEqual(newEmail, newWorker.Email);
        }

        [TestMethod]
        public void Can_DeleteWorker_Test()
        {
            // arrange
            _repository.BeginTransaction();
            var worker = _repository.FindWorker("Juan");
            _repository.CommitTransaction();

            // act
            _repository.BeginTransaction();
            _repository.DeleteWorker(worker);
            _repository.PartialCommit();

            // assert
            var deletedWorker = _repository.GetWorker(worker.Id);
            _repository.CommitTransaction();
            Assert.IsNull(deletedWorker);
        }
    }
}