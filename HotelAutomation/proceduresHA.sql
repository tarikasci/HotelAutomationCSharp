create proc prc_UnitTypes_Insert @Id int,@Name nvarchar(50), @isActive bit as
	if(exists(select * from UnitTypes ut where ut.Name = @Name))
	begin
		print 'This unit type already exists'
	end
	else
	begin
		INSERT into UnitTypes values(@Name,@isActive)
	end
go

create proc prc_Cases_Insert @Id int,@Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	if(exists(select * from Cases where Cases.Name = @Name)) 
	begin
		print 'This case already exists'
	end
	else
	begin
		INSERT into Cases values(@Name,@Description,@isActive)
	end
go

create proc prc_Cases_Select as
	SELECT * from Cases where isActive = 1
go

create proc prc_UnitTypes_Select as
	SELECT * from UnitTypes where isActive = 1
go

create proc prc_Cases_Update @Id int,@Name nvarchar(50),@Description nvarchar (500),@isActive bit as
	UPDATE Cases set Name = @Name, Description = @Description, isActive = @isActive where Id = @Id
go

create proc prc_UnitTypes_Update @Id int, @Name nvarchar(50), @isActive bit as
	UPDATE UnitTypes set Name = @Name, isActive = @isActive where Id = @Id
go


create trigger trg_DeleteCases on Cases instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Cases set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteCustomers on Customers instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Customers set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteCategories on Categories instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Categories set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteRooms on Rooms instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Rooms set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteRoomTypes on RoomTypes instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE RoomTypes set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteUnitTypes on UnitTypes instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE UnitTypes set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteCaseMovementType on CaseMovementType instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE CaseMovementType set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteEmployees on Employees instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Employees set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteProducts on Products instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Products set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteProperties on Properties instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Properties set isActive = 0 where Id = @Id
go
CREATE trigger trg_DeleteSuppliers on Suppliers instead of delete as
	declare @Id int
	select @Id = Id from deleted
	UPDATE Suppliers set isActive = 0 where Id = @Id
go



create proc prc_Cases_Delete @Id int,@Name nvarchar(50),@Description nvarchar(500),@isActive bit as
	DELETE from Cases where Id = @Id
go

create proc prc_UnitTypes_Delete @Id int, @Name nvarchar(50), @isActive bit as
	Delete from UnitTypes where Id = @Id
go


create proc prc_Categories_Select as
	SELECT * from Categories where isActive = 1
go
create proc prc_Categories_Insert @Id int, @Name nvarchar(50), @isActive bit as
	if(exists(select * from Categories where Categories.Name = @Name)) 
	begin
		print 'This category already exists'
	end
	else
	begin
		INSERT into Categories values(@Name,@isActive)
	end
go
create proc prc_Categories_Update @Id int, @Name nvarchar(50), @isActive bit as
	UPDATE Categories set Name = @Name, isActive = @isActive where Id = @Id
go
create proc prc_Categories_Delete @Id int, @Name nvarchar(50), @isActive bit as
	DELETE from Categories where Id = @Id
go


create proc prc_Products_Select as
	SELECT * from Products where isActive = 1
go
create proc prc_Products_Insert @Id int, @Name nvarchar(50), @Price money, @Quantity float, @CategoryID int, @UnitTypeID int, @isActive bit as
	if(exists(select * from Products where Products.Name = @Name)) 
	begin
		print 'This product already exists'
	end
	else
	begin
		INSERT into Products values(@Name,@Price,@Quantity,@CategoryID,@UnitTypeID,@isActive)
	end
go
create proc prc_Products_Update @Id int, @Name nvarchar(50), @Price money, @Quantity float, @CategoryID int, @UnitTypeID int, @isActive bit as
	UPDATE Products set Name = @Name,Price = @Price,Quantity = @Quantity,CategoryID = @CategoryID,UnitTypeID = @UnitTypeID,isActive = @isActive where Id = @Id
go
create proc prc_Products_Delete @Id int, @Name nvarchar(50), @Price money, @Quantity float, @CategoryID int, @UnitTypeID int, @isActive bit as
	DELETE from Products where Id = @Id
go


create proc prc_RoomTypes_Select as 
	SELECT * from RoomTypes where isActive = 1
go
create proc prc_RoomTypes_Insert @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	if(exists(select * from RoomTypes where RoomTypes.Name = @Name)) 
	begin
		print 'This room type already exists'
	end
	else
	begin
		INSERT into RoomTypes values(@Name,@Description,@isActive)
	end
go
create proc prc_RoomTypes_Update @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	UPDATE RoomTypes set Name = @Name, Description = @Description, isActive = @isActive where Id = @Id
go
create proc prc_RoomTypes_Delete @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	DELETE from RoomTypes where Id = @Id
go



create proc prc_Rooms_Select as 
	SELECT * from Rooms where isActive = 1
go
create proc prc_Rooms_Insert @Id int, @Name nvarchar(50), @Description nvarchar(500),@RoomTypeID int, @isActive bit as
	if(exists(select * from Rooms where Rooms.Name = @Name)) 
	begin
		print 'This room already exists'
	end
	else
	begin
		INSERT into Rooms values(@Name,@Description,@RoomTypeID,@isActive)
	end
go
create proc prc_Rooms_Update @Id int, @Name nvarchar(50), @Description nvarchar(500),@RoomTypeID int, @isActive bit as
	UPDATE Rooms set Name = @Name, Description = @Description,RoomTypeID = @RoomTypeID, isActive = @isActive where Id = @Id
