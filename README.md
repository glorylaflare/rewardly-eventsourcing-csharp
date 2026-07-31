# ✈️ Rewardly — API de Pontos de Fidelidade

O Rewardly é um projeto backend voltado para estudo que simula um programa de fidelidade de uma companhia aérea.

O sistema gerencia contas de recompensa de usuários, permitindo acumular, resgatar e controlar pontos através de uma arquitetura orientada a eventos.

O foco principal do projeto é aplicar conceitos avançados de arquitetura como **CQRS**, **Event Sourcing** e **Domain-Driven Design (DDD)** de forma prática e bem estruturada.

---

## 🚀 Objetivo

O objetivo deste projeto não é a complexidade do negócio, mas sim a **qualidade da arquitetura**.

Ele foi idealizado para demonstrar:

* Separação clara entre escrita e leitura (CQRS)
* Rastreamento completo de mudanças via Event Sourcing
* Modelagem de domínio com DDD
* Boas práticas de observabilidade e logging
* Processamento idempotente de comandos

---

## 🧠 Conceitos e Padrões

O projeto utiliza os seguintes princípios:

* CQRS (Command Query Responsibility Segregation)
* Event Sourcing
* Event Store (MongoDB)
* Read Model (SQL Server)
* Domain-Driven Design (DDD)
* Princípios SOLID
* Programação Orientada a Objetos (POO)
* Repository Pattern
* Factory Pattern (quando aplicável)
* Specification Pattern
* Strategy Pattern
* Notification Pattern
* Pipeline Behaviors (implementação própria, sem MediatR)
* Idempotência
* Observabilidade com Grafana

---

## 🏗️ Visão de Arquitetura

O sistema é dividido em dois lados principais:

### Write Side (Comandos)

* Recebe comandos
* Aplica regras de negócio
* Gera eventos de domínio
* Persiste eventos no MongoDB

### Read Side (Consultas)

* Otimizado para leitura
* Baseado em projeções
* Armazenado no SQL Server

---

## 📦 Domínio

O principal Aggregate do sistema é:

```text
RewardAccount
```

Cada conta é identificada por um **UserId** (proveniente de outro sistema) e possui:

* Saldo de pontos
* Status da conta (Active, Blocked, Cancelled)
* Histórico de transações baseado em eventos

---

## 📌 Eventos de Domínio

Todas as mudanças de estado são representadas por eventos:

* RewardAccountCreated
* PointsCredited
* PointsDebited
* PointsExpired
* RewardAccountCancelled
* RewardAccountBlocked
* RewardRedeemed

---

## ⚙️ Funcionalidades (Planejadas)

* Criar conta de fidelidade
* Creditar pontos
* Resgatar recompensas (uso de pontos)
* Expiração de pontos (após 90 dias)
* Cancelamento de conta
* Bloqueio de conta
* Histórico completo de transações
* Processamento idempotente

---

## 🛠️ Tecnologias

* .NET (C#)
* MongoDB (Event Store)
* SQL Server (Read Model)
* Docker (planejado)
* Grafana + Prometheus (planejado)
* GitHub Actions (CI/CD planejado)

---

## 🔍 Observabilidade (Planejado)

O sistema irá expor métricas como:

* Total de pontos creditados/debitados
* Quantidade de transações
* Latência de processamento de eventos
* Atraso nas projeções (projection lag)

---

## 🧪 Status do Projeto

🚧 **Em desenvolvimento**

Este projeto está sendo desenvolvido de forma incremental, seguindo sprints.

---

## 📌 Observações

* O sistema **não armazena dados pessoais** (nome, CPF, etc.)
* Usuários são identificados apenas por um **UserId**
* O foco é arquitetura backend (sem interface gráfica)

---

## 🎯 Motivação

Este projeto faz parte de um esforço pessoal para aprofundar conhecimentos em:

* Arquitetura de software
* Sistemas distribuídos
* Event-driven design
* Boas práticas de backend

---

## 📄 Licença

Projeto desenvolvido para fins educacionais.
