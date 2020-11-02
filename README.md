# Navita_Exercicio_2

### Especificações de sistema
Para rodar esse projeto é necessario 
- Visual Studio 2017 ou versão mais recente;
- Sistema operacional windows, preferecialmente Windows 10;
- SQL Server instalado;

### Ferramentas utilizadas
Foi utilizado ASP.NET Web com C# para desenvolver esta API, e Enitity Framework para criar o banco de dados com migrações code-first.

### Passos para rodar o projeto
##### 1. Preparando o ambiente
Abra a solução no Visual Studio e em seguida abra o Nuget Package Manager Console. Ele notificará que algumas Packages estão faltando no projeto e dará a opção de baixar as dependencias. Baixe essas dependencias. Caso essa notificação não apareça por qualquer motivo, pode baixa-las separadamente. Elas são:
- AutoMapper.4.1.0 (https://www.nuget.org/packages/AutoMapper/4.1.1)
- Newtonsoft Json (https://www.nuget.org/packages/Newtonsoft.Json/)
- EntityFramework (https://www.nuget.org/packages/EntityFramework/)
- Microsoft.AspNet.Identity.Core (https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core/)
- Microsoft.AspNet.Identity.EntityFramework (https://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/)

##### 2. Gerando o banco de dados 
No Nuget Package Manager Console digite `update-database`. Isso irá criar uma base de dados no Servidor local `(LocalDb)\MSSQLLocalDB`.

Alternativamente, você pode rodar o script gerado pelo Entity Framework que está no root do projeto, em um arquivo chamado `full-migration-sql-script.sql`.

##### 3. Rode o projeto
Rode o projeto PatrimonioManager clicando no botão Run do Visual Studio.


