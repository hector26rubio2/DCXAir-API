# Nombre del Proyecto

## Descripción
La prueba técnica para Flyr representa un desafío integral que abarca diversos aspectos del desarrollo de software.La solución se basa en una arquitectura limpia robusta de cuatro capas, que incluye la presentación, aplicación, dominio e infraestructura. Utilizamos tecnologías modernas y herramientas eficientes para garantizar un desarrollo ágil y de alta calidad.

## Versión
.NET 8

## Arquitectura Limpia
El proyecto sigue una arquitectura limpia de cuatro capas para una separación clara de responsabilidades y modularidad.

| Capa         | Descripción                                                      |
|--------------|------------------------------------------------------------------|
| Presentación | Controladores de API que manejan las solicitudes HTTP            |
| Aplicación   | Lógica de aplicación y manejo de solicitudes, incluidas las reglas de negocio |
| Dominio      | Modelos de datos y reglas de negocio                              |
| Infraestructura        | Acceso a datos utilizando Entity Framework                        |

## Controladores y Endpoints
- `FlightController`:
  - `POST /api/flight/batch`: Agrega múltiples vuelos a la base de datos.
  - `GET /api/flight/origin-airports`: Obtiene los aeropuertos de origen disponibles.
  - `GET /api/flight/destination-airports`: Obtiene los aeropuertos de destino disponibles.
  - `POST /api/flight/by-filter`: Obtiene vuelos según un filtro especificado.

## Tecnologías Utilizadas
- **Automapper**: Mapeo de entidades DTO.
- **Entity Framework**: Acceso a datos y mapeo objeto-relacional.
- **FluentValidation**: Validación de modelos DTO en los controladores.
- **Serilog**: Registro de eventos y mensajes de registro.
- **xUnit**: Pruebas unitarias.


## Pruebas Unitarias
Se incluyen un conjunto de pruebas unitarias para cubrir diferentes métodos del controlador `FlightController`:

- `GetOriginAirports_ReturnsOk_WithOriginAirports`: Verifica que se obtengan correctamente los aeropuertos de origen.
- `GetDestinationAirports_ReturnsOk_WithDestinationAirports`: Verifica que se obtengan correctamente los aeropuertos de destino.
- `GetFlightsByType_ReturnsOk_WithJourneys`: Verifica que se obtengan correctamente los vuelos según un filtro especificado.



# Ejecutar pruebas unitarias
dotnet test
