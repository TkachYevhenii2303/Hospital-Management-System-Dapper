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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Clinic_name] [nvarchar](100) not null,
	[Address] [nvarchar](100) not null,
	[Details] [text] null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),
	
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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Department_name] [nvarchar](100) not null,
	[Clinic_id] UNIQUEIDENTIFIER not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

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

Create table Employees
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[First_name] [nvarchar](100) not null,
	[Last_name] [nvarchar](100) not null,
	[User_name] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Phone_number] [nvarchar](255) null,
	[Mobile_number] [nvarchar](255) null,
	[Active_is] [bit] not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Role_name] [nvarchar](100) not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	
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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_id] UNIQUEIDENTIFIER not null,
	[Role_id] UNIQUEIDENTIFIER not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_id] UNIQUEIDENTIFIER not null,
	[Department_id] UNIQUEIDENTIFIER not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

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
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[In_Department_id] UNIQUEIDENTIFIER not null,
	[Date] [date] not null,
	[Time_start] [datetime] not null, 
	[Time_end] [datetime] not null,
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Shedule] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Shedule] Foreign key ([In_Department_id]) references [In_Department]([Id]),

	Constraint [Unique_Values_Shedule] Unique ([In_Department_id], [Date], [Time_start]),
)
Go


