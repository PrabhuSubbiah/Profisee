USE [VacancyReportSystem]
GO

--Products – Name, Manufacturer, Style, Purchase Price, Sale Price, Qty On Hand, Commission Percentage
--Salesperson – First Name, Last Name, Address, Phone, Start Date, Termination Date, Manager
--Customer – First Name, Last Name, Address, Phone, Start Date
--Sales – Product, Salesperson, Customer, Sales Date
--Discount – Product, Begin Date, End Date, Discount Percentage

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- drop tables
IF OBJECT_ID('[BeSpoked].[product]', 'U') IS NOT NULL
begin
	ALTER TABLE [BeSpoked].[product] DROP CONSTRAINT FK_product_style; 
end

IF OBJECT_ID('[BeSpoked].[sales_person]', 'U') IS NOT NULL
begin
	ALTER TABLE [BeSpoked].[sales_person] DROP CONSTRAINT FK_salesPerson_manager; 
end

IF OBJECT_ID('[BeSpoked].[sales]', 'U') IS NOT NULL
begin
	ALTER TABLE [BeSpoked].[sales] DROP CONSTRAINT FK_sales_product; 
	ALTER TABLE [BeSpoked].[sales] DROP CONSTRAINT FK_sales_salesPerson; 
	ALTER TABLE [BeSpoked].[sales] DROP CONSTRAINT FK_sales_customer; 
end

IF OBJECT_ID('[BeSpoked].[discount]', 'U') IS NOT NULL
begin
	ALTER TABLE [BeSpoked].[discount] DROP CONSTRAINT FK_discount_product; 
end

