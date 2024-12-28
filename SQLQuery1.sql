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


