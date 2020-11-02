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
- Microsoft.CodeDom.Providers.DotNetCompilerPlatform  2.0.1 (https://www.nuget.org/packages/Microsoft.CodeDom.Providers.DotNetCompilerPlatform/2.0.1)

##### 2. Gerando o banco de dados 
No Nuget Package Manager Console digite `update-database`. Isso irá criar uma base de dados no Servidor local `(LocalDb)\MSSQLLocalDB`.

Alternativamente, você pode rodar o script gerado pelo Entity Framework que está no root do projeto, em um arquivo chamado `full-migration-sql-script.sql`.

##### 3. Rode o projeto
Rode o projeto PatrimonioManager clicando no botão Run do Visual Studio. Uma página padrão do ASP.NET vai abrir. Você agora já pode fazer requisições para API. 

### Utilizando a API
Você pode usar API com Postman, ferramenta para fazer Requests. Na página de ajuda da API, acessível pelo botão "API" do menu lateral acima do site padrão do ASP.NET. Há documentação de todos os Endpoints e modelos para o envio. 

##### Autenticação
Para fazer requests na aplicação é preciso autenticar com um token, caso contrário a operação não será permitida. Para se autenticar siga os seguintes passos:
- No postman, aponte para o endereço `/api/Account/Register` e como corpo use um json como o seguinte:
```
{
  "Email": "admin@patrimonio",
  "Password": "Aa@123",
  "ConfirmPassword": "Aa@123"
}
```   
- Agora que criamos um usuário podemos logar e gerar o token. Para Logar aponte para o endereço `/Token` da API e na aba Body, selecione a opção `x-www-form-urlencoded`. Clique no botão "Bulk Edit" e cole os valores seguintes: 
```   
username:admin@patrimonio
password:Aa@123
grant_type:password
```   
Alternativamente, preencha conforme a imagem abaixo.

![imagem](https://i.ibb.co/k52t92p/image.png)

- Agora ao fazer um request na API, vá na aba Authorization, escolha o type `OAuth 2.0` e insira o Token gerado no input.
