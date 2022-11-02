using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanResourcesController : ControllerBase
    {
        private readonly ILogger<HumanResourcesController> _logger;

        private readonly HumanResources _humanResources;

        public HumanResourcesController(ILogger<HumanResourcesController> logger, HumanResources humanResources)
        {
            _logger = logger;
            _humanResources = humanResources;
        }

        [HttpPost("{name},{department}", Name = "PostWorker")]
        public Worker PostWorker(string name, int department)
        {
            _humanResources.AddWorker(name, DateTime.Now, "", 0, Enum.GetValues<Departments>()[department]);
            return _humanResources.People.OfType<Worker>().First(w => w.Name == name);
        }

        [HttpGet(Name = "GetWorkers")]
        public IEnumerable<Worker> GetWorkers()
        {
            return _humanResources.People.OfType<Worker>();
        }

        [HttpGet("{id}", Name = "GetWorker")]
        public Worker GetWorker(int id)
        {
            return _humanResources.People.OfType<Worker>().First(w => w.Id == id);
        }
    }
}