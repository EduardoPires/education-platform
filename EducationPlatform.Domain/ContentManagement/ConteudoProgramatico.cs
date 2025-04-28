namespace EducationPlatform.Domain.ContentManagement
{
    public class ConteudoProgramatico
    {
        public string Descricao { get; private set; }

        protected ConteudoProgramatico() { } // For EF

        public ConteudoProgramatico(string descricao)
        {
            Descricao = descricao;
        }
    }
}
