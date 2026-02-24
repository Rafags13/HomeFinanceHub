# Home Finance Hub - Frontend

Aplicação frontend desenvolvida em React + Vite para gerenciamento de gastos domésticos.

Consome a API responsável por Pessoas, Categorias e Transações.

---

## Stack Utilizada

- React 19
- Vite
- TypeScript
- React Router DOM
- Axios
- TanStack Query
- React Hook Form
- Zod
- TailwindCSS

---

## Arquitetura

A aplicação foi estruturada utilizando Feature-Based Architecture, onde cada domínio é isolado em seu próprio módulo.

Cada feature contém:

- api -> integração com backend
- hooks -> abstrações de queries/mutations
- components -> componentes específicos do domínio
- pages -> páginas da feature
- routes -> definição de rotas
- schemas -> validações com Zod
- types -> tipagens TypeScript

Essa organização facilita:

- Escalabilidade
- Manutenção
- Separação de responsabilidades

---

## Fluxo de Dados

### Criação / Edição

- Page
- React Hook Form
- Zod (validação)
- Mutation (TanStack Query)
- API (Axios)
- Backend

### Consulta de Dados

- Component
- Hook customizado
- TanStack Query
- Cache
- API

TanStack Query foi utilizado para:

- Controle de cache
- Revalidação automática
- Controle de loading/error
- Sincronização eficiente com backend

---

## Decisões Técnicas

### Feature-Based Architecture

Melhora organização e escalabilidade do projeto.

### TanStack Query

Evita controle manual de loading/state.
Centraliza gerenciamento de requisições assíncronas.

### Axios com tipagem

Permite interceptors e melhor controle de erros.

### React Hook Form + Zod

- Alta performance
- Validação tipada
- Integração simples com formulários complexos

### TailwindCSS

Permite estilização rápida e consistente.
Customizações reutilizáveis foram extraídas para classes compartilhadas.

---

## UX Implementada

- Paginação
- Validação de formulários
- Tratamento visual de erros
- Feedback após ações

---

## Integração com API

Base URL configurada via:

VITE_API_BASE_URL

Exemplo:

VITE_API_BASE_URL=https://localhost:5001

---

## 🛠 Como Executar

1. Instalar dependências

npm install

2. Criar arquivo `.env`

VITE_API_BASE_URL=https://localhost:<porta-backend>

3. Rodar aplicação
