Create database [Hospital_Management_System_Database] 
Go

Use [Hospital_Management_System_Database]
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Hospital]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Hospital_title] [nvarchar](100) not null,
	[Address] [nvarchar](100) not null,
	[Details] [nvarchar](255) null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),
	
	Constraint [PK-Clinic] Primary key Clustered([ID] ASC)
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
	[Department_title] [nvarchar](100) not null,
	[Hospital_ID] UNIQUEIDENTIFIER not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Department] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Department-to-Hospital] Foreign key ([Hospital_ID]) references [Hospital]([ID])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Employees]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[First_title] [nvarchar](100) not null,
	[Last_title] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Mobile] [nvarchar](255) null,
	[Active_is] [bit] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Employees] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Roles]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Role_title] [nvarchar](100) not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),
	
	Constraint [PK-Roles] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Role_title] unique ([Role_title])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Has_Role]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_ID] UNIQUEIDENTIFIER not null,
	[Roles_ID] UNIQUEIDENTIFIER not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Has-Role] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Has-Role-to-Employees] Foreign key ([Employees_ID]) references [Employees]([ID]),
	
	Constraint [FK-Role-Has-to-Roles] Foreign key ([Roles_ID]) references [Roles]([ID]),

	Constraint [Unique_Values_Roles_Employees] Unique ([Employees_ID], [Roles_ID])
)
Go

alter table [Has_Role]
drop constraint [Unique_Values_Roles_Employees];
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [In_Departments]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_ID] UNIQUEIDENTIFIER not null,
	[Departments_ID] UNIQUEIDENTIFIER not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-In-Department] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-In-Department-to-Employees] Foreign key ([Employees_ID]) references [Employees]([ID]),

	Constraint [FK-In-Department-to-Department] Foreign key ([Departments_ID]) references [Department]([ID]),

	Constraint [Unique_Values] Unique ([Employees_ID], [Departments_ID], [Time_from])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Shedules]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[In_Departments_ID] UNIQUEIDENTIFIER not null,
	[Time_start] [datetime] not null, 
	[Time_end] [datetime] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Shedule] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Shedule] Foreign key ([In_Departments_ID]) references [In_Departments]([ID]),

	Constraint [Unique_Values_Shedule] Unique ([In_Departments_ID], [Time_start]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Patients]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[First_title] [nvarchar](100) not null,
	[Last_title] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Mobile] [nvarchar](255) null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Patients] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Patients_Cases]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Patients_ID] UNIQUEIDENTIFIER not null, 
	[Start_time] [datetime] not null,
	[End_time] [datetime] null default null,
	[Total_Cost] [decimal](10, 2) null default null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Patients_Case] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Patients_Cases-to-Patients] Foreign key ([Patients_ID]) references [Patients]([ID])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Appointment_Status]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Status_title] [nvarchar](100) not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Appointment_Status] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go


Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Appointments]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Patient_Cases_ID] UNIQUEIDENTIFIER not null,
	[In_Departments_ID] UNIQUEIDENTIFIER not null, 
	[Appointment_Status_ID] UNIQUEIDENTIFIER not null,

	[Appointment_Start_time] [datetime] not null,
	[Appointment_End_time] [datetime] null default null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Appointment] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Appointments-to-In_Department] Foreign key ([In_Departments_ID]) references [In_Departments]([ID]),

	Constraint [FK-Appointments-to-Patient_Case_Id] Foreign key ([Patient_Cases_ID]) references [Patients_Cases]([ID]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Status_Histories]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Appointment_ID] UNIQUEIDENTIFIER not null,
	[Appointment_Status_ID] UNIQUEIDENTIFIER not null,
	[Details] [nvarchar](255) not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Status_History] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Status_Histories-Appointment] Foreign key ([Appointment_ID]) references [Appointments]([ID]), 

	Constraint [FK-Status_Histories-Appointment_Status_Id] Foreign key ([Appointment_Status_ID]) references [Appointment_Status]([ID])
)
Go


Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Document_types]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Types_title] [nvarchar](255) not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Documents_type] Primary key Clustered([ID] ASC)
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
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Documents_title] [nvarchar](100) not null,
	[Documents_link] [nvarchar](100) not null,
	[Documents_details] [nvarchar](100) not null,

	[Patients_ID] UNIQUEIDENTIFIER null, 
	[Patient_Case_ID] UNIQUEIDENTIFIER null,
	[In_Department_ID] UNIQUEIDENTIFIER null, 
	[Appointment_Status_ID] UNIQUEIDENTIFIER null,
	[Documents_types_ID] UNIQUEIDENTIFIER not null,

	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Documents] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Documents-to_Documents_type] foreign key ([Documents_types_ID]) references [Document_types]([ID]),

	Constraint [FK-Documents-to-Patients-Second] Foreign key ([Patients_ID]) references [Patients]([ID]),
		
	Constraint [FK-Documents-to-In_Department-Second] Foreign key ([In_Department_ID]) references [In_Departments]([ID]),

	Constraint [FK-Documents-to-Patient_Case_Id-Second] Foreign key ([Patient_Case_ID]) references [Patients_Cases]([ID]),

	Constraint [FK-Documents-to-Appointment_Status-Second] Foreign key ([Appointment_Status_ID]) references [Appointments]([ID])
)
Go

Drop procedure Employees_and_Departments

SELECT DISTINCT d.Department_title 
FROM Employees e
INNER JOIN In_Departments id ON e.ID = id.Employees_ID
INNER JOIN Department d ON d.Id = id.Departments_ID
WHERE e.ID = '2CC8342E-F8AB-48AD-BD45-0D680C22AC69';

CREATE PROCEDURE Employees_and_Departments_Server @ID UNIQUEIDENTIFIER
AS
BEGIN
    DECLARE @Employees TABLE (First_title NVARCHAR(50), Last_title NVARCHAR(50), Email NVARCHAR(50), Mobile NVARCHAR(50))
    DECLARE @Departments TABLE (Department_title NVARCHAR(50))
    
    INSERT INTO @Employees (First_title, Last_title, Email, Mobile)
    SELECT First_title, Last_title, Email, Mobile
    FROM Employees
    WHERE ID = @ID
    
    INSERT INTO @Departments (Department_title)
    SELECT Department_title
    FROM Department
    WHERE Id IN (
        SELECT Departments_ID
        FROM In_Departments
        WHERE Employees_ID = @ID
    )
    
    SELECT DISTINCT e.First_title, e.Last_title, e.Email, e.Mobile, d.Department_title
    FROM @Employees AS e
    LEFT OUTER JOIN @Departments AS d ON 1=1
END
GO

Execute Employees_and_Departments_Server '2CC8342E-F8AB-48AD-BD45-0D680C22AC69';

CREATE PROCEDURE Employees_and_Departments
    @ID UNIQUEIDENTIFIER
AS 
BEGIN
    SELECT 
        Employees.First_title, 
        Employees.Last_title, 
        Employees.Email, 
        Employees.Mobile,
        (SELECT Department.Department_title FROM In_Departments 
         INNER JOIN Department ON In_Departments.Departments_ID = Department.Id
         WHERE In_Departments.Employees_ID = Employees.ID
         FOR JSON PATH) AS department_titles
    FROM Employees 
    WHERE Employees.ID = @ID
END

Drop procedure Employees_and_Departments;

Execute Employees_and_Departments '2CC8342E-F8AB-48AD-BD45-0D680C22AC69';