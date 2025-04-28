using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EducationPlatform.Domain.ContentManagement;

namespace EducationPlatform.Infrastructure.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(c => c.ConteudoProgramatico);

            builder.HasMany(c => c.Aulas)
                .WithOne()
                .HasForeignKey(a => a.CursoId);
        }
    }
}
