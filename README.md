# 🛒 Speedy Groceries (In Development)

**Speedy Groceries** is a work-in-progress ASP.NET Core MVC web application designed to simulate an online grocery shopping experience. Users will be able to register, browse products, add them to a cart, and place orders.

---

## 📌 Project Status: 🚧 Under Development

This project is actively being developed. Features, structure, and logic are subject to change.

---

## 📁 Project Structure (WIP)

```
SpeedyGroceries/
│
├── Controllers/              # MVC controllers (Cart, Home, Products, Userentry)
├── Helpers/                  # Helper classes for password and SQL logic
├── Models/                   # POCO classes for database models
├── Views/                    # Razor views (Home, Products, Cart, etc.)
├── wwwroot/                  # Static assets like CSS, JS, images
├── appsettings.json          # Database connection and config
└── Program.cs / Startup.cs   # App entry point and service config
```

---

## ✅ Planned Features

- [x] User Registration & Login (with ADO.NET)
- [ ] Product Listing by Category
- [ ] Shopping Cart Functionality
- [ ] Checkout & Order Summary
- [ ] Admin Dashboard (Product Management)
- [ ] Seller Management
- [ ] Image Uploads for Products & Profiles

---

## 💡 Tech Stack

- **ASP.NET Core MVC**
- **ADO.NET** (SQL access)
- **SQL Server**
- **C#**
- **Razor Views**
- **Bootstrap 5** (for responsive UI)
- **HTML/CSS/JS**

---

## ⚙️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/navindra-bit/Speedy_Mart-ASP.NET-Core-project.git
cd speedy-groceries
```

### 2. Configure the Database

- Create a database in SQL Server named `SpeedyMartDB`.
- Tables needed: `Users`, `Products`, `Cart`, `Sellers` _(SQL scripts coming soon)_.
- Update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER;Initial Catalog=SpeedyMartDB;Integrated Security=True;Encrypt=False"
}
```

### 3. Run the App

```bash
dotnet build
dotnet run
```

Visit:  
`https://localhost:5001` or `http://localhost:5000`

---

## 🗂 Example: Users Table

| Field        | Type          | Notes              |
| ------------ | ------------- | ------------------ |
| UserId       | INT (PK)      | Auto-increment     |
| FullName     | NVARCHAR(100) | Required           |
| Email        | NVARCHAR(100) | Unique             |
| Password     | NVARCHAR(100) | Stored as hash     |
| PhoneNumber  | BIGINT        |                    |
| DateOfBirth  | DATE          |                    |
| ProfileImage | NVARCHAR(300) | Optional           |
| CreatedAt    | DATETIME      | Default: GETDATE() |

---

## 🧪 Testing Plan

- Future: Unit tests for controllers and database logic
- Manual testing for login/cart/product flows
- SQL validation testing

---

## 📝 Notes

- You can find key logic in `Controllers/` and `Helpers/`.
- Design and features may change as development progresses.
- suggestions are welcome!

---

## 🙋‍♂️ Author

**Navindra M**  
This project is for personal study purposes.

---
