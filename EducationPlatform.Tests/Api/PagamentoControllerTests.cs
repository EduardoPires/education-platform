using Xunit;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Api.Controllers;
using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.StudentManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationPlatform.Tests.Api
{
    public class PagamentoControllerTests
    {
        private readonly EducationDbContext _context;

        public PagamentoControllerTests()
        {
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_PagamentoDb")
                .Options;
            _context = new EducationDbContext(options);
        }

        [Fact]
        public async Task RealizarPagamento_Deve_Retornar_NotFound_Se_Matricula_Nao_Existir()
        {
            // Arrange
            var controller = new PagamentoController(_context);

            // Act
            var result = await controller.RealizarPagamento(999, new RealizarPagamentoRequest
            {
                Valor = 500,
                NomeTitular = "Teste",
                Numero = "1234567812345678",
                Validade = "12/26",
                CVV = "123"
            });

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Matrícula não encontrada.", notFoundResult.Value);
        }
    }
}
