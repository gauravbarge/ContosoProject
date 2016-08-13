use ContosoPOS

drop table dbo.InvoiceDetail 
go

drop table dbo.Product
go

Drop table dbo.Invoice
 go 


Create table dbo.Invoice
(
InvoiceID bigint primary key identity(1,1),
InvoiceNo nvarchar(50) unique,
SaleDatetime datetime,
InvoiceAmountBefore money,
DiscountPercentage decimal(5,2),
DiscountAmount money,
TaxPercentage decimal(5,2),
TaxAmount money,
FinalAmountAfterTax money,
ModifiedDate datetime
)

go



create table dbo.Product
(
ProductID bigint primary key identity(1,1),
Name nvarchar(100) ,
CostPrice money,
SellingPrice money,
AvailbleQuantity smallint,
ModifiedDate datetime
)

go
--Create table dbo.Inventory
--(
--InventoryID bigint primary key identity(1,1),
--ProductID bigint Foreign key references Product(ProductID),
--Quantity smallint 



--)

Create table dbo.InvoiceDetail
(
InvoiceDetailID bigint primary key identity(1,1),
InvoiceID bigint FOREIGN KEY references Invoice (InvoiceID),
ProductID bigint Foreign key references Product (ProductID),
QuantityPurchased smallint ,
ModifiedDate datetime
)

go 




INSERT INTO [dbo].[Product]
           ([Name]
           ,[CostPrice]
           ,[SellingPrice]
           ,[AvailbleQuantity]
           ,[ModifiedDate])
     VALUES
           ('Soap',10 ,12 ,100 ,GETDATE())
		   ,('Wheat',10 ,12 ,100 ,GETDATE())
		   ,  ('Rice',10 ,12 ,100 ,GETDATE())
		   ,  ('Chocolate',10 ,12 ,100 ,GETDATE())
		   ,  ('Milk',10 ,12 ,100 ,GETDATE())
		   ,  ('Curd',10 ,12 ,100 ,GETDATE())
		   ,  ('Oil',10 ,12 ,100 ,GETDATE())
		   ,  ('Butter',10 ,12 ,100 ,GETDATE())
		   ,  ('Biscuit',10 ,12 ,100 ,GETDATE())
		   ,  ('Cashewnuts',10 ,12 ,100 ,GETDATE())
GO

