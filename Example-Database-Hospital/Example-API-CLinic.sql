Create database [Example-API-CLinic] 
Go

Use [Example-API-CLinic]
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table Clinic
(
	[Id] [int] IDENTITY(1, 1) not null, 
	[Clinic_name] [nvarchar](100) not null,
	[Address] [nvarchar](100) not null,
	[Details] [text] null,
	
	Constraint [PK-Clinic] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table Department
(
	[Id] [int] IDENTITY(1, 1) not null, 
	[Department_name] [nvarchar](100) not null,
	[Clinic_id] [int] not null,

	Constraint [PK-Department] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Department-Clinic] Foreign key ([Clinic_id]) references Clinic([Id])
)
Go


Set ansi_nulls on
Go
Set quoted_identifier on
Go

-- Creating the table for the Employees 
Create table Employees
(
	[Id] [int] IDENTITY(1, 1) not null, 
	[First_name] [nvarchar](100) not null,
	[Last_name] [nvarchar](100) not null,
	[User_name] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Phone_number] [nvarchar](255) null,
	[Mobile_number] [nvarchar](255) null,
	[Active_is] [bit] not null,

	Constraint [PK-Employees] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Value_User_Name] Unique ([User_name]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Role]
(
	[Id] [int] IDENTITY(1, 1) not null,
	[Role_name] [nvarchar](100) not null,

	
	Constraint [PK-Has-Role] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Role_Name] unique ([Role_name]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Has_Role]
(
	[Id] [int] IDENTITY(1, 1) not null, 
	[Employees_id] [int] not null,
	[Role_id] [int] not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,

	Constraint [PK-Has-Role-IDENTITY] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Has-Role-Employees] Foreign key ([Employees_id]) references [Employees]([Id]),
	Constraint [FK-Role-Has-Role] Foreign key ([Role_id]) references [Role]([Id]),

	Constraint [Unique_Values_Role_Employees] Unique ([Employees_id], [Role_id]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [In_Department]
(
	[Id] [int] IDENTITY(1, 1) not null,
	[Employees_id] [int] not null,
	[Department_id] [int] not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,

	Constraint [PK-In-Department] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-In-Department-Employees] Foreign key ([Employees_id]) references [Employees]([Id]),

	Constraint [Unique_Values] Unique ([Employees_id], [Department_id], [Time_from]),

	Constraint [FK-In-Department-Department] Foreign key ([Department_id]) references [Department]([Id])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Shedule]
(
	[Id] [int] IDENTITY(1, 1) not null,
	[In_Department_id] [int] not null,
	[Date] [date] not null,
	[Time_start] [datetime] not null, 
	[Time_end] [datetime] not null,

	Constraint [PK-Shedule] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Shedule] Foreign key ([In_Department_id]) references [In_Department]([Id]),

	Constraint [Unique_Values_Shedule] Unique ([In_Department_id], [Date], [Time_start]),
)
Go

Set Identity_Insert dbo.Clinic on

Insert into dbo.Clinic ([Id], [Clinic_name], [Address], [Details]) Values (1, N'Chicago Medical Center', N'3650 W Armitage Ave, Chicago, IL 60647 USA', N'An urgent care facility in Chicago, Illinois');
Insert into dbo.Clinic ([Id], [Clinic_name], [Address], [Details]) Values (2, N'U.S.A. Medical Monitoring Service, LLC', N'14000 S Military Trail, Delray Beach, FL 33484', N'957 Patient Access Representative jobs available in Delray Beach');
Insert into dbo.Clinic ([Id], [Clinic_name], [Address], [Details]) Values (3, N'Pak American Clinic', N'3939 Hollywood Blvd suite 2-b, Hollywood, FL 33021', N'In association with the State of Florida, we provide free medical care to patients as allowed by the State and Volunteer Services at the Broward Board of Health.');
Insert into dbo.Clinic ([Id], [Clinic_name], [Address], [Details]) Values (4, N'America Health Care Inc', N'8347 NW 36th St, Doral, FL 33166', N'Management has been kind of rocky at Sky-Box since I started the management');
Insert into dbo.Clinic ([Id], [Clinic_name], [Address], [Details]) Values (5, N'American Clinical Services', N'210 East 86th St, New York, NY 10028, IL 60647 USA', NULL);

