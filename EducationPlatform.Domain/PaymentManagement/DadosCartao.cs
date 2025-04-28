namespace EducationPlatform.Domain.PaymentManagement
{
    public class DadosCartao
    {
        public string NomeTitular { get; private set; }
        public string Numero { get; private set; }
        public string Validade { get; private set; }
        public string CVV { get; private set; }

        protected DadosCartao() { } // For EF

        public DadosCartao(string nomeTitular, string numero, string validade, string cvv)
        {
            NomeTitular = nomeTitular;
            Numero = numero;
            Validade = validade;
            CVV = cvv;
        }
    }
}
