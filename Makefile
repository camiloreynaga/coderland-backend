.PHONY: help setup build run test clean docker-up docker-down migrate

help:
	@echo "Comandos disponibles:"
	@echo "  make setup      - Restaurar dependencias"
	@echo "  make build      - Compilar proyecto"
	@echo "  make run        - Ejecutar API localmente"
	@echo "  make test       - Ejecutar pruebas"
	@echo "  make migrate    - Crear migración (local)"
	@echo "  make clean      - Limpiar build"
	@echo "  make docker-up  - Levantar servicios con Docker"
	@echo "  make docker-down - Detener servicios"

setup:
	dotnet restore

build:
	dotnet build

run:
	cd src/ApiMarcas && dotnet run

test:
	dotnet test

clean:
	dotnet clean

docker-up:
	docker-compose up --build

docker-down:
	docker-compose down

migrate:
	cd src/ApiMarcas && dotnet ef migrations add Init

# Abrir Swagger
swagger:
	@echo "Swagger UI disponible en: http://localhost:8080/swagger"

