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
