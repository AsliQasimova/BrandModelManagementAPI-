# BrandModelManagementAPI-

Backend system for managing phone brands, models, features, sales, and inventory.  
Built with **ASP.NET Core** and **Entity Framework Core**, following layered architecture principles.

---

## 🚀 Features
- Manage **brands** and their associated **models**
- Add and update **features** (camera, storage, RAM, etc.)
- Track **sales** and **restock movements**
- Maintain **price history** for models
- Implement **soft delete** for models and features
- Structured architecture with **DTOs, Services, Entities, Controllers**

---

## 🛠️ Technologies
- ASP.NET Core
- Entity Framework Core (Code-First + Migrations)
- MySQL
- Serilog (logging)
- Swagger (API documentation)
- Layered Architecture (Controllers, Services, DTOs, Entities)

---

## ⚙️ Database Setup
1. Create a database (e.g., `brand_db`) in MySQL.
2. Add your connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=brand_db;user=YOUR_USER;password=YOUR_PASSWORD;"
   }
