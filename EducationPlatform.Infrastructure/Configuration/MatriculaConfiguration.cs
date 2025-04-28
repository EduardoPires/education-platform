using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EducationPlatform.Domain.StudentManagement;

namespace EducationPlatform.Infrastructure.Configurations
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CursoId)
                .IsRequired();

            builder.Property(m => m.AlunoId)
                .IsRequired();

            builder.Property(m => m.Status)
                .IsRequired();

            builder.OwnsOne(m => m.HistoricoAprendizado, historico =>
            {
                historico.Property(h => h.ProgressoPercentual)
                    .IsRequired()
                    .HasColumnName("ProgressoPercentual");
            });
        }
    }
}
