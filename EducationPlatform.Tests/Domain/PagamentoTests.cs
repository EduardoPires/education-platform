using Xunit;
using EducationPlatform.Domain.PaymentManagement;

namespace EducationPlatform.Tests.Domain
{
    public class PagamentoTests
    {
        [Fact]
        public void Deve_Criar_Pagamento_Aguardando_Confirmacao()
        {
            var dadosCartao = new DadosCartao("Titular", "1234567812345678", "12/26", "123");
            var pagamento = new Pagamento(1, 500, dadosCartao);

            Assert.Equal("Aguardando Confirmação", pagamento.Status.Descricao);
        }

        [Fact]
        public void Deve_Confirmar_Pagamento()
        {
            var dadosCartao = new DadosCartao("Titular", "1234567812345678", "12/26", "123");
            var pagamento = new Pagamento(1, 500, dadosCartao);

            pagamento.Confirmar();

            Assert.Equal("Pago", pagamento.Status.Descricao);
        }

        [Fact]
        public void Deve_Rejeitar_Pagamento()
        {
            var dadosCartao = new DadosCartao("Titular", "1234567812345678", "12/26", "123");
            var pagamento = new Pagamento(1, 500, dadosCartao);

            pagamento.Rejeitar();

            Assert.Equal("Recusado", pagamento.Status.Descricao);
        }
    }
}
