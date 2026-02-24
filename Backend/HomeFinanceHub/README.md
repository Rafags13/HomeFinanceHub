# Home Finance Hub API

API desenvolvida em .NET 8 para controle de gastos domésticos.

O sistema permite o gerenciamento de Pessoas, Categorias e Transações, aplicando regras de negócio específicas para garantir integridade, rastreabilidade e consistência dos dados.

---

## Tecnologias Utilizadas

- .NET 8
- Minimal API
- Entity Framework Core
- Swagger / OpenAPI
- OneOf (Pattern Matching para retorno tipado)
- Unit of Work
- Repository Pattern

---

## Arquitetura

Estrutura baseada em separação clara de responsabilidades:

- Controller (Minimal API)

- Service (Regras de negócio)

- UnitOfWork

- Repositories

- Database

### 🔹 Services

Responsáveis por:

- Aplicar regras de negócio
- Validar entidades relacionadas
- Garantir integridade antes da persistência

### 🔹 Repository Pattern

Responsável exclusivamente pelo acesso a dados.

### 🔹 Unit of Work

Coordena os repositórios e garante consistência transacional.

---

## Domínio

### Person

Representa uma pessoa do sistema.

- Utiliza Soft Delete para garantir rastreabilidade.
- Pode possuir múltiplas transações associadas.

### Category

Representa categorias de transações.

Tipos possíveis:

- Revenue
- Expenditure
- Both

Validação aplicada:

- Tamanho máximo da descrição.

### Transaction

Representa uma transação financeira vinculada a uma pessoa e categoria.

Regras aplicadas:

- Pessoa deve existir.
- Categoria deve existir.
- Categoria deve ser compatível com o tipo da transação.
- Receita exige idade mínima.
- Retorno padronizado em caso de erro.

---

## Decisões Técnicas

### Soft Delete

Adotado para evitar perda de dados e manter rastreabilidade.

### OneOf para retorno

Evita uso de exceções como fluxo esperado.
Permite retorno tipado:

OneOf<bool, BaseError>

### BaseError

Padroniza todos os erros da aplicação com:

- Mensagem
- Código HTTP
- Tipo do erro

---

## Endpoints Principais

### Person

- POST /person
- GET /person
- DELETE /person/{id}

### Category

- POST /category
- GET /category

### Transaction

- POST /person/transaction
- GET /person/transaction (paginado)

---

## 🔎 Paginação

As consultas de transações utilizam:

- page (int)
- pageSize (sbyte)

Retorno:

PaginatedDTO<T>

---

## Tratamento de Erros

A API retorna erros padronizados via `BaseError`.

Exemplos:

- PersonNotFoundError
- CategoryNotFoundError
- TransactionRevenueAgeError
- TransactionCategoryTypeError
- DatabaseError

---

## 🛠 Como Executar

1. Clonar o repositório

git clone <repo-url>

2. Restaurar dependências

dotnet restore

3. Executar aplicação

dotnet run

4. Acessar Swagger

https://localhost
:<port>/swagger
