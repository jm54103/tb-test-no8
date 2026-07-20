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
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }else{
                item.RecordTimestamp = DateTime.UtcNow;
                _context.Examinations.Add(item);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetExaminations), new { id = item.Id }, item);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamination(int id)
        {
            var examination = await _context.Examinations.FindAsync(id);

            if (examination == null)
                return NotFound();

            _context.Examinations.Remove(examination);
            await _context.SaveChangesAsync();

            return NoContent();
        }
}
