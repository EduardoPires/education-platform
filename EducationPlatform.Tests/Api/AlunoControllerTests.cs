using Xunit;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Api.Controllers;
using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.StudentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Tests.Api
{
    public class AlunoControllerTests
    {
        private readonly EducationDbContext _context;

        public AlunoControllerTests()
        {
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AlunoDb")
                .Options;
            _context = new EducationDbContext(options);
        }

        [Fact]
        public async Task Deve_Listar_Alunos()
        {
            // Arrange
            var aluno = new Aluno("João", "joao@email.com");
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            var controller = new AlunoController(_context);

            // Act
            var result = await controller.GetAlunos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var alunos = Assert.IsAssignableFrom<IEnumerable<Aluno>>(okResult.Value);
            Assert.Single(alunos);
        }
    }
}
