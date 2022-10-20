using Microsoft.AspNetCore.Mvc;

namespace Pagination.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly SampleDbContext _sampleDbContext;
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger, SampleDbContext sampleDbContext)
        {
            _logger = logger;
            _sampleDbContext = sampleDbContext;
        }

        [HttpGet(Name = "Samples")]
        public IActionResult Get([FromQuery] PaginationRequest<Guid> request)
        {
            return Ok(_sampleDbContext.SampleEntities.Where(t => t.Name == "234").ApplyPagination(request, t => t.Id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            _sampleDbContext.SampleEntities.Add(new Entities.SampleEntity() { Name = name });

            await _sampleDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}