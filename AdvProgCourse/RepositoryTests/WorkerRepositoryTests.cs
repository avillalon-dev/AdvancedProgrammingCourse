using Repository;

namespace RepositoryTests
{
    [TestClass]
    public class WorkerRepositoryTests
    {
        IWorkerRepository _repository; 

        public WorkerRepositoryTests()
        {
            _repository = new DBRepository(@"Data Source=<PCName>\SQLEXPRESS;AttachDBFilename=<Database path>;Initial Catalog=<Database name>;User ID=<username>;Password=<password>");
        }

        [TestMethod]
        public void Can_AddWorker_Test()
        {
            // arrange


            // act
            _repository.BeginTransaction();
            _repository.CreateWorker("Juan", Model.Departments.Automation);
            _repository.CommitTransaction();

            // assert

        }
    }
}