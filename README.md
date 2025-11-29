## 📚 BookStore - ASP.NET Core E-Commerce Platform

A full-featured online book store built with ASP.NET Core MVC, featuring complete e-commerce functionality including product catalog, shopping cart, and order management system.

### 🚀 Features

- **Book Catalog**: Browse books with search, filter by category, and detailed product pages
- **Shopping Cart**: Session-based cart with add, update, remove, and quantity management
- **Order Management**: Complete order processing with status tracking (Pending, Confirmed, Shipped, Delivered, Cancelled)
- **Admin Panel**: Manage orders, update status, and track customer purchases
- **Responsive Design**: Modern UI built with Bootstrap for seamless mobile and desktop experience
- **Data Validation**: Comprehensive server-side and client-side validation with error handling

### 🛠️ Tech Stack

**Backend**: ASP.NET Core MVC, Entity Framework Core, SQL Server  
**Frontend**: HTML5, CSS3, Bootstrap, JavaScript, Razor Pages  
**Session Management**: Distributed memory cache for cart persistence  
**Architecture**: MVC Pattern, Repository Pattern, Dependency Injection

### 📋 Core Functionality

- **Customer Features**:
  - Browse book catalog with search and category filters
  - Add books to shopping cart with quantity management
  - Secure checkout process with customer information collection
  - Order confirmation with detailed receipts

- **Admin Features**:
  - View all orders with comprehensive details
  - Update order status through intuitive interface
  - Manage order lifecycle from placement to delivery
  - Delete orders with confirmation dialogs

### 🏗️ Project Structure

```
BookStore/
├── Controllers/          # MVC Controllers (Books, Cart, Orders)
├── Models/              # Domain Models (Book, Order, CartItem, OrderItem)
├── Data/                # DbContext & Database Configuration
├── Views/               # Razor Views with Bootstrap
└── wwwroot/            # Static files (CSS, JS, Images)
```

### 🎯 Key Highlights

- **Session Management**: Persistent shopping cart using ASP.NET Core sessions
- **Database Seeding**: Automatic population of sample book data on first run
- **Status Workflow**: Comprehensive order status management system
- **RESTful Design**: Clean URL structure and proper HTTP verb usage
- **Error Handling**: User-friendly error messages and validation feedback

This project demonstrates real-world e-commerce application development using modern ASP.NET Core practices, making it an excellent showcase for full-stack .NET development skills.

---
