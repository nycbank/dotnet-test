# PROJETO

Este projeto se trata de uma REST API que tem o objetivo de realizar o cadastro de produtos e categorias, a fim de permitir que um usuário insira novos dados, altere ou exclua dados já existentes.

# TECNOLOGIAS

Foi utilizado o .NET 6 da Microsoft como base do projeto, juntamente com o Entity Framework na versão 7.0.13. Para o banco de dados SQL Server foi utilizado um docker com uma instância do SQL Server, rodando dentro de um servidor local, visto que o ambiente utilizado para o desenvolvimento é baseado no MacOS.

Os padrões utilizados nesse projeto foram o Repository e o Service Pattern, permitindo que a aplicação se torne mais escalável ao vincular uma única responsabilidade para cada projeto dentro da solução.

# COMO RODAR

Para executar o projeto, é necessário ter o Runtime do .NET 6 instalado em sua máquina Windows, Linux ou MacOS. 

Após verificar se o mesmo está instalado, é necessário abrir um dos arquivos do projeto para configurar o caminho do banco de dados. 

No arquivo RegisterContext.cs, seguindo o caminho dotnet-test-solution/Repository/DatabaseContexts/RegisterContext.cs há uma variável chamada connectionString na linha de número 9.

Se for utilizar migrations para o banco de dados é imprescindível que o endereço de um servidor SQL Server válido seja inserido, tanto local como em nuvem.

Feito isso é necessário utilizar o Package Manager Console, ou algum plugin em sua IDE e rodar a migration já existente ou adicionar uma nova.

Há também a possibilidade de utilizar um banco de dados em memória, apenas comentando a linha de número 17 e descomentando a linha de número 19, porém nesse caso não há como executar uma migration.

Feito todos os passos acima, podemos finalmente executar a API, dentro da pasta dotnet-solution/Crud_API inserindo o comando dotnet run



