using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.PaymentManagement;
using EducationPlatform.Domain.StudentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PagamentoController : ControllerBase
    {
        private readonly EducationDbContext _context;

        public PagamentoController(EducationDbContext context)
        {
            _context = context;
        }

        [HttpPost("{matriculaId}/realizar")]
        public async Task<IActionResult> RealizarPagamento(int matriculaId, [FromBody] RealizarPagamentoRequest request)
        {
            var matricula = await _context.Matriculas
                .FirstOrDefaultAsync(m => m.Id == matriculaId);

            if (matricula == null)
                return NotFound("Matrícula não encontrada.");

            if (matricula.Status != StatusMatricula.PendentePagamento)
                return BadRequest("Matrícula não está pendente de pagamento.");

            var dadosCartao = new DadosCartao(request.NomeTitular, request.Numero, request.Validade, request.CVV);
            var pagamento = new Pagamento(matricula.Id, request.Valor, dadosCartao);

            // Aqui você pode simular pagamento (aprovar automaticamente)
            pagamento.Confirmar();
            matricula.Ativar();

            _context.Pagamentos.Add(pagamento);
            _context.Matriculas.Update(matricula);

            await _context.SaveChangesAsync();

            return Ok("Pagamento realizado com sucesso. Matrícula ativada.");
        }
    }

    public class RealizarPagamentoRequest
    {
        public decimal Valor { get; set; }
        public string NomeTitular { get; set; }
        public string Numero { get; set; }
        public string Validade { get; set; }
        public string CVV { get; set; }
    }
}
