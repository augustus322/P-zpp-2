ARG DOTNET_VERSION=8

FROM bitnami/aspnet-core:${DOTNET_VERSION} AS base
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

# http port
EXPOSE 80

#EXPOSE 443

FROM bitnami/dotnet-sdk:${DOTNET_VERSION} AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthService/AuthService.csproj", "AuthService/"]
RUN dotnet restore "AuthService/AuthService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "AuthService/AuthService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AuthService/AuthService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.dll"]
