# LH-Pets Web API

Web API em ASP.NET Core (C#) com Controllers para gerenciar clientes e seus pets.
Os dados ficam em memória (`List<T>`), sem banco de dados.

## Como executar

```bash
dotnet restore
dotnet run
```

Abra o Swagger em: http://localhost:5080/swagger

## Endpoints

| Método | Rota                            | Descrição                          |
|--------|---------------------------------|------------------------------------|
| GET    | /api/clientes                   | Lista todos os clientes            |
| POST   | /api/clientes                   | Cadastra um cliente                |
| GET    | /api/pets                       | Lista todos os pets                |
| POST   | /api/pets                       | Cadastra um pet vinculado a cliente|
| GET    | /api/pets/cliente/{clienteId}   | Lista os pets de um cliente        |

## Exemplos de JSON

Cliente:
```json
{ "nome": "Maria Silva", "cpf": "123.456.789-00", "email": "maria@email.com" }
```

Pet:
```json
{ "nome": "Rex", "especie": "Cachorro", "raca": "Labrador", "clienteId": 1 }
```
