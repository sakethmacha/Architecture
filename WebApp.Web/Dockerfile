# =========================
# BUILD STAGE (.NET 9)
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

COPY WebApp.Web/WebApp.Web.csproj WebApp.Web/
COPY WebApp.Application/WebApp.Application.csproj WebApp.Application/
COPY WebApp.Domain/WebApp.Domain.csproj WebApp.Domain/
COPY WebApp.Infrastructure/WebApp.Infrastructure.csproj WebApp.Infrastructure/

RUN dotnet restore WebApp.Web/WebApp.Web.csproj

COPY . .
RUN dotnet publish WebApp.Web/WebApp.Web.csproj -c Release -o /app/publish

# =========================
# RUNTIME STAGE (.NET 9)
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApp.Web.dll"]
