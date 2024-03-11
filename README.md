
# Título do Projeto

Projeto CRUD "básico" de listagem de tarefas, desenvolvido utilizando .NET 7 e Entity 




## Conexão com SQL Server e Execução

Configurações necesárias:

 - Na pasta TaskList/Db há o script para criação da tabela a ser utilizada
 - Há, também, um script auxiliar para criação das tarefas, via banco de dados
 - A porta configurada para rodar a aplicação é a : localhost:7252



## Collection Postman para execução dos endpoints da API

 - Na pasta Postman Collection/TaskListProject.postman_collection.json
 - Basta apenas importar para dentro do aplicatico Postman

## Documentação da API

####  Método que retorna todas a tarefas por ordem de data de inicio

```http
  GET /api/TaskList
```


#### Método que consulta a tarefa por parametros (id, tittulo ou descricao)

```http
  GET /api/TaskList/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da tarefa |


#### Método de criação de tarefa 

```http
  POST /api/TaskList/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Titulo`      | `string` | **Obrigatório**. O titulo da tarefa |
| `Descricao`      | `string` |. A descricao da tarefa |
| `Finalizada`      | `bool` | **Obrigatório**. Flag identificadora se a tarefa finalizada|
| `DataInicio`      | `Date` | **Obrigatório**. A Data de Inicio da tarefa |
| `DataFim`      | `Date` | Data de fim da tarefa |


#### Método de alteração de tarefa 

```http
  PUT /api/TaskList/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da tarefa |
| `Titulo`      | `string` | **Obrigatório**. O titulo da tarefa |
| `Descricao`      | `string` |. A descricao da tarefa |
| `Finalizada`      | `bool` | **Obrigatório**. Flag identificadora se a tarefa finalizada|
| `DataInicio`      | `Date` | **Obrigatório**. A Data de Inicio da tarefa |
| `DataFim`      | `Date` | Data de fim da tarefa |


#### Método de atualização apenas da flag de finalização 

```http
  PATCH /api/TaskList/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da tarefa | 
| `Finalizada`      | `bool` | **Obrigatório**. Flag identificadora se a tarefa finalizada| 



#### Método de exclusão da tarefa

```http
  DELETE /api/TaskList/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da tarefa | 

