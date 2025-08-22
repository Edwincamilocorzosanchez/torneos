⚽ Sports Management System

Este proyecto es un sistema de gestión deportiva desarrollado en .NET, diseñado con una arquitectura modular y escalable que permite gestionar torneos, jugadores, cuerpos técnicos, estadísticas, transferencias y más.

📂 Estructura del Proyecto
src/
│
├── Modules/                  # Módulos independientes de negocio
│   ├── InscripcionTorneo     # Gestión de inscripciones a torneos
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── MedicalBody           # Registro del cuerpo médico
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── Players               # Administración de jugadores
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── Statistic             # Estadísticas de partidos/jugadores
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── Teams                 # Equipos registrados
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── TechnicalStaff        # Gestión de entrenadores y asistentes
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI 
│   ├── Tournaments           # Organización de torneos
│   │    ├── Application       # Casos de uso y lógica de aplicación
│   │    ├── Domain            # Entidades y lógica de dominio
│   │    ├── Infrastructure    # Acceso a datos e integración externa
│   │    └── UI             
│   └── Transferencias        # Gestión de transferencias de jugadores
│       ├── Application       # Casos de uso y lógica de aplicación
│       ├── Domain            # Entidades y lógica de dominio
│       ├── Infrastructure    # Acceso a datos e integración externa
│       └── UI                # Interfaces de usuario o endpoints
│
├── Shared/                   # Recursos y configuraciones compartidas
│   ├── Configurations        # Configuración de entidades para EF Core
│   ├── Context               # DbContext principal de la aplicación
│   └── Helpers               # Utilidades y helpers comunes
│

🛠️ Tecnologías Utilizadas

.NET 9 / C#

Entity Framework Core (con MySQL como proveedor de base de datos)

Arquitectura por Módulos (inspirada en DDD y Clean Architecture)

Migrations y DbContext para manejo de la base de datos

⚙️ Configuración del Proyecto

Clona el repositorio:

git clone https://github.com/tuusuario/torneos.git
cd torneos/src


Configura la conexión a la base de datos en Shared/Context/AppDbContext.cs o en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=torneos;user=root;password=tu_password;"
}


Aplica las migraciones:

dotnet ef database update


Ejecuta el proyecto:

dotnet run

📌 Principales Módulos

Players → Registro, edición y estadísticas de jugadores

Teams → Administración de equipos

Tournaments → Creación y gestión de torneos

Transferencias → Manejo de transferencias entre equipos

MedicalBody → Control del cuerpo médico

TechnicalStaff → Entrenadores y asistentes

Statistic → Datos y reportes estadísticos

🚀 Roadmap

 Integración con API externas de datos deportivos

 Sistema de autenticación y roles

 Dashboard para estadísticas avanzadas

 Testing automatizado con xUnit

👨‍💻 Autor

Proyecto desarrollado por Edwin Camilo Corzo Sanchez