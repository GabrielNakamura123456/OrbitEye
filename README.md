# OrbitEye

## Descrição do Projeto

O OrbitEye é uma API REST desenvolvida em ASP.NET Core para monitoramento climático inteligente.

A solução tem como objetivo auxiliar órgãos públicos e equipes de monitoramento na identificação de riscos climáticos, permitindo o cadastro de regiões, eventos climáticos, alertas e previsões geradas por Inteligência Artificial.

O sistema utiliza Oracle Database para persistência dos dados, autenticação JWT para segurança das rotas e documentação automática através do Swagger.

---

# Tecnologias Utilizadas

- ASP.NET Core 8
- C#
- Oracle Database
- Entity Framework Core
- JWT Authentication
- Swagger / OpenAPI
- Health Checks
- xUnit
- Clean Architecture

---

# Arquitetura da Solução

O projeto foi desenvolvido seguindo o padrão Clean Architecture.

## Estrutura de Camadas

```text
OrbitEye.Api
│
├── Controllers
├── Program.cs
├── appsettings.json
│
OrbitEye.Application
│
├── Interfaces
│
OrbitEye.Domain
│
├── Entities
│
OrbitEye.Infrastructure
│
├── Data
├── Repositories
├── Migrations
│
OrbitEye.Tests
│
├── Testes Automatizados
```

## Camadas

### OrbitEye.Api

Responsável pelos Controllers, autenticação JWT, Swagger e configuração da aplicação.

### OrbitEye.Application

Contém as interfaces utilizadas pelos repositórios.

### OrbitEye.Domain

Contém as entidades de negócio.

### OrbitEye.Infrastructure

Responsável pelo acesso ao banco Oracle, migrations e implementação dos repositórios.

### OrbitEye.Tests

Contém os testes automatizados utilizando xUnit.

---

# Diagramas

## Diagrama de Arquitetura

```mermaid
flowchart TD
    A[Cliente / Swagger] --> B[OrbitEye.Api]
    B --> C[Controllers]
    B --> D[JWT Authentication]
    B --> E[Swagger / OpenAPI]
    B --> F[Health Check]

    C --> G[OrbitEye.Application]
    G --> H[Interfaces]
    H --> I[OrbitEye.Infrastructure]
    I --> J[Repositories]
    J --> K[OrbitEyeDbContext]
    K --> L[Oracle Database]

    G --> M[OrbitEye.Domain]
    M --> N[Entities]
```

## Diagrama de Classes

```mermaid
classDiagram
    class Usuario {
        int Id
        string Nome
        string Email
        string Senha
        string Perfil
    }

    class Regiao {
        int Id
        string Nome
        string Estado
        double Latitude
        double Longitude
        string NivelRisco
    }

    class Alerta {
        int Id
        string Mensagem
        string Nivel
        DateTime DataEmissao
        int RegiaoId
    }

    class EventoClimatico {
        int Id
        string TipoEvento
        string Descricao
        DateTime DataEvento
        int RegiaoId
    }

    class PrevisaoIA {
        int Id
        double ProbabilidadeRisco
        string NivelPrevisto
        DateTime DataAnalise
        int RegiaoId
    }

    Regiao "1" --> "*" Alerta
    Regiao "1" --> "*" EventoClimatico
    Regiao "1" --> "*" PrevisaoIA
```

## Diagrama MER

```mermaid
erDiagram
    REGIOES ||--o{ ALERTAS : possui
    REGIOES ||--o{ EVENTOSCLIMATICOS : registra
    REGIOES ||--o{ PREVISOESIA : gera

    USUARIOS {
        int Id PK
        string Nome
        string Email
        string Senha
        string Perfil
    }

    REGIOES {
        int Id PK
        string Nome
        string Estado
        double Latitude
        double Longitude
        string NivelRisco
    }

    ALERTAS {
        int Id PK
        string Mensagem
        string Nivel
        datetime DataEmissao
        int RegiaoId FK
    }

    EVENTOSCLIMATICOS {
        int Id PK
        string TipoEvento
        string Descricao
        datetime DataEvento
        int RegiaoId FK
    }

    PREVISOESIA {
        int Id PK
        double ProbabilidadeRisco
        string NivelPrevisto
        datetime DataAnalise
        int RegiaoId FK
    }
```

---

# Modelo de Dados

O sistema possui as seguintes entidades:

## Usuario

- Id
- Nome
- Email
- Senha
- Perfil

## Regiao

- Id
- Nome
- Estado
- Latitude
- Longitude
- NivelRisco

## Alerta

- Id
- Mensagem
- Nivel
- DataEmissao
- RegiaoId

## EventoClimatico

- Id
- TipoEvento
- Descricao
- DataEvento
- RegiaoId

## PrevisaoIA

- Id
- ProbabilidadeRisco
- NivelPrevisto
- DataAnalise
- RegiaoId

