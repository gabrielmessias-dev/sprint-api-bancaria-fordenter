# 💰 API Bancária - Ford Enter

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![MySQL](https://img.shields.io/badge/MySQL-Database-blue)
![JWT](https://img.shields.io/badge/Auth-JWT-green)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)

------------------------------------------------------------------------

## 📌 Sobre o Projeto

API bancária desenvolvida com **ASP.NET Core (.NET 8)**, seguindo
princípios de **arquitetura REST**, com autenticação via **JWT** e
documentação com **Swagger**.

Este projeto simula um sistema bancário real, incluindo:

-   👤 Cadastro e gerenciamento de clientes\
-   💳 Criação e gerenciamento de contas\
-   💸 Transações financeiras (Depósito, Saque e Transferência)\
-   📄 Extrato bancário

------------------------------------------------------------------------

## 🧠 Arquitetura

Arquitetura em camadas:

Controllers → Services → Repositories → Database

Separação clara de responsabilidades:

-   Controllers: entrada HTTP\
-   Services: regras de negócio\
-   Repositories: persistência\
-   Models/DTOs: estrutura de dados

------------------------------------------------------------------------

## 🚀 Tecnologias

-   ASP.NET Core (.NET 8)
-   Entity Framework Core
-   MySQL
-   Pomelo Provider
-   JWT Authentication
-   Swagger (OpenAPI)

------------------------------------------------------------------------

## 🔐 Autenticação

Fluxo:

1.  Login com CPF + senha\
2.  Retorno de token JWT\
3.  Token enviado nas requisições

Exemplo:

Authorization: Bearer SEU_TOKEN

------------------------------------------------------------------------

## 📄 Extrato Bancário

Endpoint:

GET /api/Transacoes/conta/{contaId}

Retorna todas as transações da conta:

-   Tipo
-   Valor
-   Data

------------------------------------------------------------------------

## 💸 Transações

Tipos:

-   Depósito\
-   Saque\
-   Transferência

Transferência realiza:

-   Débito na origem\
-   Crédito no destino\
-   Registro duplo no histórico

------------------------------------------------------------------------

## 📌 Endpoints

### Auth

POST /api/Auth/login

### Clientes

POST /api/Clientes\
GET /api/Clientes\
GET /api/Clientes/{id}\
PUT /api/Clientes/{id}\
DELETE /api/Clientes/{id}

### Contas

POST /api/Contas\
GET /api/Contas/{id}\
GET /api/Contas/cliente/{clienteId}

### Transações

POST /api/Transacoes/deposito\
POST /api/Transacoes/saque\
POST /api/Transacoes/transferencia\
GET /api/Transacoes/conta/{contaId}

------------------------------------------------------------------------

## 🗄️ Banco de Dados

-   MySQL
-   EF Core
-   Migrations

------------------------------------------------------------------------

## 🚀 Como Rodar

git clone
https://github.com/gabrielmessias-dev/sprint-api-bancaria-fordenter.git

cd sprint-api-bancaria-fordenter

dotnet ef database update

dotnet run

------------------------------------------------------------------------

## 🧪 Swagger

http://localhost:xxxx/swagger

------------------------------------------------------------------------

## ⚠️ Tratamento de Erros

Middleware global para:

-   Padronização
-   Logs
-   Status HTTP corretos

------------------------------------------------------------------------

## 👨‍💻 Autor

Gabriel Messias

------------------------------------------------------------------------

## ⭐ Destaques

-   Arquitetura limpa\
-   JWT implementado\
-   CRUD completo\
-   Transações financeiras reais\
-   Extrato bancário funcional

------------------------------------------------------------------------

## 🚀 Próximos passos

-   Deploy em produção\
-   Dashboard financeiro\
-   Filtros no extrato\
-   UI completa em React
