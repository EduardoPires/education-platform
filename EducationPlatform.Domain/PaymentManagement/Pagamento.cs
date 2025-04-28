using EducationPlatform.Domain.Common;

namespace EducationPlatform.Domain.PaymentManagement
{
    public class Pagamento : Entity
    {
        public int MatriculaId { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DadosCartao DadosCartao { get; private set; }
        public StatusPagamento Status { get; private set; }

        protected Pagamento() { } // For EF

        public Pagamento(int matriculaId, decimal valor, DadosCartao dadosCartao)
        {
            MatriculaId = matriculaId;
            Valor = valor;
            DadosCartao = dadosCartao;
            DataPagamento = DateTime.UtcNow;
            Status = StatusPagamento.AguardandoConfirmacao();
        }

        public void Confirmar()
        {
            Status = StatusPagamento.Pago();
        }

        public void Rejeitar()
        {
            Status = StatusPagamento.Recusado();
        }
    }
}
