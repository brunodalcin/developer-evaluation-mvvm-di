# Customer Management App - .NET MAUI

This is a simple **Customer Management Application** built with **.NET MAUI 9** for **Windows**. The application allows users to **create, update, delete, and list customers**. Data is stored **in-memory** with SQLite.

---

## Features

- Implemented using **MVVM (Model-View-ViewModel)** pattern.
- **Customer class** contains the following fields:
  - `Name`
  - `Lastname`
  - `Age`
  - `Address`
- **Main window** displays a list of customers and allows:
  - **Adding** a new customer (opens in a new window)
  - **Editing** an existing customer (opens in a new window)
  - **Deleting** a customer (with confirmation dialog)
- Uses **Dependency Injection** for services.

---
