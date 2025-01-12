CREATE table Status (
    Id Int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(30) UNIQUE NOT NULL,
    Description NVARCHAR(255) not null
)

create table PaymentMethods (
    Id int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(45) UNIQUE NOT NULL,
    Description NVARCHAR(255) not null,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

CREATE TABLE Movements (
    Id int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(45) UNIQUE NOT NULL,
    Description NVARCHAR(255) not null,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

CREATE table CategoryTypes (
    Id int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(50) UNIQUE NOT NULL,
    Description NVARCHAR(100) not null
)

CREATE table Categories(
    Id int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(60) UNIQUE NOT NULL,
    Description NVARCHAR(255) not null,
    CategoryTypeID INT NOT NULL,
    FOREIGN KEY (CategoryTypeID) REFERENCES CategoryTypes(Id)
)

CREATE TABLE Currency (
    Id int IDENTITY(1,1) PRIMARY key,
    Code NVARCHAR(5) UNIQUE NOT NULL,
    Description NVARCHAR(255) not null
)


create table DeliveryTypes (
    Id int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(50) UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

CREATE TABLE UserRoles (
    Id Int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) not null,
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

create table Departments (
    Id Int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) not null,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

create TABLE JobPositions (
    Id Int IDENTITY(1,1) PRIMARY key,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) not null,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    DepartmentID INT not null,
    StatusID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(Id),
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

create table Employees (
    Id int IDENTITY(1,1) PRIMARY key,
    EmployeeCode NVARCHAR(15) not null UNIQUE,
    Name NVARCHAR(90) not NULL,
    LastName NVARCHAR(90) not null,
    PhoneNumber NVARCHAR(10) not NULL,
    EmailAddress NVARCHAR(150) not NULL,
    Gender NVARCHAR(20) not null,
    Country NVARCHAR(150) not null,
    BirthDate DATE not null,
    MartialStatus NVARCHAR(20) NOT NULL,
    City NVARCHAR(150) not null,
    PostalCode NVARCHAR(10) not null,
    Province NVARCHAR(100) not NULL,
    Address NVARCHAR(150) not NULL,
    AptUnit NVARCHAR(10) not NULL,
    CreatedAt DATETIME not null DEFAULT GETDATE(),
    UpdatedAt DATETIME not null DEFAULT GETDATE(),
    StartDate DATE not null,
    EndDate DATE,
    StatusID int not null,
    JobPositionID int not null,
    FOREIGN KEY (JobPositionID) REFERENCES JobPositions(Id),
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)


create table Customers (
    Id int IDENTITY(1,1) PRIMARY key,
    CustomerCode NVARCHAR(15) not null UNIQUE,
    Name NVARCHAR(90) not NULL,
    LastName NVARCHAR(90) not null,
    PhoneNumber NVARCHAR(10) not NULL,
    EmailAddress NVARCHAR(150) not NULL,
    Gender NVARCHAR(20) not null,
    Country NVARCHAR(150) not null,
    BirthDate DATE,
    MartialStatus NVARCHAR(20),
    City NVARCHAR(150) not null,
    PostalCode NVARCHAR(10) not null,
    Province NVARCHAR(100) not NULL,
    Address NVARCHAR(150) not NULL,
    AptUnit NVARCHAR(10) not NULL,
    CreatedAt DATETIME not null DEFAULT GETDATE(),
    UpdatedAt DATETIME not null DEFAULT GETDATE(),
    StatusID int not null,
    EmployeeID INT NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(Id),
    FOREIGN KEY (StatusID) REFERENCES Status(Id)
)

create TABLE Users (
    Id int IDENTITY(1,1) PRIMARY key,
    EmployeeID INT,
    CustomerID INT,
    RoleID int not null,
    Password NVARCHAR(255) NOT NULL,
    LastAccess DATETIME,
    StatusID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id),
    FOREIGN KEY (RoleID) REFERENCES UserRoles(Id),
    FOREIGN KEY (CustomerID) REFERENCES Customers(Id),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(Id)
)


create table CustomerDeliveryAddresses (
    Id int IDENTITY(1,1) PRIMARY key,
    CustomerID INT NOT NULL,
    Name NVARCHAR(90) not NULL,
    LastName NVARCHAR(90) not null,
    PhoneNumber NVARCHAR(10) not NULL,
    EmailAddress NVARCHAR(150) not NULL,
    Gender NVARCHAR(20) not null,
    Country NVARCHAR(150) not null,
    City NVARCHAR(150) not null,
    PostalCode NVARCHAR(10) not null,
    Province NVARCHAR(100) not NULL,
    Address NVARCHAR(150) not NULL,
    AptUnit NVARCHAR(10) not NULL,
    Notes NVARCHAR(255),
    CreatedAt DATETIME not null DEFAULT GETDATE(),
    UpdatedAt DATETIME not null DEFAULT GETDATE(),
    StatusID int not null,
    EmployeeID int not NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(Id),
    FOREIGN KEY (StatusID) REFERENCES Status(Id),
    FOREIGN KEY (CustomerID) REFERENCES Customers(Id)
)


CREATE table Products (
    Id int IDENTITY(1,1) PRIMARY key,
    SKU NVARCHAR(35) UNIQUE NOT NULL,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(450) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock FLOAT NOT NULL,
    MinimumStock FLOAT NOT NULL,
    StatusID INT NOT NULL,
    CategoryID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id),
    FOREIGN KEY (CategoryID) REFERENCES Categories(Id)
)

CREATE table ProductDetails (
    Id int IDENTITY(1,1) PRIMARY key,
    ImageUrl NVARCHAR(350) NOT NULL,
    Description NVARCHAR(155),
    ProductID INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(Id)
)


create TABLE Offers (
    Id int IDENTITY(1,1) PRIMARY key,
    Folio NVARCHAR(25) UNIQUE NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) not null,
    DiscountPCT FLOAT,
    StartDate DATE,
    EndDate DATE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    StatusID INT NOT NULL,
    CategoryID INT NOT NULL,
    FOREIGN KEY (StatusID) REFERENCES Status(Id),
    FOREIGN KEY (CategoryID) REFERENCES Categories(Id)
)

