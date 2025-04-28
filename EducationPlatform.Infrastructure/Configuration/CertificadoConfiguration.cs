using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EducationPlatform.Domain.StudentManagement;

namespace EducationPlatform.Infrastructure.Configurations
{
    public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
    {
        public void Configure(EntityTypeBuilder<Certificado> builder)
        {
            builder.ToTable("Certificados");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.AlunoId)
                .IsRequired();

            builder.Property(c => c.CursoId)
                .IsRequired();

            builder.Property(c => c.DataEmissao)
                .IsRequired();
        }
    }
}
