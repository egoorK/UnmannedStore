#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Clients/Presentation/Clients.API/Clients.API.csproj", "Clients/Presentation/Clients.API/"]
COPY ["Clients/Core/Clients.Application/Clients.Application.csproj", "Clients/Core/Clients.Application/"]
COPY ["Clients/Core/Clients.Domain/Clients.Domain.csproj", "Clients/Core/Clients.Domain/"]
COPY ["Clients/Infrastructure/Clients.Persistence/Clients.Persistence.csproj", "Clients/Infrastructure/Clients.Persistence/"]
COPY ["Clients/Infrastructure/Clients.Infrastructure/Clients.Infrastructure.csproj", "Clients/Infrastructure/Clients.Infrastructure/"]
RUN dotnet restore "Clients/Presentation/Clients.API/Clients.API.csproj"
COPY . .
WORKDIR "/src/Clients/Presentation/Clients.API"
RUN dotnet build "Clients.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clients.API.dll"]
