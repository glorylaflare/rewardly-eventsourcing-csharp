# Personal.EventSourcing.Rewardly - API de Pontos com Event Sourcing

Rewardly é um projeto backend de estudo que simula um programa de fidelidade de companhia aérea.

O objetivo principal é exercitar decisões arquiteturais em um contexto de negócio simples: gerir contas de recompensa, acumulação e consumo de pontos, com trilha completa de eventos.

## Intenção de Negócio

No contexto de programas de fidelidade, a confiança no saldo e no histórico de movimentações é essencial.

Este projeto modela esse problema com foco em:

- rastreabilidade das mudanças de estado;
- consistência das regras de negócio no agregado;
- separação entre processamento de comandos (write side) e consultas (read side).

## Estado Atual do Projeto

Status de referência: 2026-07-31.

| Item | Estado Atual |
| --- | --- |
| Build da solução | Concluído com sucesso (`dotnet build`) |
| Execução da API | Não inicializa no momento por erro de DI no bootstrap |
| Testes automatizados | Projetos de teste criados, sem casos implementados |
| Write Side (comandos e domínio) | Parcialmente implementado |
| Read Side (projeções e consultas) | Não implementado |
| Observabilidade (métricas/tracing) | Planejado |
| CI/CD | Planejado |

Este é um projeto em desenvolvimento ativo e incremental. O objetivo atual é consolidar a base de Event Sourcing no write side antes da evolução do read side.

## Arquitetura

### Write Side (implementado em progresso)

- API HTTP para recebimento de comandos.
- Camada de aplicação com Command Bus e pipeline próprios.
- Agregado de domínio `RewardlyAccount` com regras de negócio.
- Persistência orientada a eventos em MongoDB (Event Store).

### Read Side (planejado)

- Projeções para modelo de leitura.
- Persistência otimizada para consulta (SQL Server).
- Endpoints de consulta e histórico materializado.

## Domínio Atual

Aggregate root principal: `RewardlyAccount`

Entidades/objetos de valor relevantes:

- saldo (`Balance`);
- status da conta (`Active`, `Blocked`, `Cancelled`).

Regras de negócio já modeladas:

- somente contas ativas podem sofrer crédito, débito, resgate e expiração;
- pontos devem ser maiores que zero;
- débito/resgate exigem saldo suficiente;
- cancelamento não é permitido com saldo positivo;
- bloqueio/cancelamento repetidos não geram novo evento.

## Eventos de Domínio Modelados

- `AccountCreated`
- `AccountBlocked`
- `AccountCancelled`
- `PointsCredited`
- `PointsDebited`
- `PointsExpired`
- `RewardRedeemed`

## API de Comandos (v1)

Base route: `/api/v1/rewardly`

| Endpoint | Objetivo | Payload |
| --- | --- | --- |
| `POST /account` | Criar conta de recompensa | `{ "userId": "guid" }` |
| `POST /block` | Bloquear conta | `{ "aggregateId": "guid", "reason": "string" }` |
| `POST /cancel` | Cancelar conta | `{ "aggregateId": "guid", "reason": "string" }` |
| `POST /credit` | Creditar pontos | `{ "aggregateId": "guid", "points": 100, "reason": "string" }` |
| `POST /debit` | Debitar pontos | `{ "aggregateId": "guid", "points": 100, "reason": "string" }` |
| `POST /redeem` | Resgatar recompensa | `{ "aggregateId": "guid", "rewardId": "guid", "points": 100 }` |

Resposta padrão: envelope `ResponseBase<T>`.

## Stack Tecnológica

- .NET 8
- ASP.NET Core Web API
- MongoDB (Event Store)
- xUnit (estrutura de testes)
- Dockerfile para conteinerização da API

## Como Executar Localmente

### Pre-requisitos

- .NET SDK 8
- MongoDB disponível localmente ou remoto

### Configuração

1. Ajuste a `ConnectionString` em `src/Rewardly.Api/appsettings.Development.json`.
2. Opcionalmente ajuste `DatabaseName` conforme o ambiente.

### Comandos

```bash
dotnet build .\Personal.EventSourcing.Rewardly.slnx
dotnet run --project .\src\Rewardly.Api\Rewardly.Api.csproj
```

Observação importante: no estado atual, a API falha na inicialização por configuração de DI pendente no módulo de aplicação.

## Principais Gaps para Proximas Sprints

- corrigir composição de DI do pipeline/command invoker;
- registrar handlers de comando automaticamente (ou explicitamente);
- finalizar configuração de acesso ao MongoDB (client/database/collection);
- implementar read side e projeções em SQL Server;
- criar cobertura de testes unitários e de integração;
- incluir idempotência de comandos e observabilidade operacional.

## Observações

- o sistema não armazena dados pessoais sensíveis (nome, CPF etc.);
- o identificador de usuário é tratado como `UserId` externo;
- o foco do repositório é arquitetura backend e evolução técnica.

## Licença

Projeto para fins educacionais.
