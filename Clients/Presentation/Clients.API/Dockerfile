#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80		
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/Clients/Presentation/Clients.API/Clients.API.csproj", "Services/Clients/Presentation/Clients.API/"]
COPY ["Services/Clients/Core/Clients.Domain/Clients.Domain.csproj", "Services/Clients/Core/Clients.Domain/"]
COPY ["Services/Clients/Core/Clients.Application/Clients.Application.csproj", "Services/Clients/Core/Clients.Application/"]
COPY ["Services/Clients/Infrastructure/Clients.Persistence/Clients.Persistence.csproj", "Services/Clients/Infrastructure/Clients.Persistence/"]
#COPY ["Services/Clients/Infrastructure/Clients.Infrastructure/Clients.Infrastructure.csproj", "Services/Clients/Infrastructure/Clients.Infrastructure/"]
RUN dotnet restore "Services/Clients/Presentation/Clients.API/Clients.API.csproj"
COPY . .
WORKDIR "/src/Services/Clients/Presentation/Clients.API"
RUN dotnet build "Clients.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clients.API.dll"]