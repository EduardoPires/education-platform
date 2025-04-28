using EducationPlatform.Domain.Common;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Domain.StudentManagement
{
    public class Matricula : Entity
    {
        public int CursoId { get; private set; }
        public int AlunoId { get; private set; }
        public StatusMatricula Status { get; private set; }
        public HistoricoAprendizado HistoricoAprendizado { get; private set; }

        protected Matricula() { } // For EF

        public Matricula(int cursoId, int alunoId)
        {
            CursoId = cursoId;
            AlunoId = alunoId;
            Status = StatusMatricula.PendentePagamento;
            HistoricoAprendizado = new HistoricoAprendizado(0);
        }

        public void Ativar()
        {
            Status = StatusMatricula.Ativa;
        }

        public void Finalizar()
        {
            Status = StatusMatricula.Concluida;
        }
    }

    public enum StatusMatricula
    {
        PendentePagamento,
        Ativa,
        Concluida
    }
}
