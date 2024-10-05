#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebAPIeshop/WebAPIeshop.csproj", "WebAPIeshop/"]
COPY ["DataAccessEF/DataAccessEF.csproj", "DataAccessEF/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "WebAPIeshop/WebAPIeshop.csproj"
COPY . .
WORKDIR "/src/WebAPIeshop"
RUN dotnet build "./WebAPIeshop.csproj" -c Release -o app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAPIeshop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIeshop.dll"]