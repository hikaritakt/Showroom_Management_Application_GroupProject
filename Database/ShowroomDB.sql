CREATE DATABASE ShowroomDB;
GO

USE ShowroomDB;
GO

-- 1. BRAND
CREATE TABLE Brand (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    brand_name NVARCHAR(100) NOT NULL
);

-- 2. CAR
CREATE TABLE Car (
    car_id INT IDENTITY(1,1) PRIMARY KEY,
    car_name NVARCHAR(100) NOT NULL,
    price DECIMAL(18,2) NOT NULL CHECK(price >= 0),
    quantity INT NOT NULL CHECK(quantity >= 0),
    brand_id INT NOT NULL,
    FOREIGN KEY (brand_id) REFERENCES Brand(brand_id)
);

-- ========================
-- 3. CUSTOMER
-- ========================
CREATE TABLE Customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20),
    address NVARCHAR(200)
);

-- 4. EMPLOYEE
CREATE TABLE Employee (
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100),
    phone NVARCHAR(20)
);

-- 5. ORDERS
CREATE TABLE Orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    employee_id INT NOT NULL,
    order_date DATETIME DEFAULT GETDATE(),
    total_amount DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (employee_id) REFERENCES Employee(employee_id)
);

-- 6. ORDER DETAIL
CREATE TABLE OrderDetail (
    order_detail_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    car_id INT NOT NULL,
    quantity INT NOT NULL CHECK(quantity > 0),
    price DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (car_id) REFERENCES Car(car_id)
);

-- INDEX
CREATE INDEX idx_car_brand ON Car(brand_id);
CREATE INDEX idx_order_customer ON Orders(customer_id);

-- 7. SUPPLIER
CREATE TABLE Supplier (
    supplier_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    address NVARCHAR(200),
    phone NVARCHAR(20)
);

-- 8. ROLE
CREATE TABLE Role (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name NVARCHAR(50) NOT NULL
);

-- 9. ACCOUNT
CREATE TABLE Account (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password_hash NVARCHAR(256) NOT NULL,
    role_id INT NOT NULL,
    employee_id INT NOT NULL UNIQUE,
    is_active BIT DEFAULT 1,
    FOREIGN KEY (role_id) REFERENCES Role(role_id),
    FOREIGN KEY (employee_id) REFERENCES Employee(employee_id)
);

-- Insert Demo Data
INSERT INTO Role (role_name) VALUES ('Admin'), ('Staff');

-- Insert Employees
INSERT INTO Employee (name, email, phone) VALUES 
('System Admin', 'admin@system.com', '123456789'),
('John Doe', 'john.doe@showroom.com', '0987654321'),
('Jane Smith', 'jane.smith@showroom.com', '0123456789'),
('Alice Brown', 'alice.brown@showroom.com', '0369852147');

-- Insert Accounts
-- Sử dụng HASHBYTES của SQL Server để mã hoá mật khẩu chữ bình thường 'admin123' sang SHA256 ngay lúc Insert.
INSERT INTO Account (username, password_hash, role_id, employee_id, is_active) 
VALUES 
('admin', LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2)), 1, 1, 1),
('staff1', LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2)), 2, 2, 1),
('staff2', LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2)), 2, 3, 1);

-- Insert Suppliers
INSERT INTO Supplier (name, address, phone) VALUES 
('Toyota Official Dealer', '123 Toyota Str, Tokyo', '1800-TOYOTA'),
('Honda Motors', '456 Honda Blvd, Tokyo', '1800-HONDA'),
('Ford Global', '789 Dearborn, Michigan', '1800-FORD'),
('BMW Supplies', 'Munich, Germany', '1800-BMW');

