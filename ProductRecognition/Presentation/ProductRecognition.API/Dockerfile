#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProductRecognition/Presentation/ProductRecognition.API/ProductRecognition.API.csproj", "ProductRecognition/Presentation/ProductRecognition.API/"]
COPY ["ProductRecognition/Infrastructure/ProductRecognition.Persistence/ProductRecognition.Persistence.csproj", "ProductRecognition/Infrastructure/ProductRecognition.Persistence/"]
COPY ["ProductRecognition/Core/ProductRecognition.Application/ProductRecognition.Application.csproj", "ProductRecognition/Core/ProductRecognition.Application/"]
COPY ["ProductRecognition/Core/ProductRecognition.Domain/ProductRecognition.Domain.csproj", "ProductRecognition/Core/ProductRecognition.Domain/"]
COPY ["ProductRecognition/Infrastructure/ProductRecognition.Infrastructure/ProductRecognition.Infrastructure.csproj", "ProductRecognition/Infrastructure/ProductRecognition.Infrastructure/"]
RUN dotnet restore "ProductRecognition/Presentation/ProductRecognition.API/ProductRecognition.API.csproj"
COPY . .
WORKDIR "/src/ProductRecognition/Presentation/ProductRecognition.API"
RUN dotnet build "ProductRecognition.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductRecognition.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductRecognition.API.dll"]