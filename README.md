# 🅿️ Estacionamento Central Park — Sistema de Gestão

Sistema completo de gerenciamento de estacionamento desenvolvido em **C# (ASP.NET Core)** com banco de dados **SQL Server** e interface web em **HTML/CSS/JavaScript**.

---

## 🚀 Tecnologias utilizadas

- **Backend:** C# / ASP.NET Core Web API
- **Banco de dados:** SQL Server (Entity Framework Core)
- **Autenticação:** JWT (JSON Web Token)
- **Frontend:** HTML, CSS, JavaScript puro

---

## 📋 Funcionalidades

- ✅ Login com autenticação JWT
- ✅ Visualização de 18 vagas em tempo real
- ✅ Registro de entrada e saída de veículos
- ✅ Cadastro de veículos (Carro/Moto)
- ✅ Cadastro de clientes
- ✅ Relatório de entradas e saídas com tempo de permanência
- ✅ Gerenciamento de usuários (somente Admin)
- ✅ Proteção de rotas sem login

---

## ⚙️ Como rodar o projeto

### Pré-requisitos
- .NET 10 SDK
- SQL Server (Express ou superior)
- Visual Studio Code

### Passo a passo

1. Clone ou baixe o projeto
2. Abra a pasta no VS Code
3. Configure a string de conexão no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SistemaGestao;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Crie o banco de dados no SQL Server Management Studio:

```sql
CREATE DATABASE SistemaGestao
```

5. No terminal, rode:

```
dotnet run
```

6. Acesse no navegador: `http://localhost:5105/index.html`

---

## 👤 Usuário padrão

| Campo | Valor |
|-------|-------|
| Usuário | admin |
| Senha | admin123 |

---

## 📁 Estrutura do projeto

```
SistemaGestao.API/
├── Controllers/
│   ├── AuthController.cs
│   ├── VeiculoController.cs
│   ├── ClienteController.cs
│   └── OcupacaoController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Usuario.cs
│   ├── Veiculo.cs
│   ├── Cliente.cs
│   └── Ocupacao.cs
├── wwwroot/
│   ├── index.html
│   ├── dashboard.html
│   ├── cadastro-veiculo.html
│   ├── cadastro-cliente.html
│   ├── relatorio.html
│   └── usuario.html
├── appsettings.json
└── Program.cs
```

---

## 📊 Banco de dados

Tabelas criadas:
- `Usuarios` — usuários do sistema
- `Veiculos` — veículos cadastrados
- `Clientes` — clientes cadastrados
- `Ocupacoes` — registro de entradas e saídas

---

## 🗄️ Scripts SQL

```sql
-- Criar banco
CREATE DATABASE SistemaGestao

-- Adicionar coluna Admin
ALTER TABLE Usuarios ADD IsAdmin BIT NOT NULL DEFAULT 0

-- Criar tabela Veiculos
CREATE TABLE Veiculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo NVARCHAR(50) NOT NULL,
    Placa NVARCHAR(20) NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    Cor NVARCHAR(50) NOT NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT GETDATE()
)

-- Criar tabela Clientes
CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(20) NOT NULL,
    Telefone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT GETDATE()
)

-- Criar tabela Ocupacoes
CREATE TABLE Ocupacoes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroVaga INT NOT NULL,
    VeiculoId INT NOT NULL,
    ClienteId INT NOT NULL,
    DataEntrada DATETIME2 NOT NULL DEFAULT GETDATE(),
    DataSaida DATETIME2 NULL
)

-- Criar usuário Admin (senha: admin123)
UPDATE Usuarios 
SET SenhaHash = '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9',
    IsAdmin = 1
WHERE Email = 'admin'
```

---

Desenvolvido usando C# e SQL Server.
