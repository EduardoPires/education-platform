using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.StudentManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace EducationPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protege o controller inteiro
    public class AlunoController : ControllerBase
    {
        private readonly EducationDbContext _context;

        public AlunoController(EducationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            var alunos = await _context.Alunos
                .Include(a => a.Matriculas)
                .Include(a => a.Certificados)
                .ToListAsync();

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno(int id)
        {
            var aluno = await _context.Alunos
                .Include(a => a.Matriculas)
                .Include(a => a.Certificados)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost("{alunoId}/matricular/{cursoId}")]
        public async Task<IActionResult> Matricular(int alunoId, int cursoId)
        {
            var aluno = await _context.Alunos.FindAsync(alunoId);
            if (aluno == null)
                return NotFound("Aluno n�o encontrado.");

            var curso = await _context.Cursos.FindAsync(cursoId);
            if (curso == null)
                return NotFound("Curso n�o encontrado.");

            var matricula = new Matricula(cursoId, alunoId);
            aluno.AdicionarMatricula(matricula);

            _context.Update(aluno);
            await _context.SaveChangesAsync();

            return Ok("Matr�cula realizada com sucesso.");
        }

        [HttpPost("{alunoId}/finalizar/{matriculaId}")]
        public async Task<IActionResult> FinalizarCurso(int alunoId, int matriculaId)
        {
            var aluno = await _context.Alunos
                .Include(a => a.Matriculas)
                .Include(a => a.Certificados)
                .FirstOrDefaultAsync(a => a.Id == alunoId);

            if (aluno == null)
                return NotFound("Aluno n�o encontrado.");

            var matricula = aluno.Matriculas.FirstOrDefault(m => m.Id == matriculaId);

            if (matricula == null)
                return NotFound("Matr�cula n�o encontrada.");

            if (matricula.Status != StatusMatricula.Ativa)
                return BadRequest("Matr�cula precisa estar ativa para finalizar o curso.");

            // Atualiza a matr�cula para Conclu�da
            matricula.Finalizar();

            // Cria o certificado
            var certificado = new Certificado(alunoId, matricula.CursoId);
            aluno.AdicionarCertificado(certificado);

            _context.Matriculas.Update(matricula);
            _context.Certificados.Add(certificado);
            _context.Alunos.Update(aluno);

            await _context.SaveChangesAsync();

            return Ok("Curso finalizado e certificado gerado com sucesso.");
        }
    }
}
