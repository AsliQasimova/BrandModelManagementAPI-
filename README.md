# 📱 PhoneAppAPI

PhoneAppAPI is a backend system designed to manage **phone brands, models, features, sales, and inventory**.  
Built with **ASP.NET Core** and **Entity Framework Core**, the project follows **layered architecture principles** to ensure scalability, maintainability, and clean separation of concerns.

---

## 🚀 Features
- Manage **brands** and their associated **models**
- Add and update **features** (camera, storage, RAM, etc.)
- Track **sales** and **restock movements**
- Maintain **price history** for models
- Implement **soft delete** for models and features
- Structured architecture with **DTOs, Services, Entities, Controllers**
- Integrated **logging** with Serilog
- Interactive API documentation via **Swagger**

---

## 🛠️ Technologies
- **ASP.NET Core** – Web API framework
- **Entity Framework Core** – ORM with Code-First + Migrations
- **MySQL** – Relational database
- **Serilog** – Structured logging
- **Swagger / Swashbuckle** – API documentation
- **Layered Architecture** – Controllers, Services, DTOs, Entities

---

## ⚙️ Database Setup
1. Create a database (e.g., `brand_db`) in MySQL.  
2. Add your connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=brand_db;user=YOUR_USER;password=YOUR_PASSWORD;"
   }
3. Run migrations to create tables:
    ```bash
    dotnet ef database update

## 🗄️ Database File
The repository also includes a sample database file in the **Database** folder:

- `phoneApp_db.sql` → Contains schema and sample data.

### How to Import
1. Create a database:
   ```sql
   CREATE DATABASE phoneApp_db;
   
2. Import the file:

   ```bash
   mysql -u root -p brand_db <

## ▶️ How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/<your-username>/PhoneAppAPI.git

2. Navigate into the project folder:

   ```bash
   cd PhoneAppAPI

3. Run the application:

   ```bash
   dotnet run
   
4. Open Swagger UI at:
   ```Code
   https://localhost:5001/swagger
   
## 📂 Project Structure
- **Abstractions** → Interfaces (IBrandService, IModelService, IFeatureService)  
- **Controllers** → API endpoints  
- **Data** → DbContext (PhoneDbContext)  
- **Entities** → Database entities (Brand, Model, Feature, Sales, PriceHistory, StockMovement)  
- **Models** → DTOs (BrandDTO, ModelDTO, FeatureDTO, etc.)  
- **Services** → Business logic (BrandService, ModelService, FeatureService)  
- **Migrations** → EF Core migration files  

---

## 🧪 Testing
- Unit tests for services and business logic  
- Integration tests for API endpoints  
- Swagger UI for manual testing and API exploration  

---

## 📌 Notes
- Keep your **connection string private** (add `appsettings.json` to `.gitignore`).  
- Use README.md to guide others on how to set up and run the project.  
- Future improvements: Authentication (JWT), Role-based Authorization, CI/CD pipeline integration.  

---

## 👤 Author
Developed by **Aslı Qasımova**  
📧 Contact: [asligasimova21@gmail.com]  
🌐 GitHub: [[https://github.com/<your-username>]](https://github.com/AsliQasimova)

