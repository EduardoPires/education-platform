using Xunit;
using EducationPlatform.Domain.StudentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class AlunoTests
    {
        [Fact]
        public void Deve_Criar_Aluno_Corretamente()
        {
            var aluno = new Aluno("Jo�o Silva", "joao@email.com");

            Assert.Equal("Jo�o Silva", aluno.Nome);
            Assert.Equal("joao@email.com", aluno.Email);
        }

        [Fact]
        public void Deve_Adicionar_Matricula_A_Aluno()
        {
            var aluno = new Aluno("Jo�o Silva", "joao@email.com");
            var matricula = new Matricula(1, aluno.Id);

            aluno.AdicionarMatricula(matricula);

            Assert.Single(aluno.Matriculas);
        }
    }
}
