# 💰 API Bancária - Ford Enter (Full Stack)

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/C%23-Backend-239120?style=for-the-badge&logo=csharp" />
  <img src="https://img.shields.io/badge/React-Frontend-61DAFB?style=for-the-badge&logo=react" />
  <img src="https://img.shields.io/badge/PostgreSQL-Database-336791?style=for-the-badge&logo=postgresql" />
  <img src="https://img.shields.io/badge/Docker-Container-2496ED?style=for-the-badge&logo=docker" />
  <img src="https://img.shields.io/badge/Render-Deploy-46E3B7?style=for-the-badge&logo=render" />
</p>

---

## 📌 Sobre o Projeto

Sistema bancário completo desenvolvido com **arquitetura unificada (Modern Monolith)**.

O backend em **.NET 8** também serve o frontend em **React** via pasta `wwwroot`, eliminando problemas de CORS e simplificando o deploy.

---

## 🧠 Diferencial Técnico (Arquitetura)

Este projeto utiliza **SPA Hosting (Single Page Application Hosting)** com ASP.NET Core.

* API + Frontend no mesmo servidor
* React buildado dentro do backend
* Sem problemas de CORS
* Deploy simplificado

---

## 🚀 Tech Stack

### 🔧 Backend

* C# (.NET 8)
* Entity Framework Core
* JWT Authentication
* Swagger / OpenAPI

### 🎨 Frontend

* React (Vite)
* Tailwind CSS
* Axios
* React Router DOM

### 🗄️ Banco de Dados

* PostgreSQL

### ☁️ Infraestrutura

* Docker
* Render

---

## ⚙️ Funcionalidades

* 🔐 Autenticação com JWT
* 👤 CRUD de Clientes
* 💳 CRUD de Contas
* 💸 Depósito, Saque e Transferência
* 📄 Extrato bancário
* 📚 Swagger integrado

---

## 🔐 Autenticação

```http
Authorization: Bearer SEU_TOKEN
```

---

## 📡 Endpoints

### 🔑 Auth

| Método | Endpoint        |
| ------ | --------------- |
| POST   | /api/Auth/login |

### 👤 Clientes

| Método | Endpoint           |
| ------ | ------------------ |
| POST   | /api/Clientes      |
| GET    | /api/Clientes      |
| GET    | /api/Clientes/{id} |
| PUT    | /api/Clientes/{id} |
| DELETE | /api/Clientes/{id} |

### 💳 Contas

| Método | Endpoint                        |
| ------ | ------------------------------- |
| POST   | /api/Contas                     |
| GET    | /api/Contas/{id}                |
| GET    | /api/Contas/cliente/{clienteId} |

### 💸 Transações

| Método | Endpoint                        |
| ------ | ------------------------------- |
| POST   | /api/Transacoes/deposito        |
| POST   | /api/Transacoes/saque           |
| POST   | /api/Transacoes/transferencia   |
| GET    | /api/Transacoes/conta/{contaId} |

---

## ▶️ Como Rodar

```bash
git clone https://github.com/gabrielmessias-dev/sprint-api-bancaria-fordenter.git
cd sprint-api-bancaria-fordenter
dotnet run
```

### 📍 Acesse:

* http://localhost:5104
* http://localhost:5104/swagger

---

## 🌐 Produção

👉 https://sprint-api-bancaria-fordenter-csharp.onrender.com/

---

## 👨‍💻 Autor

**Gabriel Messias**
Analista de Sistemas

* GitHub: https://github.com/gabrielmessias-dev
* LinkedIn: https://linkedin.com

---

## ⭐ Destaques

* 🚀 Arquitetura Modern Monolith
* 🔐 JWT Authentication
* 📦 SPA Hosting
* 💻 Backend + Frontend unificados
