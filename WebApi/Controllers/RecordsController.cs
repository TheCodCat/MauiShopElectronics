using Microsoft.AspNetCore.Mvc;
using Models.models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsRepository recordsRepository;

        public RecordsController(IRecordsRepository recordsRepository)
        {
            this.recordsRepository = recordsRepository;
        }

        [HttpGet("/getRecords/{userId:int}")]
        public async Task<List<Records>> GetRecords(int userId)
        {
            return await recordsRepository.GetRecords(userId);
        }

        [HttpPost("/createRecorder")]
        public async Task<bool> CreateRecords([FromBody] Records records)
        {
            var result = await recordsRepository.Create(records);
            return result;
        }
    }
}
