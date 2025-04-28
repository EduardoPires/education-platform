using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EducationPlatform.Domain.PaymentManagement;

namespace EducationPlatform.Infrastructure.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.MatriculaId)
                .IsRequired();

            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DataPagamento)
                .IsRequired();

            builder.OwnsOne(p => p.DadosCartao, cartao =>
            {
                cartao.Property(c => c.NomeTitular)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("NomeTitularCartao");

                cartao.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NumeroCartao");

                cartao.Property(c => c.Validade)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ValidadeCartao");

                cartao.Property(c => c.CVV)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("CVVCartao");
            });

            builder.OwnsOne(p => p.Status, status =>
            {
                status.Property(s => s.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("StatusPagamento");
            });
        }
    }
}
