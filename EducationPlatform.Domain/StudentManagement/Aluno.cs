using EducationPlatform.Domain.Common;

namespace EducationPlatform.Domain.StudentManagement
{
    public class Aluno : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        private readonly List<Matricula> _matriculas = new();
        public IReadOnlyCollection<Matricula> Matriculas => _matriculas.AsReadOnly();

        private readonly List<Certificado> _certificados = new();
        public IReadOnlyCollection<Certificado> Certificados => _certificados.AsReadOnly();

        protected Aluno() { } // For EF

        public Aluno(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void AdicionarMatricula(Matricula matricula)
        {
            _matriculas.Add(matricula);
        }

        public void AdicionarCertificado(Certificado certificado)
        {
            _certificados.Add(certificado);
        }
    }
}
