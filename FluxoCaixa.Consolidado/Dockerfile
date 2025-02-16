FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5001
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluxoCaixa.Consolidado/FluxoCaixa.Consolidado.csproj", "FluxoCaixa.Consolidado/"]
COPY ["FluxoCaixa.Lancamentos/FluxoCaixa.Lancamentos.csproj", "FluxoCaixa.Lancamentos/"]
RUN dotnet restore "FluxoCaixa.Consolidado/FluxoCaixa.Consolidado.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa.Consolidado"
RUN dotnet build "FluxoCaixa.Consolidado.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FluxoCaixa.Consolidado.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.Consolidado.dll"]
