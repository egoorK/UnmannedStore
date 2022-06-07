#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BasketFormation/Presentation/BasketFormation.API/BasketFormation.API.csproj", "BasketFormation/Presentation/BasketFormation.API/"]
COPY ["BasketFormation/Core/BasketFormation.Application/BasketFormation.Application.csproj", "BasketFormation/Core/BasketFormation.Application/"]
COPY ["BasketFormation/Core/BasketFormation.Domain/BasketFormation.Domain.csproj", "BasketFormation/Core/BasketFormation.Domain/"]
COPY ["BasketFormation/Infrastructure/BasketFormation.Infrastructure/BasketFormation.Infrastructure.csproj", "BasketFormation/Infrastructure/BasketFormation.Infrastructure/"]
COPY ["BasketFormation/Infrastructure/BasketFormation.Persitence/BasketFormation.Persitence.csproj", "BasketFormation/Infrastructure/BasketFormation.Persitence/"]
RUN dotnet restore "BasketFormation/Presentation/BasketFormation.API/BasketFormation.API.csproj"
COPY . .
WORKDIR "/src/BasketFormation/Presentation/BasketFormation.API"
RUN dotnet build "BasketFormation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketFormation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketFormation.API.dll"]