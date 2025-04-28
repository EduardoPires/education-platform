using Xunit;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Api.Controllers;
using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.ContentManagement;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Tests.Api
{
    public class CursoControllerTests
    {
        private readonly EducationDbContext _context;

        public CursoControllerTests()
        {
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_CursoDb")
                .Options;
            _context = new EducationDbContext(options);
        }

        [Fact]
        public async Task Deve_Listar_Cursos()
        {
            // Arrange
            _context.Cursos.Add(new Curso("Curso Teste", new ConteudoProgramatico("Descrição")));
            await _context.SaveChangesAsync();

            var controller = new CursoController(_context);

            // Act
            var result = await controller.GetCursos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var cursos = Assert.IsAssignableFrom<IEnumerable<Curso>>(okResult.Value);
            Assert.Single(cursos);
        }
    }
}
