using Xunit;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Infrastructure.Data;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Tests.Infrastructure
{
    public class EducationDbContextTests
    {
        [Fact]
        public void Deve_Salvar_E_Recuperar_Curso_No_DbContext()
        {
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: "EducationTestDb")
                .Options;

            using (var context = new EducationDbContext(options))
            {
                var curso = new Curso("Curso Teste", new ConteudoProgramatico("Descrição Teste"));
                context.Cursos.Add(curso);
                context.SaveChanges();
            }

            using (var context = new EducationDbContext(options))
            {
                var cursos = context.Cursos.ToList();
                Assert.Single(cursos);
                Assert.Equal("Curso Teste", cursos[0].Nome);
            }
        }
    }
}
