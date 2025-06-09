# 🚨 SIRVAL API - Sistema de Gestión de Alertas

API RESTful para el **Sistema Inteligente de Registro y Visualización de Alertas Locales (SIRVAL)**, desarrollada en **ASP.NET Core** con **MySQL**.

---

## 📋 Tabla de Contenidos

- [🛠 Requisitos](#-requisitos)  
- [🔧 Instalación](#-instalación)  
- [⚙️ Configuración](#️-configuración)  
- [🚀 Uso](#-uso)  
- [📡 Endpoints Principales](#-endpoints-principales)  
- [💡 Ejemplos](#-ejemplos)  
- [🤝 Contribución](#-contribución)  
- [📄 Licencia](#-licencia)

---

## 🛠 Requisitos

- [.NET 6.0 SDK o superior](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)
- WAMP/XAMPP (para entorno local)
- Git

---

## 🔧 Instalación

Clonar el repositorio:

```bash
git clone https://github.com/tuusuario/sirval-api.git
cd sirval-api
```

Restaurar dependencias:

```bash
dotnet restore
```

Configurar la base de datos (ver sección de [⚙️ Configuración](#️-configuración))  
Ejecutar la aplicación:

```bash
dotnet run
```

---

## ⚙️ Configuración

**1. Importar la estructura de la base de datos:**

Ejecutar el script `db_sirval.sql` en tu servidor MySQL.

**2. Configurar la conexión a la base de datos:**

Editar el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=db_sirval;User=root;Password=tucontraseña;"
  }
}
```

**3. Configuración opcional:**

Modificar el puerto en `Properties/launchSettings.json` si es necesario.

---

## 🚀 Uso

La API estará disponible en:

```
http://localhost:5000
```

Accede a la documentación interactiva con **Swagger UI**:

```
http://localhost:5000/swagger
```

---

## 📡 Endpoints Principales

| Entidad       | Endpoint                     | Métodos Disponibles       |
|---------------|------------------------------|----------------------------|
| Dispositivos  | `/api/dispositivos`          | GET, POST                 |
|               | `/api/dispositivos/{id}`     | GET, PUT, DELETE          |
| Alertas       | `/api/alertas`               | GET, POST                 |
|               | `/api/alertas/{id}`          | GET, PUT, DELETE          |
| Responsables  | `/api/responsables`          | GET, POST                 |
|               | `/api/responsables/{id}`     | GET, PUT, DELETE          |
| Tipos Alerta  | `/api/tiposalerta`           | GET, POST                 |
|               | `/api/tiposalerta/{id}`      | GET, PUT, DELETE          |
| Asignaciones  | `/api/asignaciones`          | GET, POST                 |
|               | `/api/asignaciones/{id}`     | GET, PUT, DELETE          |

---

## 💡 Ejemplos

**Crear un dispositivo:**

```bash
curl -X POST "http://localhost:5000/api/dispositivos" -H "Content-Type: application/json" -d '{"Tipo_Disp":"Router","Nombre_Disp":"Principal","Ubicacion_Disp":"Edificio A","IP":"192.168.1.1"}'
```

**Registrar una alerta:**

```bash
curl -X POST "http://localhost:5000/api/alertas" -H "Content-Type: application/json" -d '{"Id_TipoAlerta":1,"Id_Dispositivo":1,"Severidad":"Alta","Detalle_Alerta":"Intento de intrusión"}'
```

**Obtener todas las alertas:**

```bash
curl -X GET "http://localhost:5000/api/alertas"
```

---

## 🤝 Contribución

1. Haz fork del proyecto  
2. Crea una rama para tu feature:

   ```bash
   git checkout -b feature/nueva-funcionalidad
   ```

3. Haz commit de tus cambios:

   ```bash
   git commit -am 'Agrega nueva funcionalidad'
   ```

4. Haz push a la rama:

   ```bash
   git push origin feature/nueva-funcionalidad
   ```

5. Abre un **Pull Request**

---

## 📄 Licencia

Este proyecto está bajo la **Licencia MIT** - consulta el archivo [LICENSE](LICENSE) para más detalles.
