using EducationPlatform.Domain.ContentManagement;
using EducationPlatform.Domain.StudentManagement;
using EducationPlatform.Domain.PaymentManagement;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(this EducationDbContext context)
        {
            // Garantir que o banco est� criado
            context.Database.EnsureCreated();

            // Se j� existir dados, n�o faz nada
            if (context.Cursos.Any() || context.Alunos.Any())
                return;

            // Criar Curso
            var curso = new Curso(
                "Curso de C# B�sico",
                new ConteudoProgramatico("Aprenda C# do zero: tipos de dados, controle de fluxo, POO")
            );

            curso.AdicionarAula(new Aula("Introdu��o ao C#", "Conceitos b�sicos de C# e .NET"));
            curso.AdicionarAula(new Aula("Tipos de Dados", "Tipos primitivos, structs e enums"));
            curso.AdicionarAula(new Aula("POO em C#", "Classes, objetos, heran�a e polimorfismo"));

            context.Cursos.Add(curso);
            context.SaveChanges();

            // Criar Aluno
            var aluno = new Aluno("Jo�o Silva", "joao.silva@email.com");
            context.Alunos.Add(aluno);
            context.SaveChanges();

            // Criar Matr�cula
            var matricula = new Matricula(curso.Id, aluno.Id);
            aluno.AdicionarMatricula(matricula);
            context.SaveChanges();
        }
    }
}