Set Identity_Insert dbo.Clinic off

Set Identity_Insert dbo.Department on

Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (1, 1, N'Aerospace Medicine');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (2, 2, N'Brain Tumor Program');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (3, 1, N'Childrens Center');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (4, 3, N'Dental Specialties');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (5, 4, N'Emergency Medicine');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (6, 5, N'Executive Health Program');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (7, 2, N'Family Medicine');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (8, 3, N'Sleep Medicine');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (9, 1, N'Sports Medicine');
Insert into dbo.Department ([Id], [Clinic_id], [Department_name]) Values (10, 5, N'Transplant Center');

Set Identity_Insert dbo.Department off

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create procedure dbo.[Show_Company_and_Departments] @id int
as 
Select c.Clinic_name, c.Address
From Clinic c Join Department d on c.Id = d.Clinic_id
Where c.Id = @id

Go


Set Identity_Insert dbo.Role on
Insert into dbo.Role ([Id], [Role_name]) Values (1, N'General Practitioner (GP)');
Insert into dbo.Role ([Id], [Role_name]) Values (2, N'Surgeon');
Insert into dbo.Role ([Id], [Role_name]) Values (3, N'Specialist');
Insert into dbo.Role ([Id], [Role_name]) Values (4, N'Hospitalist');
Insert into dbo.Role ([Id], [Role_name]) Values (5, N'Emergency Medicine Physician');
Set Identity_Insert dbo.Role off

Set Identity_Insert dbo.Employees on
Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (1, N'John', N'Smith', N'jsmith', N'jsmith@example.com', N'password123', N'555-555-5555', 'N555-555-1212', 1);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (2, N'Jane', 'Doe', 'jdoe', 'jdoe@example.com', 'password456', '555-123-4567', '555-987-6543', 1);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (3, N'Michael', 'Johnson', 'mjohnson', 'mjohnson@example.com', 'abc123', '555-867-5309', '555-555-5555', 1);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (4, N'Sarah', 'Lee', 'slee', 'slee@example.com', 'qwerty123', '555-555-1212', '555-123-4567', 0);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (5, N'William', 'Brown', 'wbrown', 'wbrown@example.com', 'password789', '555-987-6543', '555-555-1212', 0);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (6, N'Elizabeth', 'Davis', 'edavis', 'edavis@example.com', '12345678', '555-555-5555', '555-123-4567', 0);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (7, N'Christopher', 'Wilson', 'cwilson', 'cwilson@example.com', 'pass1234', '555-123-4567', '555-555-5555', 1);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (8, N'Ashley', 'Anderson', 'aanderson', 'aanderson@example.com', '98765432', '555-555-1212', '555-987-6543', 0);

Insert into dbo.Employees([Id], [First_name], [Last_name], [User_name], [Email], [Password], [Mobile_number], [Phone_number], [Active_is]) 
Values (9, N'David', N'Taylor', N'dtaylor', N'dtaylor@example.com', N'letmein123', N'555-867-5309', N'555-555-1212', 1);
Set Identity_Insert dbo.Employees off

Set Identity_Insert dbo.Has_Role on

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (1, 1, 2, 0, '2020-12-01', NULL);

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (2, 2, 1, 1, '2021-12-01', NULL);

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (3, 3, 1, 1, '2020-10-01', NULL);

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (4, 4, 3, 1, '2020-05-20', NULL);

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (5, 5, 4, 0, '2020-12-01', '2022-11-10');

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (6, 6, 4, 1, '2020-12-01', NULL);

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (7, 7, 5, 0, '2020-12-01', '2022-11-10');

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (8, 8, 2, 1, '2020-12-01', '2022-11-10');

Insert into dbo.Has_Role ([Id], [Employees_id], [Role_id], [Active_is], [Time_from], [Time_to]) 
Values (9, 9, 1, 1, '2020-12-01', '2022-11-10');

Set Identity_Insert dbo.Has_Role off 


