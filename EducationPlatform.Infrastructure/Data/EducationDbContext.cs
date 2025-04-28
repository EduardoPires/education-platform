using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.ContentManagement;
using EducationPlatform.Domain.StudentManagement;
using EducationPlatform.Domain.PaymentManagement;

namespace EducationPlatform.Infrastructure.Data
{
	public class EducationDbContext : DbContext
	{
		public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
		{
		}

		// Content Management
		public DbSet<Curso> Cursos { get; set; }
		public DbSet<Aula> Aulas { get; set; }

		// Student Management
		public DbSet<Aluno> Alunos { get; set; }
		public DbSet<Matricula> Matriculas { get; set; }
		public DbSet<Certificado> Certificados { get; set; }

		// Payment Management
		public DbSet<Pagamento> Pagamentos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configurations (separadas por classe para boa prática)
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationDbContext).Assembly);
		}
	}
}
