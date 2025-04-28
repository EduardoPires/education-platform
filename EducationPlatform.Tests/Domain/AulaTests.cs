using Xunit;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class AulaTests
    {
        [Fact]
        public void Deve_Criar_Aula_Corretamente()
        {
            var aula = new Aula("Título Aula", "Conteúdo Aula", "http://material.com");

            Assert.Equal("Título Aula", aula.Titulo);
            Assert.Equal("Conteúdo Aula", aula.Conteudo);
            Assert.Equal("http://material.com", aula.MaterialUrl);
        }
    }
}
