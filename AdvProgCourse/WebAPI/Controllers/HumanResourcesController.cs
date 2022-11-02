using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanResourcesController : ControllerBase
    {
        private readonly ILogger<HumanResourcesController> _logger;

        private readonly IWorkerRepository _workerRepository;

        public HumanResourcesController(ILogger<HumanResourcesController> logger, IWorkerRepository workerRepository)
        {
            _logger = logger;
            _workerRepository = workerRepository;
        }

        [HttpPost("PostWorker/{name},{birthdate},{email},{phoneNumber},{department}", Name = "PostWorker")]
        public ActionResult<Worker> PostWorker(string name, DateTime birthdate, string email, int phoneNumber, int department)
        {
            _workerRepository.BeginTransaction();
            var worker = _workerRepository.CreateWorker(name, birthdate, email, phoneNumber, Enum.GetValues<Departments>()[department]);
            _workerRepository.CommitTransaction();
            if (worker == null)
            {
                _logger.LogError($"{nameof(HumanResourcesController.PostWorker)} -> cannot create worker");
                return NotFound();
            }
            return worker;
        }

        [HttpGet("GetWorkers", Name = "GetWorkers")]
        public ActionResult<IEnumerable<Worker>> GetWorkers()
        {
            _workerRepository.BeginTransaction();
            var worker = _workerRepository.GetWorkers();
            _workerRepository.CommitTransaction();
            if (worker == null)
            {
                _logger.LogError($"{nameof(HumanResourcesController.GetWorker)} -> worker not found");
                return NotFound();
            }
            return worker;
        }

        [HttpGet("GetWorker/{id}", Name = "GetWorker")]
        public ActionResult<Worker> GetWorker(int id)
        {
            _workerRepository.BeginTransaction();
            var worker = _workerRepository.GetWorker(id);
            _workerRepository.CommitTransaction();
            if (worker == null)
            {
                _logger.LogError($"{nameof(HumanResourcesController.GetWorker)} -> worker not found");
                return NotFound();
            }
            return worker;
        }
    }
}