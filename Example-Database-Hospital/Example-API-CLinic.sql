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

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Patients]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[First_name] [nvarchar](100) not null,
	[Last_name] [nvarchar](100) not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Patients] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Patients_Case]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Patients_Id] UNIQUEIDENTIFIER not null, 
	[Start_time] [datetime] not null,
	[End_time] [datetime] null default null,
	[In_Progress] [bit] not null,
	[Total_Cost] [decimal](10, 2) null default null,
	[Amound_Paid] [decimal](10, 2) null default null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Patients_Case] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-to-Patients] Foreign key ([Patients_Id]) references [Patients]([Id])
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Appointment_Status]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Status_Name] [nvarchar](100) not null,

	Constraint [PK-Appointment_Status] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go


Alter table [Appointment_Status] add [Created_at] [datetime] null default GETDATE();
Alter table [Appointment_Status] add [Updated_at] [datetime] null default GETDATE();

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Appointment]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Patient_Case_Id] UNIQUEIDENTIFIER not null,
	[In_Department_Id] UNIQUEIDENTIFIER not null, 
	[Appointment_Start_time] [datetime] not null,
	[Appointment_End_time] [datetime] null default null,
	[Appointment_Status_Id] UNIQUEIDENTIFIER not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Appointment] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-to-In_Department] Foreign key ([In_Department_Id]) references [In_Department]([Id]),

	Constraint [FK-to-Patient_Case_Id] Foreign key ([Patient_Case_Id]) references [Patients_Case]([Id]),

	Constraint [FK-to-Appointment_Status] Foreign key ([Appointment_Status_Id]) references [Appointment_Status]([Id])
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Status_History]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Appointment_Id] UNIQUEIDENTIFIER not null,
	[Appointment_Status_Id] UNIQUEIDENTIFIER not null,
	[Status_time] [datetime] not null,
	[Details] [nvarchar](max) not null,

	Constraint [PK-Status_History] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Appointment] Foreign key ([Appointment_Id]) references [Appointment]([Id]), 

	Constraint [FK-Appointment_Status_Id] Foreign key ([Appointment_Status_Id]) references [Appointment_Status]([Id])
)
Go

Alter table [Status_History] add [Created_at] [datetime] null default GETDATE();
Alter table [Status_History] add [Updated_at] [datetime] null default GETDATE();

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Document_type]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Type_name] [nvarchar](max) not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Documents_type] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Documents]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Document_Internal_id] [nvarchar](64) not null,
	[Document_Name] [nvarchar](100) not null,
	[Document_type_Id] UNIQUEIDENTIFIER not null,
	[Document_link] [nvarchar](100) not null,
	[Document_Details] [nvarchar](100) not null,

	[Patients_Id] UNIQUEIDENTIFIER null, 
	[Patient_Case_Id] UNIQUEIDENTIFIER null,
	[In_Department_Id] UNIQUEIDENTIFIER null, 
	[Appointment_Status_Id] UNIQUEIDENTIFIER null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Documents] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [UN_Document_Id] Unique ([Document_Internal_id]),

	Constraint [FK-to_Documents_type] foreign key ([Document_type_Id]) references [Document_type]([Id]),

	Constraint [FK-to-Patients-Second] Foreign key ([Patients_Id]) references [Patients]([Id]),
		
	Constraint [FK-to-In_Department-Second] Foreign key ([In_Department_Id]) references [In_Department]([Id]),

	Constraint [FK-to-Patient_Case_Id-Second] Foreign key ([Patient_Case_Id]) references [Patients_Case]([Id]),

	Constraint [FK-to-Appointment_Status-Second] Foreign key ([Appointment_Status_Id]) references [Appointment]([Id])
)
Go

