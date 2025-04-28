namespace EducationPlatform.Domain.StudentManagement
{
    public class HistoricoAprendizado
    {
        public int ProgressoPercentual { get; private set; } // 0 a 100%

        protected HistoricoAprendizado() { } // For EF

        public HistoricoAprendizado(int progressoPercentual)
        {
            ProgressoPercentual = progressoPercentual;
        }

        public void AtualizarProgresso(int novoProgresso)
        {
            if (novoProgresso >= 0 && novoProgresso <= 100)
            {
                ProgressoPercentual = novoProgresso;
            }
        }
    }
}
