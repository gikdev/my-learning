# Setup

Steps I took to create the project:

```sh
rm -rf src

mkdir src
cd src

dotnet new webapi -controllers -o GymManagement.Api
dotnet new classlib -o GymManagement.Application
dotnet new classlib -o GymManagement.Infrastructure
dotnet new classlib -o GymManagement.Domain
dotnet new classlib -o GymManagement.Contracts

dotnet add GymManagement.Api reference GymManagement.Application
dotnet add GymManagement.Infrastructure reference GymManagement.Application
dotnet add GymManagement.Application reference GymManagement.Domain
dotnet add GymManagement.Api reference GymManagement.Contracts
dotnet add GymManagement.Api reference GymManagement.Infrastructure

cd ..

dotnet sln add src/GymManagement.Api/GymManagement.Api.csproj
dotnet sln add src/GymManagement.Application/GymManagement.Application.csproj
dotnet sln add src/GymManagement.Infrastructure/GymManagement.Infrastructure.csproj
dotnet sln add src/GymManagement.Domain/GymManagement.Domain.csproj
dotnet sln add src/GymManagement.Contracts/GymManagement.Contracts.csproj

dotnet add src/GymManagement.Application package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add src/GymManagement.Application package MediatR
dotnet add src/GymManagement.Application package ErrorOr
dotnet add src/GymManagement.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add src/GymManagement.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite
dotnet add src/GymManagement.Api package Microsoft.EntityFrameworkCore.Design
dotnet add src/GymManagement.Domain package Ardalis.SmartEnum

dotnet ef migrations add InitialCreate -p src/GymManagement.Infrastructure -s src/GymManagement.Api
dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api

dotnet ef migrations add Enhance -p src/GymManagement.Infrastructure -s src/GymManagement.Api
dotnet ef database update -p src/GymManagement.Infrastructure -s src/GymManagement.Api


```
