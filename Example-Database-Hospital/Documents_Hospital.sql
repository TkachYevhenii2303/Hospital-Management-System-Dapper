Create database [Documents_Hospital]
Go

Use [Documents_Hospital]
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
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-In-Department] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
	
	Constraint [Unique_Values] Unique ([Employees_id], [Department_id], [Time_from]),
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Patients]
(
	[Id] [int] IDENTITY(1, 1) not null, 
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
	[Id] [int] IDENTITY(1, 1) not null, 
	[Patients_Id] [int] not null, 
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
Create table [Appointment]
(
	[Id] [int] IDENTITY(1, 1) not null, 
	[Patient_Case_Id] [int] not null,
	[In_Department_Id] [int] not null, 
	[Appointment_Start_time] [datetime] not null,
	[Appointment_End_time] [datetime] null default null,
	[Appointment_Status_Id] [int] not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Appointment] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-to-In_Department] Foreign key ([In_Department_Id]) references [In_Department]([Id]),

	Constraint [FK-to-Patient_Case_Id] Foreign key ([Patient_Case_Id]) references [Patients_Case]([Id]),
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table [Document_type]
(
	[Id] [int] IDENTITY(1, 1) not null,
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
	[Id] [int] IDENTITY(1, 1) not null,
	[Document_Internal_id] [nvarchar](64) not null,
	[Document_Name] [nvarchar](100) not null,
	[Document_type_Id] [int] not null,
	[Document_link] [nvarchar](100) not null,
	[Document_Details] [nvarchar](100) not null,

	[Patients_Id] [int] null, 
	[Patient_Case_Id] [int] null,
	[In_Department_Id] [int] null, 
	[Appointment_Status_Id] [int] null,

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

Drop table dbo.Appointment;
Drop table dbo.Document_type;
Drop table dbo.Documents;
Drop table dbo.In_Department;
Drop table dbo.Patients;
Drop table dbo.Patients_Case;