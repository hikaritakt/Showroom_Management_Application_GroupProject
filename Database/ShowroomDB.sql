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
    role NVARCHAR(50)
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


