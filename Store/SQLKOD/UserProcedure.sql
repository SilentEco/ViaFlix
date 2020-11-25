CREATE PROC AddUser
@Name nvarchar(100),
@Username varchar(50),
@Password varchar(50)
AS
INSERT INTO Customers(Name, Username, Password)
VALUES(@Name, @Username, @Password)