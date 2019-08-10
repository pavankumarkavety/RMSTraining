using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Models;
using TrainingAPI.Services;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public TrainingController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> PostTraining([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if (await _repo.Add(training))
            {
                return Ok(CreatedAtAction("GetTraining", new { id = training.Id }, training));
            }

            return BadRequest("Could not add training");
            
        }
        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraining([FromRoute] int id)
        {
            var training = await _repo.GetTraining(id);
           

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        
    }
}