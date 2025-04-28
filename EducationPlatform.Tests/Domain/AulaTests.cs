using Xunit;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class AulaTests
    {
        [Fact]
        public void Deve_Criar_Aula_Corretamente()
        {
            var aula = new Aula("T�tulo Aula", "Conte�do Aula", "http://material.com");

            Assert.Equal("T�tulo Aula", aula.Titulo);
            Assert.Equal("Conte�do Aula", aula.Conteudo);
            Assert.Equal("http://material.com", aula.MaterialUrl);
        }
    }
}
