#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_VERSION=8

FROM bitnami/aspnet-core:${DOTNET_VERSION} AS base
#USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# http port
EXPOSE 80

#EXPOSE 443

FROM bitnami/dotnet-sdk:${DOTNET_VERSION} AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DatabaseService/DatabaseService.csproj", "DatabaseService/"]
RUN dotnet restore "./DatabaseService/DatabaseService.csproj"
COPY . .
WORKDIR "/src/DatabaseService"
RUN dotnet build "./DatabaseService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DatabaseService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatabaseService.dll"]
