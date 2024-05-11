# Build env used only in building process
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

COPY AuthService.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app .

ENTRYPOINT ["dotnet", "AuthService.dll"]
