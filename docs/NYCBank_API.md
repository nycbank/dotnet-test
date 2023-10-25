# NYCBANK_API

## Requisitos Funcionais:

	1. CRUD para Produtos
	2. CRUD para Categorias
	3. Produtos possuem: "id", "nome" e "preço"
	4. Categorias possuem: "id" e "nome"
	5. Cada Produto pode pertencer a várias categorias, mas não repetidas vezes na mesma categoria.
	6. Cada Categoria pode se relacionar com vários produtos


## Requisitos Não Funcionais:

	1. Respostas em Formato JSON
	2. Códigos HTTP devem ser implementados conforme sua operação

## Modelagem de Dados:
O diagrama pode ser encontrado na pasta /docs.

	1. Produto:
		id: Int, PK
		nome: String, Not Null
		preco: Decimal, Not Null
	2. Categoria:
		id: Int, PK
		nome: String, Not Null


