# 📦 Versión del Proyecto

## v1.0.0 - API de Marcas de Autos

### Características Implementadas ✅

#### Backend
- [x] API Web en .NET 8
- [x] Entity Framework Core con PostgreSQL
- [x] Controlador REST con endpoint GET /api/marcas
- [x] Migraciones automáticas
- [x] Seed data con 3 marcas (Toyota, Ford, BMW)
- [x] Swagger/OpenAPI integrado

#### Testing
- [x] Proyecto de pruebas con xUnit
- [x] In-Memory Database para pruebas
- [x] Tests para controlador
- [x] Tests para contexto de base de datos
- [x] Tests para servicio de seed
- [x] Coverage objetivo ≥70%

#### Docker
- [x] Docker Compose con 2 servicios
- [x] PostgreSQL 15
- [x] Aplicación API containerizada
- [x] Volumen persistente para datos
- [x] Health checks configurados

#### Documentación
- [x] README.md completo
- [x] QUICKSTART.md para inicio rápido
- [x] Ejemplos de cURL
- [x] Guía de troubleshooting
- [x] Comandos útiles

### Próximas Características 🚀

- [ ] Endpoint POST /api/marcas (crear marca)
- [ ] Endpoint PUT /api/marcas/{id} (actualizar marca)
- [ ] Endpoint DELETE /api/marcas/{id} (eliminar marca)
- [ ] Validación de datos con FluentValidation
- [ ] Autenticación JWT
- [ ] Paginación en GET /api/marcas
- [ ] Búsqueda/filtrado
- [ ] CI/CD con GitHub Actions
- [ ] Logging estructurado con Serilog
- [ ] Métricas con Prometheus

### Tecnologías Usadas

- **.NET 8** - Framework principal
- **Entity Framework Core 8.0** - ORM
- **PostgreSQL 15** - Base de datos
- **Npgsql** - Proveedor EF Core para PostgreSQL
- **xUnit** - Framework de pruebas
- **FluentAssertions** - Assertions expresivas
- **Moq** - Mocking para pruebas
- **Swagger/OpenAPI** - Documentación de API
- **Docker & Docker Compose** - Containerización

### Estructura del Proyecto

```
coderland-backend/
├── src/ApiMarcas/              # Proyecto principal
│   ├── Controllers/            # Controladores REST
│   ├── Data/                   # DbContext y migraciones
│   ├── Models/                 # Modelos de datos
│   ├── Services/               # Servicios (seed data)
│   ├── Migrations/            # Migraciones EF (auto-generadas)
│   └── Program.cs             # Configuración de la app
├── tests/
│   └── ApiMarcas.Tests/       # Pruebas unitarias
├── docker-compose.yml         # Orquestación de servicios
├── Dockerfile                # Imagen de la API
└── README.md                 # Documentación
```

### Comandos Principales

```bash
# Docker (más simple)
docker-compose up --build

# Desarrollo local
dotnet restore
dotnet build
dotnet run

# Pruebas
dotnet test

# Migraciones (desarrollo)
dotnet ef migrations add NombreMigracion
dotnet ef database update
```

### Endpoints Disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/marcas | Obtener todas las marcas |
| GET | /swagger | Documentación interactiva |

### Licencia

Este proyecto es parte del coderland-backend.

