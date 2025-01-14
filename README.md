# Sales Management System

## Overview
The Sales Management System (SMS) is a web application designed to streamline and automate the sales process, from the initial customer request through to order fulfillment and invoicing. The system helps employees handle client requests, generate quotes, create orders, and track invoices. Additionally, the application manages leads and ensures follow-up to convert them into customers.

## Key Features
- **Client Requests**: Clients can request products, which are captured in the system.
- **Quote Creation**: Employees can generate quotes based on the requested products.
- **Order Management**: Once a quote is approved, it can be converted into an order.
- **Invoice Generation**: Orders are processed, and invoices are automatically generated.
- **Lead Management**: Tracks leads and converts them into customers after necessary follow-up.


## Technologies
* **Backend**:
    * .NET 9 API (ASP.NET Core)
    * Entity Framework Core for database operations
    * SQL Server for database management
    * log4net for logging
* **Frontend**:
    * Angular 15
    * Bootstrap and MDBootstrap for UI components
    * RxJS for reactive programming

## Features
* **Client and Employee Management**: Handle customer requests, quotes, orders, and invoices.
* **Sales Process Automation**: Seamlessly convert quotes to orders and generate invoices.
* **Lead Tracking**: Manage leads and follow-ups to convert them into customers.
* **Real-Time Notifications**: Get notified when a lead or order progresses.
* **Reporting**: Generate reports for quotes, orders, and invoices.



## Environment Configuration
The application supports different environments (e.g., Development, Production). The backend will automatically load the appropriate appsettings.{Environment}.json file based on the ASPNETCORE_ENVIRONMENT variable.

1. Development: Uses appsettings.Development.json for local development.
2. Production: Uses appsettings.Production.json for production environments.
3. Set the ASPNETCORE_ENVIRONMENT variable in your server or local environment as needed.

## Logging Configuration
The backend uses log4net for logging. The configuration file (log4net.config) defines logging levels, file paths, and formatting.

1. Configure the logging behavior in log4net.config (e.g., log file location, rolling strategy).
2. Logs will be written to the logs/ directory by default.

## License
This project is licensed under the MIT License - see the LICENSE file for details.