go
create proc prc_Rooms_Delete @Id int, @Name nvarchar(50), @Description nvarchar(500),@RoomTypeID int, @isActive bit as
	DELETE from Rooms where Id = @Id
go


create proc prc_Properties_Select as 
	SELECT * from Properties where isActive = 1
go
create proc prc_Properties_Insert @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	if(exists(select * from Properties where Properties.Name = @Name)) 
	begin
		print 'This property already exists'
	end
	else
	begin
		INSERT into Properties values(@Name,@Description,@isActive)
	end
go
create proc prc_Properties_Update @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	UPDATE Properties set Name = @Name, Description = @Description, isActive = @isActive where Id = @Id
go
create proc prc_Properties_Delete @Id int, @Name nvarchar(50), @Description nvarchar(500), @isActive bit as
	DELETE from Properties where Id = @Id
go


create proc prc_RoomProperties_Insert @RoomID int, @PropertyID int, @Value smallint as
	INSERT into RoomProperties values(@RoomID,@PropertyID,@Value)
go


create proc prc_Customers_Select as --!!!!!!!!!!!!!!!!!!!!!!
	SELECT Id,Name,Surname,CompanyName as 'Company Name',IdentityNO as 'Identity Number',Phone as 'Phone Number',BirthDate as 'Birth Date',case MaritalStatus when 1 then 'Single' when 2 then 'Married' end as 'Marital Status', case Gender when 1 then 'Female' when 2 then 'Male' end as 'Gender',isActive from Customers where isActive = 1
go
create proc prc_Customers_Insert @Id int, @Name nvarchar(50), @Surname nvarchar(50), @CompanyName nvarchar(250), @IdentityNO char(11),@Phone char(14),@BirthDate date,@MaritalStatus tinyint,@Gender tinyint,@isActive bit as
	if(exists(select * from Customers where Customers.IdentityNO = @IdentityNO)) 
	begin
		print 'This customer already exists'
	end
	else
	begin
		INSERT into Customers values(@Name,@Surname,@CompanyName,@IdentityNO,@Phone,@BirthDate,@MaritalStatus,@Gender,@isActive)
	end		
go
create proc prc_Customers_Update @Id int, @Name nvarchar(50), @Surname nvarchar(50), @CompanyName nvarchar(250), @IdentityNO char(11),@Phone char(14),@BirthDate date,@MaritalStatus tinyint,@Gender tinyint,@isActive bit as
	Update Customers set Name = @Name, Surname = @Surname, CompanyName = @CompanyName, IdentityNO = @IdentityNO, Phone = @Phone, BirthDate = @BirthDate, MaritalStatus = @MaritalStatus, Gender = @Gender, isActive=@isActive where Id = @Id
go
create proc prc_Customers_Delete @Id int, @Name nvarchar(50), @Surname nvarchar(50), @CompanyName nvarchar(250), @IdentityNO char(11),@Phone char(14),@BirthDate date,@MaritalStatus tinyint,@Gender tinyint,@isActive bit as
	Delete from Customers where Id = @Id
go


create proc prc_Employees_Select as
	Select * from Employees
go
create proc prc_Employees_Insert @Id int,@Name nvarchar(50),@Surname nvarchar(50),@IdentityNO char(11),@Phone char(14),@Address nvarchar(500),@BirthDate date,@HireDate datetime,@Salary money,@UserName nvarchar(50),@Password nvarchar(15),@isActive bit as
	if(exists(select * from Employees where Employees.IdentityNO = @IdentityNO)) 
	begin
		print 'This employee already exists'
	end
	else
	begin
		INSERT into Employees values(@Name,@Surname,@IdentityNO,@Phone,@Address,@BirthDate,@HireDate,@Salary,@UserName,@Password,@isActive)
	end
go
create proc prc_Employees_Update @Id int,@Name nvarchar(50),@Surname nvarchar(50),@IdentityNO char(11),@Phone char(14),@Address nvarchar(500),@BirthDate date,@HireDate datetime,@Salary money,@UserName nvarchar(50),@Password nvarchar(15),@isActive bit as
	UPDATE Employees set Name = @Name, Surname = @Surname, IdentityNO = @IdentityNO, Phone = @Phone, Address = @Address, BirthDate = @BirthDate, HireDate = @HireDate, Salary = @Salary, UserName = @UserName, Password = @Password, isActive = @isActive where Id = @Id
go
create proc prc_Employees_Delete @Id int,@Name nvarchar(50),@Surname nvarchar(50),@IdentityNO char(11),@Phone char(14),@Address nvarchar(500),@BirthDate date,@HireDate datetime,@Salary money,@UserName nvarchar(50),@Password nvarchar(15),@isActive bit as
	Delete from Employees where Id = @Id
go
create proc prc_Employees_Login @un nvarchar(50),@pwd nvarchar(15) as
	SELECT * from Employees where UserName = @un and Password = @pwd
go

create proc prc_Sales_Insert @Id int,@CustomerID int,@EmployeeID int,@RoomID int,@RoomPrice money,@SaleDate datetime as
	INSERT into Sales values(@CustomerID,@EmployeeID,@RoomID,@RoomPrice,@SaleDate);
	Select SCOPE_IDENTITY()
go
create proc prc_SalesDetails_Insert @SaleID int,@ProductID int,@Quantity float,@Price money,@Discount float as
	INSERT into SalesDetails values(@SaleID,@ProductID,@Quantity,@Price,@Discount)
