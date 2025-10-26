FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["src/ApiMarcas/ApiMarcas.csproj", "src/ApiMarcas/"]
RUN dotnet restore "src/ApiMarcas/ApiMarcas.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/src/ApiMarcas"
RUN dotnet build "ApiMarcas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiMarcas.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "ApiMarcas.dll"]

