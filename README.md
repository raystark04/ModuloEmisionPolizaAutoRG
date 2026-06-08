# Modulo-Emision-Poliza-Auto-RG

## 📌 Descripción

API REST desarrollada en ASP.NET Core para la emisión de pólizas de automóviles.

Permite:

- Registrar clientes  
- Consultar clientes registrados  
- Consultar coberturas disponibles  
- Emitir pólizas de seguro  
- Consultar una póliza por Id  
- Consultar el historial de pólizas emitidas  

---

## 🛠️ Tecnologías utilizadas

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- FluentValidation  
- Swagger  

---

## 📋 Requisitos

- Visual Studio 2022  
- SQL Server  
- .NET SDK 8.0 o superior  

---

## ⚙️ Configuración de la Base de Datos

Modificar la cadena de conexión en:

`appsettings.json`

```json
{
  "ConnectionStrings": {
    "CadenaConexionSQL": "Server=localhost;Database=PolizasAuto;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
o dejarla a como esta

{
  "ConnectionStrings": {
    "CadenaConexionSQL": "Server=.;Database=PolizasAuto;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

## 🚀 Ejecutar Migraciones

Abrir VS Studio y abrir la **Consola del Administrador de Paquetes** y ejecutar:

```powershell
Update-Database
```

O usando CLI de .NET:

```bash
dotnet ef database update
```

Esto creará automáticamente la base de datos y todas las tablas necesarias.

De igual forma encontraras el archivo de la base de datos existente con datos si quieres realizar las pruebas de manera mas rapida
Solo restauras la bd en tu Sql Server Managemente Studio
---

## ▶️ Ejecutar el Proyecto

### Desde Visual Studio:

- Abrir la solución  
- Establecer el proyecto Web API como proyecto de inicio  
- Presionar `F5`  

### O desde CLI:

```bash
dotnet restore
dotnet build
dotnet run
```

---

## 🌐 Swagger

Una vez ejecutada la aplicación:

```
https://localhost:{puerto}/swagger
```

---

## 📡 Endpoints Disponibles

### 👤 Clientes

**Crear Cliente**

```http
POST /api/cliente/crear
```

**Obtener Clientes**

```http
GET /api/cliente
```

---

### 🛡️ Coberturas

**Obtener Coberturas**

```http
GET /api/cliente/obtener/cobertura
```

---

### 🚗 Pólizas

**Emitir Póliza**

```http
POST /api/cliente/crear/poliza
```

**Obtener Historial de Pólizas**

```http
GET /api/cliente/obtener/polizas
```

**Obtener Póliza por Id**

```http
GET /api/cliente/obtener/poliza/{id}
```

---
## 👨‍💻 Autor

Raymond Anotnio García Espinoza
