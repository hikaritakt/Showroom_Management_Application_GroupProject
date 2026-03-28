-- Du lieu mau

-- Brand
INSERT INTO Brand VALUES (N'Toyota'), (N'Honda');

-- Car
INSERT INTO Car VALUES 
(N'Vios', 500000000, 10, 1),
(N'Civic', 700000000, 5, 2);

-- Customer
INSERT INTO Customer VALUES 
(N'Nguyen Van A', '0123456789', N'Da Nang');

-- Employee
INSERT INTO Employee VALUES 
(N'Tran Van B', N'Sales');

-- Orders
INSERT INTO Orders (customer_id, employee_id)
VALUES (1, 1);

-- OrderDetail
INSERT INTO OrderDetail VALUES (1, 1, 1, 500000000);