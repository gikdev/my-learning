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

cd ..

dotnet sln add src/GymManagement.Api/GymManagement.Api.csproj
dotnet sln add src/GymManagement.Application/GymManagement.Application.csproj
dotnet sln add src/GymManagement.Infrastructure/GymManagement.Infrastructure.csproj
dotnet sln add src/GymManagement.Domain/GymManagement.Domain.csproj
dotnet sln add src/GymManagement.Contracts/GymManagement.Contracts.csproj

```
