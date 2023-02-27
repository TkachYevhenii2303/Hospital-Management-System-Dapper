Create database [Patients_appointments]
Go

Use [Patients_appointments]
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go
Create table Patients 
(
	[Id] [int] Identity(1, 1) not null, 
	[First_name] [nvarchar](100) not null,
	[Last_name] [nvarchar](100) not null,

	Constraint [PK-Patients] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go
Set quoted_identifier on
Go

Create table [Patients_case]
(
	[Id] [int] Identity(1, 1) not null, 
	[Patients_Id] [int] not null,
	[Start_time] [datetime] not null, 
	[End_time] [datetime] null,
	[In_Progress] [bit] not null,
	[Total_Cost] [money] not null,
	[Amount_Paid] [money] not null,

	Constraint [PK-Patients_case] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Patients_case] Foreign key ([Patients_Id]) references Patients([Id])
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
)
Go