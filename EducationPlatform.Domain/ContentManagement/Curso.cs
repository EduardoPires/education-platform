using EducationPlatform.Domain.Common;

namespace EducationPlatform.Domain.ContentManagement
{
    public class Curso : Entity
    {
        public string Nome { get; private set; }
        public ConteudoProgramatico ConteudoProgramatico { get; private set; }

        private readonly List<Aula> _aulas = new();
        public IReadOnlyCollection<Aula> Aulas => _aulas.AsReadOnly();

        protected Curso() { } // For EF

        public Curso(string nome, ConteudoProgramatico conteudoProgramatico)
        {
            Nome = nome;
            ConteudoProgramatico = conteudoProgramatico;
        }

        public void AdicionarAula(Aula aula)
        {
            _aulas.Add(aula);
        }
    }
}
