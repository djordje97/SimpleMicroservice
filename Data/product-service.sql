CREATE DATABASE IF NOT EXISTS `product-db`;

CREATE TABLE
    `product` (
        id VARCHAR(50) PRIMARY KEY,
        name VARCHAR(20),
        quantity INT,
        price DECIMAL(10, 2)
    );