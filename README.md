# Education Platform

# 1. Apresentação
Bem-vindo ao repositório do projeto Education Platform. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo 3 ao Desenvolvimento de API em ASP.NET Core. 
O objetivo principal é desenvolver uma API de uma plataforma educacional online com múltiplos bounded contexts (BC), aplicando DDD, TDD, CQRS e padrões arquiteturais para gestão eficiente de conteúdos educacionais, alunos e processos financeiros.

# Autor
+ Leandro Andreotti

# 2. Proposta do Projeto
O projeto consiste em:

+ **API RESTful**: Exposição dos recursos do blog para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
+ **Autenticação e Autorização**: Implementação de controle de acesso.
+ **Acesso a Dados**: .

# 3. Tecnologias Utilizadas
+ **Linguagem de Programação**: C#
+ **Frameworks**:
  + ASP.NET Core Web API
  + Entity Framework Core
+ **Banco de Dados**: SQLite
+ **Autenticação e Autorização**:
  + ASP.NET Core Identity
  + JWT (JSON Web Token) para autenticação na API
+ **Documentação da API**: Swagger

# 4. Estrutura do Projeto
A estrutura do projeto é organizada da seguinte forma:

+ src/
+ /Api
    - Program.cs
    - Controllers/
    - Middlewares/
+ /Domain
     - /Common
     - /ContentManagement
     - /StudentManagement
     - /PaymentManagement
+ /Infrastructure
    - Data/
    - Identity/
    - Services/
+ /Application
     - /UseCases/
     - /DTOs/
     - /Interfaces/
+ /Tests
     - /Unit
     - /Integration
+ README.md - Arquivo de Documentação do Projeto
+ FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
+ .gitignore - Arquivo de Ignoração do Git

# 5. Funcionalidades Implementadas
+ Listar cursos: Listar todos os cursos
+ Matrículas, Finalização, Visualização: Realização da Matrícula, finalização e visualização da mesma.
+ Realizar pagamento de matrícula
+ Autenticação e Autorização: Diferenciação entre usuários comuns e administradores.
+ API RESTful: Exposição de endpoints para operações CRUD via API.
+ Documentação da API: Documentação automática dos endpoints da API utilizando Swagger.

# 6. Como Executar o Projeto

### Pré-requisitos
+ .NET SDK 8.0 ou superior
+ SQLite
+ Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
+ Git

### Passos para Execução

**1. Clone o Repositório**:

+ git clone:

        git clone https://github.com/Landreotti/education-platform.git

+ cd EducationPlatform: 

        cd EducationPlatform.Api

 + Rodar os testes:
 +     dotnet test --collect:"XPlat Code Coverage" 

+ Gerar relatório HTML:
+     reportgenerator -reports:"TestResults/**/*.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html


**2. Executar a API**:

+ cd EducationPlatform
+ dotnet run
+ Acesse a documentação da API em: [Swagger](http://localhost:5295/swagger).

# 7. Instruções de Configuração

+ JWT para API: As chaves de configuração do JWT estão no appsettings.json.
+ Migrações do Banco de Dados: As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

# 8. Documentação da API
A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

[Swagger](http://localhost:5295/swagger).

# 9. Avaliação

+ Este projeto é parte de um curso acadêmico e não aceita contribuições externas.
+ Para feedbacks ou dúvidas utilize o recurso de Issues
+ O arquivo FEEDBACK.md é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
