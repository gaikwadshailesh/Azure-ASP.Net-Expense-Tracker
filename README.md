# Expense Tracker - Azure Blob Storage

A lightweight expense tracking application built with ASP.NET Core Blazor Server and Azure Blob Storage.

## Features

- Track expenses with date, description, amount, and category
- Upload and store receipts in Azure Blob Storage
- View all expenses in a responsive table format
- Edit and delete existing expenses
- Simple and clean user interface
- No authentication required (suitable for personal use)

## Prerequisites

- .NET 7.0 SDK
- Azure Storage Account
- Visual Studio 2022 or VS Code

## Setup

1. Clone the repository:


ExpenseTracker/
│
├── Models/
│ └── Expense.cs # Data model for expenses
│
├── Services/
│ ├── BlobStorageService.cs # Azure Blob Storage operations
│ └── ExpenseService.cs # Expense management operations
│
├── Pages/
│ └── Expenses/
│ ├── List.razor # Expenses list page
│ ├── Create.razor # Create new expense
│ └── Edit.razor # Edit existing expense
│
├── Components/
│ └── ExpenseForm.razor # Reusable expense form
│
└── Shared/
└── NavMenu.razor # Navigation menu