# DotNet Core versão 3.1 com C# (Website) e SQLite3 - Projeto 02

* Linguagem principal: C# (CSharp)
* Frameworks utilizadas: DotNet Core versão 3.1
* Outras linguagens: HTML5, CSS3 e Javascript
* Pacotes extras utilizadas: AutoMapper, FluentValidator, Dapper e Microsoft Extensions Dependency Injection
* Banco de Dados utilizado: SQLite3
* Template utilizado: AdminLTE Bootstrap Admin Dashboard Template (MIT License)
* Editor utilizado: Visual Studio 2019
* Informações extras: Foi utilizado DI (dependency injection) com arquitetura limpa (CLEAN ARCHITECTURE) em 3 camadas (domain, application e infra) com uma camada extra de utilitades (cross cutting).

----

## Descrição:

Pequeno projeto em ASP.NET Core v3.1 (C# com Website) para demonstrar o uso com BD SQLite3 criando uma tabela, inserindo, alterando, excluindo e listando os dados de forma sequencial através de um Website.

----

## Banco de Dados:

1. Na pasta "Database" está os 2 bancos de dados e 1 está com 100 registros e o outro esta vazio
2. O BD com o nome "estoque.db" é o BD que é usado pelo Website
3. O BD com o nome "estoque_BD_ZERADO.db" serve apenas para se você precisar de um BD vazio
4. Se quiser mudar o caminha onde o BD fica, vá para o projeto "KITAB.CRUD.Products.Infra" e altere o arquivo "Repository.cs"

----

## Sobre o Autor:

SANDRO YAQUB YUSUF - Analista & Programador Sênior FULL-STACK - Trabalha com desenvolvimento de softwares desde 1990, passando pelas linguagens COBOL, CLIPPER, VISUAL BASIC 6, ASP Clássico, ASP.NET Framework, ASP.NET Core, PHP (Laravel) e NodeJS. Possui conhecimentos em banco de dados como SQL-SERVER, ORACLE, MySQL, MariaDB, MongoDB e SQLite. Também possui conhecimentos em HTML5, CSS3, TYPESCRIPT e JAVASCRIPT. Para as frameworks de desenvolvimento de FRONT-END, possui conhecimentos em ANGULAR, VUEJS e REACT JS. Pratica o modelo CLEAN ARCHITECTURE usando os conhecimentos em DDD, SOLID e TDD.