---

# Segurança

A aplicação utiliza autenticação JWT.

Após realizar login:

```http
POST /api/Auth/login
```

é gerado um token JWT utilizado para acessar as rotas protegidas.

Exemplo:

```text
Bearer eyJhbGciOiJIUzI1Ni...
```

---

# Documentação da API

A documentação completa da API está disponível através do Swagger.

```text
https://localhost:7285/swagger
```

---

# Health Check

Endpoint utilizado para monitoramento da aplicação.

```text
https://localhost:7285/health
```

Retorno esperado:

```text
Healthy
```

---

# Endpoints Disponíveis

## Auth

### Login

```http
POST /api/Auth/login
```

## Usuários

```http
GET    /api/Usuarios
GET    /api/Usuarios/{id}
POST   /api/Usuarios
PUT    /api/Usuarios/{id}
DELETE /api/Usuarios/{id}
```

## Regiões

```http
GET    /api/Regioes
GET    /api/Regioes/{id}
POST   /api/Regioes
PUT    /api/Regioes/{id}
DELETE /api/Regioes/{id}
```

## Alertas

```http
GET    /api/Alertas
GET    /api/Alertas/{id}
POST   /api/Alertas
PUT    /api/Alertas/{id}
DELETE /api/Alertas/{id}
```

## Eventos Climáticos

```http
GET    /api/EventosClimaticos
GET    /api/EventosClimaticos/{id}
POST   /api/EventosClimaticos
PUT    /api/EventosClimaticos/{id}
DELETE /api/EventosClimaticos/{id}
```

## Previsões IA

```http
GET    /api/PrevisoesIA
GET    /api/PrevisoesIA/{id}
POST   /api/PrevisoesIA
PUT    /api/PrevisoesIA/{id}
DELETE /api/PrevisoesIA/{id}
```

---

# Como Executar o Projeto

## 1. Clonar o Repositório

```bash
git clone https://github.com/GabrielNakamura123456/OrbitEye.git
```

## 2. Configurar a conexão Oracle

Editar o arquivo:

```text
appsettings.json
```

configurando a string de conexão Oracle.

## 3. Aplicar as Migrations

```bash
dotnet ef database update
```

## 4. Executar a aplicação

```bash
dotnet run
```

ou executar diretamente pelo Visual Studio.

# Exemplos de Testes da API

## Login

### Request

```http
POST /api/Auth/login
```

```json
{
  "email": "admin@orbiteye.com",
  "senha": "123456"
}
```

### Response

```json
{
  "token": "eyJhbGciOiJIUzI1Ni..."
}
```

---

## Criar Região

### Request

```http
POST /api/Regioes
```

```json
{
  "nome": "São Paulo",
  "estado": "SP",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRisco": "ALTO"
}
```

### Response

```json
{
  "id": 1,
  "nome": "São Paulo",
  "estado": "SP",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRisco": "ALTO"
}
```

---

## Buscar Região

### Request

```http
GET /api/Regioes/1
```

### Response

```json
{
  "id": 1,
  "nome": "São Paulo",
  "estado": "SP",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRisco": "ALTO"
}
```

---

## Atualizar Região

### Request

```http
PUT /api/Regioes/1
```

```json
{
  "nome": "São Paulo",
  "estado": "SP",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRisco": "CRITICO"
}
```

### Response

```json
{
  "id": 1,
  "nome": "São Paulo",
  "estado": "SP",
  "latitude": -23.5505,
  "longitude": -46.6333,
  "nivelRisco": "CRITICO"
}
```

---

## Excluir Região

### Request

```http
DELETE /api/Regioes/1
```

### Response

```text
204 No Content
```
---

# Testes Automatizados

O projeto possui testes automatizados utilizando xUnit seguindo o padrão AAA (Arrange, Act, Assert).

## Testes Implementados

### RegiaoTests

Validação da criação de regiões.

### UsuarioTests

Validação da criação de usuários.

### PrevisaoIATests

Validação das previsões geradas pela IA.

## Execução dos Testes

```bash
dotnet test
```

ou através do Visual Studio:

```text
Teste → Executar Todos os Testes
```

## Resultado Obtido

```text
3 testes executados
3 testes aprovados
0 falhas
```

---

# Integrantes

| Nome | RM |
|--------|--------|
| Gabriel Nakamura Ogata | RM560671 |
| Julio Cesar Dias Vilella | RM560494 |
| Guilherme Costeira Braganholo | RM560628 |

---

# Link do video 
https://www.youtube.com/watch?v=nrwI3wgipj8

# Disciplina

Advanced Business Development with .NET

FIAP

---

# Objetivo

Demonstrar a construção de uma API REST utilizando ASP.NET Core, Oracle Database, JWT Authentication, Swagger, Health Checks e Testes Automatizados, aplicando boas práticas de desenvolvimento e arquitetura de software.
