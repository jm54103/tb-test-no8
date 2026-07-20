using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
[ApiController]
public class ExaminationController : ControllerBase
{
        private readonly AppDbContext _context;

        public ExaminationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examination>>> GetExaminations()
        {
            return await _context.Examinations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Examination>> PostExamination(Examination item)
        {
            _context.Examinations.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExaminations), new { id = item.Id }, item);
        }
}
