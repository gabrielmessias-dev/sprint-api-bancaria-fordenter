# 💰 API Bancária - Ford Enter

## 📌 Sobre o Projeto

API bancária desenvolvida com **ASP.NET Core (.NET 8)**, seguindo os princípios da **arquitetura REST**, com autenticação via **JWT (JSON Web Token)** e documentação interativa com **Swagger**.

O sistema simula operações bancárias reais, incluindo:

* 👤 Gerenciamento de clientes
* 💳 Gerenciamento de contas
* 💸 Transações (Depósito, Saque e Transferência)

---

## 🚀 Tecnologias Utilizadas

* ASP.NET Core (.NET 8)
* Entity Framework Core
* MySQL
* Pomelo (MySQL Provider)
* Swagger (OpenAPI)
* JWT Authentication

---

## 🏗️ Arquitetura

O projeto segue arquitetura em camadas:

```bash
Controllers → Services → Repositories → Database
```

### 📂 Estrutura

* **Controllers** → Endpoints da API
* **Services** → Regras de negócio
* **Repositories** → Acesso ao banco
* **Models** → Entidades
* **DTOs** → Transferência de dados
* **Middlewares** → Tratamento de erros

---

## 🗂️ Modelagem

### 📌 Entidades

#### 👤 Cliente

* Id
* Nome
* CPF
* Senha

#### 💳 Conta

* Id
* Número
* Saldo
* ClienteId

#### 💸 Transação

* Id
* Valor
* Tipo (Depósito, Saque, Transferência)
* Data
* ContaId

---

### 🔗 Relacionamentos

* Um **Cliente** possui várias **Contas**
* Uma **Conta** possui várias **Transações**

---

## 🌐 Arquitetura REST

A API segue os princípios REST:

* Comunicação via JSON
* Stateless
* Uso correto dos métodos HTTP
* URLs semânticas

---

## 🔄 Métodos HTTP

| Método | Descrição       |
| ------ | --------------- |
| GET    | Buscar dados    |
| POST   | Criar dados     |
| PUT    | Atualizar dados |
| DELETE | Remover dados   |

---

## 📡 Status Codes

| Código | Descrição           |
| ------ | ------------------- |
| 200    | OK                  |
| 201    | Criado              |
| 400    | Requisição inválida |
| 401    | Não autorizado      |
| 404    | Não encontrado      |
| 500    | Erro interno        |

---

## 🔐 Autenticação JWT

A API utiliza autenticação baseada em **JWT**.

### 🔑 Fluxo de autenticação

1. O usuário realiza login com CPF e senha
2. A API gera um token JWT
3. O token deve ser enviado nas requisições protegidas

### 📌 Exemplo

```http
Authorization: Bearer SEU_TOKEN_AQUI
```

---

## 💸 Transações

### ✔️ Tipos suportados

* **Depósito** → Adiciona saldo à conta
* **Saque** → Remove saldo da conta
* **Transferência** → Move saldo entre contas

---

### 🔁 Transferência (Destaque do Projeto)

A transferência realiza:

* Débito na conta de origem
* Crédito na conta de destino
* Registro de duas transações:

  * Saída (Transferência)
  * Entrada (Depósito)

---

### 📌 Exemplo de requisição (Transferência)

```json
{
  "valor": 100,
  "tipo": 3,
  "contaId": 1,
  "contaDestinoId": 2
}
```

---

## 🧪 Swagger

A API possui documentação interativa.

### ▶️ Acesso

```bash
http://localhost:5104/swagger
```

### 🔐 Como autenticar

1. Fazer login
2. Copiar o token
3. Clicar em **Authorize 🔒**
4. Inserir:

```bash
Bearer SEU_TOKEN
```

---

## 🗄️ Banco de Dados

* MySQL
* Entity Framework Core
* Migrations

---

## 🚀 Como Executar

### 1. Clonar o projeto

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
```

---

### 2. Configurar banco

No `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=api_bancaria;user=root;password=sua_senha"
}
```

---

### 3. Aplicar migrations

```bash
dotnet ef database update
```

---

### 4. Executar projeto

```bash
dotnet run
```

---

## 📌 Endpoints

### 🔐 Auth

* `POST /api/Auth/login`

### 👤 Clientes

* `POST /api/Clientes`
* `GET /api/Clientes`
* `GET /api/Clientes/{id}`
* `PUT /api/Clientes/{id}`
* `DELETE /api/Clientes/{id}`

### 💳 Contas

* `POST /api/Contas`
* `GET /api/Contas/{id}`

### 💸 Transações

* `POST /api/Transacoes/deposito`
* `POST /api/Transacoes/saque`
* `POST /api/Transacoes/transferencia`

---

## ⚠️ Tratamento de Erros

A API utiliza middleware global para:

* Padronização de respostas
* Melhor controle de exceções
* Retorno adequado de status HTTP

---

## 🔍 Validações

* `[Required]`
* `[MinLength]`
* `[MaxLength]`

---

## 👨‍💻 Autor

**Gabriel Messias**

---

## ⭐ Considerações Finais

Este projeto demonstra:

* Aplicação prática de arquitetura REST
* Implementação de autenticação com JWT
* Uso de Entity Framework Core
* Estrutura profissional em camadas
* Simulação de operações bancárias reais

---
