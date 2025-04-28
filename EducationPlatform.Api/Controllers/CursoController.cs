using EducationPlatform.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EducationPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protege o controller inteiro
    public class CursoController : ControllerBase
    {
        private readonly EducationDbContext _context;

        public CursoController(EducationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCursos()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Aulas)
                .ToListAsync();

            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurso(int id)
        {
            var curso = await _context.Cursos
                .Include(c => c.Aulas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }
    }
}
