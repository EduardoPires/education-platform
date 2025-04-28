using EducationPlatform.Domain.Common;

namespace EducationPlatform.Domain.StudentManagement
{
    public class Certificado : Entity
    {
        public int AlunoId { get; private set; }
        public int CursoId { get; private set; }
        public DateTime DataEmissao { get; private set; }

        protected Certificado() { } // For EF

        public Certificado(int alunoId, int cursoId)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
            DataEmissao = DateTime.UtcNow;
        }
    }
}
