using Xunit;
using EducationPlatform.Domain.StudentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class MatriculaTests
    {
        [Fact]
        public void Deve_Criar_Matricula_Com_Status_Pendente()
        {
            var matricula = new Matricula(1, 1);

            Assert.Equal(StatusMatricula.PendentePagamento, matricula.Status);
        }

        [Fact]
        public void Deve_Ativar_Matricula()
        {
            var matricula = new Matricula(1, 1);

            matricula.Ativar();

            Assert.Equal(StatusMatricula.Ativa, matricula.Status);
        }

        [Fact]
        public void Deve_Finalizar_Matricula()
        {
            var matricula = new Matricula(1, 1);

            matricula.Finalizar();

            Assert.Equal(StatusMatricula.Concluida, matricula.Status);
        }
    }
}
