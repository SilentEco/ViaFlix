CREATE PROC AddUser
@Name nvarchar(100),
@Username varchar(50),
@Password varchar(50),
@Phonenumber varchar(50),
@Email varchar(50),
@Adress varchar(50)
AS
INSERT INTO Customers(Name, Username, Password, Phonenumber, Email, Adress)
VALUES(@Name, @Username, @Password, @Phonenumber, @Email, @Adress)