using Xunit;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class CursoTests
    {
        [Fact]
        public void Deve_Criar_Curso_Corretamente()
        {
            var conteudo = new ConteudoProgramatico("Descrição do curso");
            var curso = new Curso("Curso Teste", conteudo);

            Assert.Equal("Curso Teste", curso.Nome);
            Assert.Equal("Descrição do curso", curso.ConteudoProgramatico.Descricao);
        }

        [Fact]
        public void Deve_Adicionar_Aula_A_Curso()
        {
            var conteudo = new ConteudoProgramatico("Descrição");
            var curso = new Curso("Curso Teste", conteudo);

            curso.AdicionarAula(new Aula("Aula 1", "Conteúdo da aula"));

            Assert.Single(curso.Aulas);
            Assert.Equal("Aula 1", curso.Aulas.First().Titulo);
        }
    }
}
