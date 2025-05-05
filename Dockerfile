FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["StockiBotService/StockiBotService.csproj", "StockiBotService/"]

# Brings in any dependencies 
RUN dotnet restore "StockiBotService/StockiBotService.csproj"

COPY . .

WORKDIR /src/StockiBotService

RUN dotnet build "StockiBotService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StockiBotService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockiBotService.dll"]
