# API de Marcas de Autos - Backend

API Web en .NET 8 para gestionar marcas de automóviles usando Entity Framework Core y PostgreSQL.

## Características

- .NET 8
- PostgreSQL con Entity Framework Core
- Docker Compose para desarrollo
- Pruebas unitarias con xUnit
- Swagger para documentación

## Requisitos

- .NET 8 SDK ([descargar](https://dotnet.microsoft.com/download))
- Docker Desktop (opcional, para docker-compose)
- PostgreSQL 15+ (opcional, para desarrollo local)

## Estructura

```
coderland-backend/
├── src/ApiMarcas/              # API principal
├── tests/ApiMarcas.Tests/       # Pruebas unitarias
├── docker-compose.yml           # Docker Compose
└── Dockerfile                   # Imagen de la API
```

## Inicio Rápido

### Opción 1: Docker Compose (la más fácil)

```bash
docker-compose up --build
```

La API estará en http://localhost:8080

Abre http://localhost:8080/swagger para ver la documentación, o prueba:

```bash
curl http://localhost:8080/api/marcas
```

Deberías ver 3 marcas: Toyota, Ford, BMW.

### Opción 2: Desarrollo Local

**1. Levantar PostgreSQL (Docker):**

```bash
docker run --name postgres-dev -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres:15
```

**2. Configurar variables de entorno:**

Linux/Mac:
```bash
export POSTGRES_HOST=localhost
export POSTGRES_DB=marcas_autos
export POSTGRES_USER=postgres
export POSTGRES_PASSWORD=postgres
```

Windows PowerShell:
```powershell
$env:POSTGRES_HOST="localhost"
$env:POSTGRES_DB="marcas_autos"
$env:POSTGRES_USER="postgres"
$env:POSTGRES_PASSWORD="postgres"
```

**3. Crear migraciones:**

```bash
cd src/ApiMarcas
dotnet ef migrations add Init
```

**4. Ejecutar:**

```bash
dotnet restore
dotnet build
dotnet run
```

La API estará en http://localhost:5000 o https://localhost:5001

## Ejecutar Pruebas

```bash
dotnet test
```

Las pruebas usan InMemory Database, no necesitas PostgreSQL corriendo.

## Endpoint

### GET /api/marcas

Obtiene todas las marcas de autos.

**Respuesta:**
```json
[
  {
    "id": 1,
    "nombre": "Toyota",
    "paisOrigen": "Japón"
  },
  {
    "id": 2,
    "nombre": "Ford",
    "paisOrigen": "Estados Unidos"
  },
  {
    "id": 3,
    "nombre": "BMW",
    "paisOrigen": "Alemania"
  }
]
```

**Ejemplo:**
```bash
curl http://localhost:8080/api/marcas
```

## Base de Datos

### Modelo

```sql
CREATE TABLE MarcasAutos (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    PaisOrigen VARCHAR(255)
);
```

### Datos Iniciales

La app incluye 3 marcas por defecto:
- Toyota (Japón)
- Ford (Estados Unidos)
- BMW (Alemania)

### Migraciones

Se aplican automáticamente con Docker. Si usas desarrollo local:

```bash
dotnet ef database update
```

## Docker

**Construir:**
```bash
docker-compose build
```

**Ver logs:**
```bash
docker-compose logs -f api
```

**Detener:**
```bash
docker-compose down
```

**Limpiar todo (incluye datos):**
```bash
docker-compose down -v
```

## Comandos Útiles

```bash
# Limpiar
dotnet clean

# Listar migraciones
dotnet ef migrations list

# Nueva migración
dotnet ef migrations add NombreMigracion

# Ver SQL de migraciones
dotnet ef migrations script
```

## Notas

- Las migraciones se aplican automáticamente al iniciar
- Los datos se siembran solo si la tabla está vacía
- Las pruebas usan In-Memory DB (no necesitas Postgres)
- Logger configurado para debugging

## Troubleshooting

**Error: "Unable to connect to PostgreSQL"**
- Verifica que Postgres esté corriendo
- Revisa credenciales en variables de entorno
- Revisa logs: `docker-compose logs`

**Error: "Migration already applied"**
```bash
dotnet ef database drop
dotnet ef database update
```

**Puerto 8080 ocupado**

Cambia el puerto en `docker-compose.yml`:
```yaml
ports:
  - "8081:8080"
```

## Verificar que funciona

Después de levantar:

```bash
curl http://localhost:8080/api/marcas
```

Deberías ver las 3 marcas en formato JSON.

## Recursos

- [Documentación .NET](https://docs.microsoft.com/dotnet/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [PostgreSQL Docs](https://www.postgresql.org/docs/)
- [Docker Compose](https://docs.docker.com/compose/)
