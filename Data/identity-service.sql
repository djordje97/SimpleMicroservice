-- Cr... SQLINES DEMO ***
-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE
    "user" (
        id VARCHAR(50) PRIMARY KEY,
        name VARCHAR(20),
        last_name VARCHAR(20),
        email VARCHAR(20) UNIQUE,
        password VARCHAR(100)
    );
SELECT user, host FROM mysql.user WHERE user='productdb';
GRANT ALL PRIVILEGES ON `product-db`.* TO 'productdb'@'%';
FLUSH PRIVILEGES;

