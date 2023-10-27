# Projeto:
Este projeto se trata de uma API com as funcionalidades de um CRUD, podendo Cadastrar, Filtrar, Editar e Deletar produtos de suas categorias.

# Tecnologias:
Este projeto foi desenvolvido em C#.NET6 com ajuda do Entity Framework em sua versão 6.0 para realizar o mapeamento do banco de dados SQLServer.

Saiba mais em:

- [API .NET6](https://learn.microsoft.com/pt-br/dotnet/api/?view=net-6.0).
- [Entity Framework](https://learn.microsoft.com/pt-br/aspnet/entity-framework).

# Como Rodar:
O primeiro passo é abrir o arquivo **appsettings.json** e configurar sua **ConnectionStrings**

Exemplo:
```
Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
```
Depois abra seu Package manager Console e execute o codigo

`
Update-Database
`

Para ser criado o banco de dados local 

Logo após inicie a aplicação e acesse a URL [https://localhost:7241](https://localhost:7241/swagger/index.html)
para ter acesso a todos EndPoints da aplicação.