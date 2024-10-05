using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        
        public ActivitiesController(DataContext context)
        {
            _context = context;
           
            
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActvities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/fef2f2323f23f
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
{
    var activity = await _context.Activities.FindAsync(id);

    if (activity == null) 
        return NotFound();

    return Ok(activity); // Explicitly wrapping it in Ok() to avoid null argument warning
}
    }
}