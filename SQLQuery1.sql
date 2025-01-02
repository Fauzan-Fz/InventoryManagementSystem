USE Inventory;

CREATE TABLE users
(
	id int PRIMARY KEY IDENTITY(1,1),
	username VARCHAR (MAX) NULL,
	password VARCHAR (MAX) NULL,
	role VARCHAR (MAX) NULL,
	status VARCHAR (MAX) NULL,
	date DATE NULL
)

SELECT * FROM users

INSERT INTO users (username,password,role,status,date) VALUES('admin','admin123','admin','Active','2024-12-26')

CREATE TABLE categories 
(
	id int PRIMARY KEY IDENTITY(1,1),
	category VARCHAR(MAX) NULL,
	date DATE NULL
)

SELECT * FROM categories

CREATE TABLE products 
(
	id int PRIMARY KEY IDENTITY(1,1),
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	category VARCHAR(MAX) NULL,
	price VARCHAR(MAX) NULL,
	stock VARCHAR(MAX) NULL,
	image_path VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_insert DATETIME NULL
)

SELECT *  FROM products

CREATE TABLE orders
(
	id int PRIMARY KEY IDENTITY(1,1),
	customers_id VARCHAR(MAX) NULL,
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX)NULL,
	category VARCHAR(MAX) NULL,
	qty INT NULL,
	orig_price FLOAT NULL,
	total_price FLOAT NULL,
	order_date DATE NULL
)

SELECT * FROM orders

ALTER TABLE orders
ADD customers_id INT NULL

CREATE TABLE customers
(
	id INT PRIMARY KEY IDENTITY(1,1),
	customer_id INT NULL,
	prod_id VARCHAR(MAX) NULL,
	total_price FLOAT NULL,
	amount FLOAT NULL,
	change FLOAT NULL,
	order_date DATE NULL
)

SELECT * FROM customers
