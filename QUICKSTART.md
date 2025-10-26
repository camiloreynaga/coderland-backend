# 🚀 Inicio Rápido - Coderland Backend

## Opción más rápida: Docker Compose

Si tienes Docker instalado, puedes ejecutar todo sin necesidad de instalar .NET:

```bash
# Levantar API + PostgreSQL
docker-compose up --build

# En otro terminal, probar la API
curl http://localhost:8080/api/marcas
```

La API estará disponible en `http://localhost:8080` con Swagger en `http://localhost:8080/swagger`

## Verificar que funciona

1. Abre tu navegador: http://localhost:8080/swagger
2. Prueba el endpoint GET /api/marcas
3. Deberías ver 3 marcas: Toyota, Ford, BMW

## Detener los servicios

```bash
docker-compose down
```

## Para desarrollo local (requiere .NET SDK)

### 1. Instalar .NET 8 SDK

- **Windows**: Descarga desde https://dotnet.microsoft.com/download
- **Linux/Mac**: 
  ```bash
  # Ubuntu/Debian
  wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh
  chmod +x dotnet-install.sh
  ./dotnet-install.sh --version latest
  ```

### 2. Levantar PostgreSQL

```bash
docker run --name postgres-dev \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=marcas_autos \
  -p 5432:5432 \
  -d postgres:15
```

### 3. Configurar variables de entorno (Windows PowerShell)

```powershell
$env:POSTGRES_HOST="localhost"
$env:POSTGRES_DB="marcas_autos"
$env:POSTGRES_USER="postgres"
$env:POSTGRES_PASSWORD="postgres"
```

En Linux/Mac:
```bash
export POSTGRES_HOST=localhost
export POSTGRES_DB=marcas_autos
export POSTGRES_USER=postgres
export POSTGRES_PASSWORD=postgres
```

### 4. Restaurar y ejecutar

```bash
dotnet restore
dotnet build
cd src/ApiMarcas
dotnet ef migrations add Init
dotnet run
```

## Ejecutar pruebas

```bash
dotnet test
```

Las pruebas usan InMemory Database y no requieren PostgreSQL.

## Estructura creada

```
coderland-backend/
├── src/ApiMarcas/          # Proyecto API
│   ├── Controllers/        # MarcasAutosController
│   ├── Data/              # MarcasContext
│   ├── Models/            # MarcaAuto
│   ├── Services/          # SeedData
│   └── Program.cs         # Configuración principal
├── tests/                 # Proyecto de pruebas
│   └── ApiMarcas.Tests/
│       ├── MarcasControllerTests.cs
│       ├── MarcasContextTests.cs
│       └── SeedDataTests.cs
├── docker-compose.yml     # Orquestación servicios
├── Dockerfile             # Imagen de la API
└── README.md              # Documentación completa
```

## Próximos pasos

1. Personaliza las marcas en `SeedData.cs`
2. Agrega más endpoints (POST, PUT, DELETE)
3. Implementa autenticación si es necesario
4. Agrega más pruebas unitarias
5. Configura CI/CD

## Troubleshooting

### Error: Puerto 8080 en uso
Modifica el puerto en `docker-compose.yml`:
```yaml
ports:
  - "8081:8080"
```

### Error: PostgreSQL no inicia
```bash
docker logs postgres-dev
docker rm -f postgres-dev
docker run --name postgres-dev -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres:15
```

### Ver logs de la API
```bash
docker-compose logs -f api
```

