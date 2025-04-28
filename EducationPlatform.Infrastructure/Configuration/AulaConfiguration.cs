using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Infrastructure.Configurations
{
    public class AulaConfiguration : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("Aulas");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.Conteudo)
                .IsRequired();

            builder.Property(a => a.MaterialUrl)
                .HasMaxLength(500);

            builder.Property(a => a.CursoId)
                .IsRequired();
        }
    }
}
