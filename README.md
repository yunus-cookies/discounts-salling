# Discounts Salling

A full-stack web application for managing and displaying discounts/deals, built with modern technologies and deployed on Azure.

## 🏗️ Architecture

This project consists of three main components:

- **Backend API** (`ds-api/`): .NET 8.0 ASP.NET Core Web API with PostgreSQL database
- **Frontend Web App** (`ds-web/`): Next.js 16 web application with React 19 and Tailwind CSS
- **Infrastructure** (`main.tf`): Terraform configuration for Azure cloud resources

## 🛠️ Tech Stack

### Backend
- **.NET 8.0** - ASP.NET Core Web API
- **Entity Framework Core** - ORM for database operations
- **PostgreSQL** - Relational database
- **Swagger/OpenAPI** - API documentation

### Frontend
- **Next.js 16** - React framework
- **React 19** - UI library
- **TypeScript** - Type-safe JavaScript
- **Tailwind CSS** - Utility-first CSS framework

### Infrastructure & DevOps
- **Terraform** - Infrastructure as Code (IaC)
- **Azure** - Cloud hosting platform
  - Azure Resource Group
  - Azure App Service Plan (Linux)
  - Azure Linux Web App
- **Docker Compose** - Local development environment
- **PostgreSQL** - Local database instance
- **Adminer** - Database management tool

## 📁 Project Structure

```
discounts-salling/
├── ds-api/              # .NET 8.0 Backend API
│   ├── Data/            # Database context and entities
│   ├── Program.cs       # Application entry point
│   └── Dockerfile       # Container configuration
├── ds-web/              # Next.js Frontend Application
│   ├── app/             # Next.js app directory
│   └── public/          # Static assets
├── main.tf              # Terraform infrastructure configuration
├── compose.yaml         # Docker Compose for local development
└── README.md            # This file
```

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (v18 or higher)
- [Docker](https://www.docker.com/) and Docker Compose
- [Terraform](https://www.terraform.io/downloads) (>= 1.1.0)
- Azure CLI (for Terraform deployment)

### Local Development

1. **Start the database**:
   ```bash
   docker compose up -d
   ```
   This starts PostgreSQL on port 5432 and Adminer on port 8080.

2. **Run the API**:
   ```bash
   cd ds-api
   dotnet run
   ```
   The API will be available at `https://localhost:5001` (or `http://localhost:5000`).

3. **Run the web app**:
   ```bash
   cd ds-web
   npm install
   npm run dev
   ```
   The web app will be available at `http://localhost:3000`.

### Database Access

- **Adminer**: http://localhost:8080
  - System: PostgreSQL
  - Server: db
  - Username: discounts-salling-postgres-admin
  - Password: example
  - Database: discounts-salling-postgres

## ☁️ Azure Deployment

### Initialize Terraform

```bash
terraform init
```

### Plan Infrastructure Changes

```bash
terraform plan
```

### Apply Infrastructure

```bash
terraform apply
```

This will create:
- Azure Resource Group: `discounts-salling-resource-group`
- Azure Service Plan: `discounts-salling-service-plan` (F1 Free tier)
- Azure Linux Web App: `discounts-salling-api`

## 📝 Notes

- The Terraform configuration uses the **F1 Free tier** service plan, which has limitations (e.g., `always_on` must be `false`).
- State files (`terraform.tfstate*`) are ignored by `.gitignore` for security reasons.
- The `.terraform.lock.hcl` file should be committed to ensure consistent provider versions.

## 🔒 Security

- Never commit sensitive files like `terraform.tfstate`, `*.tfvars` (if containing secrets), or `.env` files.
- Use Azure Key Vault or environment variables for production secrets.

## 📄 License

[Add your license here]