create table OfferDetails (
    Id int IDENTITY(1,1) PRIMARY key,
    ProductId INT NOT NULL,
    OfferedPrice DECIMAL(18,2),
    DiscountPCT FLOAT,
    StartDate DATE,
    EndDate DATE,
    QuantityMin FLOAT,
    PaymentMethodID int,
    DeliveryTypeID int,
    FOREIGN KEY (ProductID) REFERENCES Products(Id),
    FOREIGN KEY (PaymentMethodID) REFERENCES PaymentMethods(Id),
    FOREIGN KEY (DeliveryTypeID) REFERENCES DeliveryTypes(Id)
)

create table Sales (
    Id int IDENTITY(1,1) PRIMARY key,
    Folio NVARCHAR(25) UNIQUE NOT NULL,
    MovementID INT NOT NULL,
    UserID INT not NULL,
    ApplyToEmployeeID INT NOT NULL,
    CustomerID INT not null,
    GlobalOfferID INT,
    CurrencyID INT NOT NULL,
    Tax FLOAT NOT null,
    TotalTax DECIMAL(18, 2) not null,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    TotalShipping DECIMAL(18, 2) not NULL,
    DiscountPCT FLOAT NOT NULL,
    TotalDiscount DECIMAL(18, 2) NOT null,
    StatusID int not null,
    SourceID Int,
    CreatedAt DATETIME not null DEFAULT GETDATE(),
    UpdatedAt DATETIME not null DEFAULT GETDATE(),
    DeliveryAddressID INT,
    DeliveryDateEST_Start DATETIME not NULL,
    DeliveryDateEST_End DATETIME not NULL,
    Notes NVARCHAR(255),
    FOREIGN KEY (DeliveryAddressID) REFERENCES CustomerDeliveryAddresses(Id),
    FOREIGN KEY (MovementID) REFERENCES Movements(Id),
    FOREIGN KEY (UserID) REFERENCES Users(Id),
    FOREIGN KEY (ApplyToEmployeeID) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerID) REFERENCES Customers(Id),
    FOREIGN KEY (GlobalOfferID) REFERENCES Offers(Id),
    FOREIGN KEY (StatusID) REFERENCES Status(Id),
    FOREIGN KEY (SourceID) REFERENCES Sales(Id),
    FOREIGN KEY (CurrencyID) REFERENCES Currency(Id)
)


create table SaleDetails (
    Id int IDENTITY(1,1) PRIMARY key,
    Quantity FLOAT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Notes NVARCHAR(255),
    DateAdded DATETIME NOT NULL,
    DiscountPCT FLOAT NOT NULL,
    TotalDiscount DECIMAL(18, 2) NOT null,
    SaleID INT NOT NULL,
    ProductID INT NOT NULL,
    OfferDetailID INT,
    FOREIGN KEY (ProductID) REFERENCES Products(Id),
    FOREIGN KEY (SaleID) REFERENCES Sales(Id),
    FOREIGN KEY (OfferDetailID) REFERENCES OfferDetails(Id)
)