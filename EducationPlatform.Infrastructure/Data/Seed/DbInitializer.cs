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
            // Garantir que o banco está criado
            context.Database.EnsureCreated();

            // Se já existir dados, não faz nada
            if (context.Cursos.Any() || context.Alunos.Any())
                return;

            // Criar Curso
            var curso = new Curso(
                "Curso de C# Básico",
                new ConteudoProgramatico("Aprenda C# do zero: tipos de dados, controle de fluxo, POO")
            );

            curso.AdicionarAula(new Aula("Introdução ao C#", "Conceitos básicos de C# e .NET"));
            curso.AdicionarAula(new Aula("Tipos de Dados", "Tipos primitivos, structs e enums"));
            curso.AdicionarAula(new Aula("POO em C#", "Classes, objetos, herança e polimorfismo"));

            context.Cursos.Add(curso);
            context.SaveChanges();

            // Criar Aluno
            var aluno = new Aluno("João Silva", "joao.silva@email.com");
            context.Alunos.Add(aluno);
            context.SaveChanges();

            // Criar Matrícula
            var matricula = new Matricula(curso.Id, aluno.Id);
            aluno.AdicionarMatricula(matricula);
            context.SaveChanges();
        }
    }
}