IF OBJECT_ID('[BeSpoked].[style]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[style]
end

IF OBJECT_ID('[BeSpoked].[product]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[product]
end

IF OBJECT_ID('[BeSpoked].[customer]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[customer]
end

IF OBJECT_ID('[BeSpoked].[manager]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[manager]
end

IF OBJECT_ID('[BeSpoked].[sales_person]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[sales_person]
end

IF OBJECT_ID('[BeSpoked].[sales]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[sales]
end

IF OBJECT_ID('[BeSpoked].[discount]', 'U') IS NOT NULL
begin
	drop table [BeSpoked].[discount]
end


IF OBJECT_ID('[BeSpoked].[style]', 'U') IS NULL
begin
	Create table [BeSpoked].[style](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[style] varchar(100) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
end

IF OBJECT_ID('[BeSpoked].[product]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[product](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[manufacturer] [varchar](50) NOT NULL,
		[style_id] [int] NOT NULL,
		[purchase_price]  money NOT NULL,
		[sales_price]  [money] NOT NULL,
		[quantity] [int] NOT NULL,
		[commission] [decimal](5,2) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [BeSpoked].[product] ADD CONSTRAINT FK_product_style FOREIGN KEY (style_id) REFERENCES [BeSpoked].[style] ([id]); 
end

IF OBJECT_ID('[BeSpoked].[manager]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[manager](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[first_name] [varchar](50) NOT NULL,
		[last_name] [varchar](50) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
end

IF OBJECT_ID('[BeSpoked].[sales_person]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[sales_person](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[first_name] [varchar](50) NOT NULL,
		[last_name] [varchar](50) NOT NULL,
		[address]  [varchar](100) NULL,
		[phone]  [varchar](15) NOT NULL,
		[start_date] [datetime] NOT NULL,
		[termination_date] [datetime] NOT NULL,
		[manager_id]  [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [BeSpoked].[sales_person] ADD CONSTRAINT FK_salesPerson_manager FOREIGN KEY (manager_id) REFERENCES [BeSpoked].[manager] ([id]); 
end

IF OBJECT_ID('[BeSpoked].[customer]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[customer](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[first_name] [varchar](50) NOT NULL,
		[last_name] [varchar](50) NOT NULL,
		[address]  [varchar](100) NULL,
		[phone]  [varchar](15) NOT NULL,
		[start_date] [datetime] NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
end

IF OBJECT_ID('[BeSpoked].[sales]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[sales](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[product_id] [int] NOT NULL,
		[sales_person_id] [int] NOT NULL,
		[customer_id] [int] NOT NULL,
		[sales_date] [datetime] NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [BeSpoked].[sales] ADD CONSTRAINT FK_sales_product FOREIGN KEY (product_id) REFERENCES [BeSpoked].[product] ([id]); 
	ALTER TABLE [BeSpoked].[sales] ADD CONSTRAINT FK_sales_salesPerson FOREIGN KEY (sales_person_id) REFERENCES [BeSpoked].[sales_person] ([id]); 
	ALTER TABLE [BeSpoked].[sales] ADD CONSTRAINT FK_sales_customer FOREIGN KEY (customer_id) REFERENCES [BeSpoked].[customer] ([id]); 
end

IF OBJECT_ID('[BeSpoked].[discount]', 'U') IS NULL
begin
	CREATE TABLE [BeSpoked].[discount](
		[id] [int] IDENTITY(1,1) NOT NULL,
		[product_id]  [int] NOT NULL,
		[begin_date] [datetime] NOT NULL,
		[end_date] [datetime] NULL,
		[discount] [decimal](5,2) NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [BeSpoked].[discount] ADD CONSTRAINT FK_discount_product FOREIGN KEY (product_id) REFERENCES [BeSpoked].[product] ([id]); 
end

 -- Seed with sample data for testing
INSERT INTO [BeSpoked].[customer] ([first_name],[last_name],[address],[phone],[start_date])
VALUES 
('Prabhu','Subbiah','39 Jugunu House','989-288-2872','06/01/2009'),
('Virat','Kohli','39 Bombay House','989-288-2112','06/01/2009'),
('Mahi','Dohni','39 Punjab street','989-455-2872','06/01/2009')
GO

INSERT INTO [BeSpoked].[style]
           ([style])
     VALUES
           ('Mountain Bike'),
		   ('Hybrid'),
		   ('Road'),
		   ('Touring'),
		   ('City')
Go

INSERT INTO [BeSpoked].[product] ([manufacturer],[style_id],[purchase_price],[sales_price],[quantity],[commission])
VALUES 
('Trek',1,258.99,479.99,100,20.50),
('Giant',2,2158.99,579.99,200,20.50),
('Cannondale',3,238.99,379.99,300,20.50),
('Scott',5,368.99,679.99,200,20.50),
('Bianchi',3,258.99,339.99,70,20.50),
('Canyon',4,158.99,219.99,80,20.50)
GO

INSERT INTO [BeSpoked].[manager] ([first_name],[last_name])
     VALUES
           ('Fahad','Alniner'),
		   ('Chris','Mcclary'),
		   ('Sireesha','Bunrottie')
Go

INSERT INTO [BeSpoked].[sales_person] ([first_name],[last_name],[address],[phone],[start_date],[termination_date],[manager_id])
VALUES
			('Mohamed','Juvare','39 Jugunu House','989-288-2872','06/01/2009', '1/1/1900', 1),
			('Markus','Odam','39 Bombay Beach','989-288-2872','06/01/2009', '1/1/1900', 2),
			('Bhu','Selvaraj','22 chennai Beach','989-288-2872','06/01/2009', '06/01/2020', 3),
			('Keith','Simmons','2020 Calle Lorca','989-288-2872','06/01/2009', '1/1/1900', 2),
			('Malcom','Marshell','10 Santa Fe','989-288-2872','06/01/2009', '06/01/2019', 1)

GO

INSERT INTO [BeSpoked].[discount] ([product_id],[begin_date],[end_date],[discount])
     VALUES
           (1,'06/01/2009', '3/31/2024', 20.00),
           (2,'06/01/2009', '3/31/2025', 20.00),
           (3,'06/01/2009', '3/31/2025', 20.00),
           (4,'06/01/2009', '3/31/2025', 20.00),
           (5,'06/01/2009', '3/31/2025', 20.00),
           (6,'06/01/2009', '3/31/2025', 20.00),
           (1,'06/01/2009', '3/31/2025', 20.00)
GO

INSERT INTO [BeSpoked].[sales] ([product_id] ,[sales_person_id],[customer_id],[sales_date])
VALUES  
(1,2,1,'01/01/2025'),
(1,2,1,'02/01/2025'),
(1,3,2,'02/12/2025'),
(1,6,3,'02/13/2025'),
(1,4,2,'02/13/2025'),
(1,5,3,'02/13/2025'),
(2,6,1,'01/01/2025'),
(3,2,1,'02/01/2025'),
(2,2,2,'02/12/2025'),
(2,3,3,'02/13/2025'),
(2,4,2,'02/13/2025'),
(2,5,3,'02/13/2025'),
(3,6,1,'01/01/2025'),
(3,2,1,'02/01/2025'),
(3,2,2,'02/12/2025'),
(3,3,3,'02/13/2025'),
(3,4,2,'02/13/2025'),
(3,5,3,'02/13/2025'),
(4,6,1,'01/01/2025'),
(4,2,1,'02/01/2025'),
(4,2,2,'02/12/2025'),
(4,3,3,'02/13/2025'),
(4,4,2,'02/13/2025'),
(4,5,3,'02/13/2025'),
(5,6,1,'01/01/2025'),
(5,2,1,'02/01/2025'),
(5,2,2,'02/12/2025'),
(5,3,3,'02/13/2025'),
(5,4,2,'02/13/2025'),
(5,5,3,'02/13/2025'),
(6,6,1,'01/01/2025'),
(6,2,1,'02/01/2025'),
(6,2,2,'02/12/2025'),
(6,3,3,'02/13/2025'),
(6,4,2,'02/13/2025'),
(6,5,3,'02/13/2025')

go


