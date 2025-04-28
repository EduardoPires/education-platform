namespace EducationPlatform.Domain.PaymentManagement
{
	public class StatusPagamento
	{
		public string Descricao { get; private set; }

		protected StatusPagamento() { } // For EF

		private StatusPagamento(string descricao)
		{
			Descricao = descricao;
		}

		public static StatusPagamento AguardandoConfirmacao() => new StatusPagamento("Aguardando Confirmação");
		public static StatusPagamento Pago() => new StatusPagamento("Pago");
		public static StatusPagamento Recusado() => new StatusPagamento("Recusado");
	}
}
