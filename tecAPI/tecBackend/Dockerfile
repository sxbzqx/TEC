# Step 1: Runtime .NET 10
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Step 2: SDK .NET 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Настройки для защиты от таймаутов NuGet
ENV NUGET_HTTP_POLICY_CONFIG_HTTPRETRYMAXRETRIES=5
ENV NUGET_HTTP_POLICY_CONFIG_HTTPRETRYTIMEOUT=300

# 1. Копируем решение и файл проекта
COPY ["tecAPI.sln", "./"]
COPY ["tecBackend/tecBackend.csproj", "tecBackend/"]

# 2. Восстанавливаем пакеты с использованием BuildKit-кэша
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore "tecBackend/tecBackend.csproj"

# 3. Копируем весь остальной код бэкенда
COPY ["tecBackend/", "tecBackend/"]

# 4. Собираем и публикуем
WORKDIR "/src/tecBackend"
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish "tecBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Step 3: Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "tecBackend.dll"]