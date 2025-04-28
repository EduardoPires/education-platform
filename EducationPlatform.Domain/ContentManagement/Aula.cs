using EducationPlatform.Domain.Common;

namespace EducationPlatform.Domain.ContentManagement
{
    public class Aula : Entity
    {
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public string? MaterialUrl { get; private set; }

        public int CursoId { get; private set; }

        protected Aula() { } // For EF

        public Aula(string titulo, string conteudo, string? materialUrl = null)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            MaterialUrl = materialUrl;
        }
    }
}
