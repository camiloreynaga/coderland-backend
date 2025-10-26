# 📝 Guía de Commits

## Estructura de Commits Sugerida

Sigue este orden para hacer commits organizados:

### 1. Configuración inicial
```bash
git init
git add .
git commit -m "chore: initial project setup with .NET 8"
```

### 2. Modelo y contexto
```bash
git add src/ApiMarcas/Models/MarcaAuto.cs src/ApiMarcas/Data/MarcasContext.cs
git commit -m "feat: add MarcaAuto model and MarcasContext"

git add src/ApiMarcas/Services/SeedData.cs
git commit -m "feat: add seed data service for initial brands"
```

### 3. Migraciones
```bash
# Generar migración primero con: dotnet ef migrations add Init
git add src/ApiMarcas/Migrations/
git commit -m "feat: add database migration for MarcasAutos table"
```

### 4. Controlador
```bash
git add src/ApiMarcas/Controllers/MarcasAutosController.cs
git commit -m "feat: add MarcasAutosController with GET endpoint"
```

### 5. Configuración de la app
```bash
git add src/ApiMarcas/Program.cs
git add src/ApiMarcas/appsettings.json
git add src/ApiMarcas/appsettings.Development.json
git commit -m "feat: configure Program.cs with EF Core and PostgreSQL"
```

### 6. Pruebas unitarias
```bash
git add tests/ApiMarcas.Tests/
git commit -m "test: add unit tests for controller, context and seed data"
```

### 7. Docker
```bash
git add Dockerfile docker-compose.yml .dockerignore
git commit -m "feat: add Docker configuration and docker-compose setup"
```

### 8. Documentación
```bash
git add README.md QUICKSTART.md VERSION.md
git commit -m "docs: add comprehensive documentation"
```

### 9. Configuración del repositorio
```bash
git add .gitignore global.json Makefile
git commit -m "chore: add gitignore, global.json and Makefile"
```

## Ejemplos de Mensajes de Commit

### Buena práctica (estilo "humano")
```
feat: add endpoint to get all car brands
fix: correct PostgreSQL connection string handling
test: add unit tests for MarcaAuto model
docs: update README with API examples
refactor: simplify seed data logic
chore: update .NET packages to latest version
```

### Evitar (demasiado formal o mecánico)
```
ADD: new endpoint
FIX: bug in code
UPDATE: documentation
CHANGES: in configuration
```

## Comandos Útiles

### Ver el historial
```bash
git log --oneline
git log --graph --pretty=format:'%h - %s (%cr) <%an>' --abbrev-commit
```

### Crear un tag para la versión
```bash
git tag -a v1.0.0 -m "Primera versión funcional de la API"
git push origin v1.0.0
```

### Crear una rama para nueva funcionalidad
```bash
git checkout -b feature/add-post-endpoint
# hacer cambios...
git add .
git commit -m "feat: add POST endpoint for creating brands"
git checkout main
git merge feature/add-post-endpoint
```

## Tips

1. **Haz commits frecuentes**: No acumules muchos cambios en un solo commit
2. **Mensajes descriptivos**: El mensaje debe explicar el "qué" y "por qué"
3. **Usa convenciones**: feat:, fix:, test:, docs:, etc.
4. **Revisa antes de commitear**: `git status` y `git diff` para ver qué vas a commitear

## Convenciones

- `feat:` - Nueva funcionalidad
- `fix:` - Corrección de bug
- `test:` - Agregar o modificar tests
- `docs:` - Cambios en documentación
- `refactor:` - Refactorización de código
- `chore:` - Tareas de mantenimiento (dependencias, configuración)
- `perf:` - Mejoras de rendimiento
- `style:` - Cambios de formato (no afectan funcionalidad)

