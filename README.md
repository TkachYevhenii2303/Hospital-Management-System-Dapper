## Example-Dapper-API-Migration
![Database](https://img.shields.io/badge/Database--Server-<COLOR>)
![ORM](https://img.shields.io/badge/ORM--Dapper-FAD02C)
![ASP](https://img.shields.io/badge/ASP--NET--CORE-738FA7)

![Database Part 1](https://img.shields.io/badge/Employees--Depatments-D01110)
![Database Part 2](https://img.shields.io/badge/Patients--Appointment-D01110)
![Database Part 3](https://img.shields.io/badge/Documents-D01110)

Creating the base ASP.NET Core API and Migration to Entity Framework, also I use the such ORM as Dapper and Sql-Server like main tool for create databases

Firstly, I created the database for the API. It was database [Employees and Shedule + Department and Clinic + Patients and Documents]


![image](https://www.linkpicture.com/q/Hospital-Dapper-Database.png)


>### Clinic and Department

The clinic table lists all clinics we operate. The clinic_name is the UNIQUE attribute while attributes address and details attributes are used to store the location of that clinic and any other information in a textual format. This table is very important when we operate more than one clinic.

The second table in this subject area is the department table. This is the place where we’ll store the different departments of each clinic. Each department is UNIQUELY defined by its department_name and the ID of the clinic it belongs to.

>### Employees 
The central table here is the employee table. This holds a list of all employees working in any of our clinics, no matter what their role.

1. first_name & last_name – Are the first and the last name of that employee.

2. user_name – A UNIQUE value the employee will use to access our system.

3. password – A password the user will use to access the system.

4. email, mobile and phone – Are arbitrary contact details we’ll store for users. We can expect that we’ll have at least one of them in our system.

5. is_active – Denotes if the user is currently active in our system. This flag is set to True if the employee currently works in the clinic and false otherwise.

>### Role and Has_Role 

The first is the role dictionary. It contains only UNIQUE role_name values. We can expect that roles will be closely related to positions in the clinic (i.e. doctor, nurse, medical assistant). 

Note that role-related user permissions are not stored in the database; we would test permissions on the application’s front end.

The second table, has_role , stores relationships between employees and roles. Each record in this table must contain foreign keys from both the employee_id and the role_id. We’ll always store the time_from timestamp, as it denotes when each user started this role. We store the moment they stopped performing a role in the time_to timestamp. 

This value could be set in advance (e.g. hiring a temporary employee for a six-month period) or it could be open-ended (e.g. a regular hire). I have made this attribute NULLable so that it can accept either situation. 

>### In_Department

The in_department table has almost exactly the same structure as the has_role table. It has two foreign key attributes and a time range when this data is valid. The is_active attribute also has the same purpose. In this table, the employee_id – department_id – time_from combination forms the UNIQUE key of the table. Again, we should check for overlapping time intervals when data in this table is added or changed. 

The idea is that each employee should work in only one department at a time. This model allows us to assign the same employee to more than one department, but we should only do that in special circumstances.

>### Shedule 

The schedule table is the last table in this subject area. It looks simple, but it’s very important. Schedules should be defined upfront so that administrators can effectively plan staff for the week or month. Working in an environment where no-one knows what to expect is very stressful on everyone, and very hard for the managers to organize. This table aims to prevent this situation. 

>### Patients 

Patients are the most important part of our clinic because there would be no need for a clinic without them. For each patient, we’ll store only their first and last name. We could have other details as well, but these would add no value to this model. Besides, you could always add attributes to this table for those details.

>### Appointment 

Next in importance is the appointment table. Patients usually expect to make an appointment to go to the clinic or see the doctor. We’ll store the clinic location, the patient, the department, and the employees involved in the appointment. Each record will contain:

1. patient_case_id –Relates this appointment to a patient and a specific case. (We’ll describe the case in a minute).

2. in_department_id – The ID of the employee (usually a doctor) in charge of that appointment.

3. time_created – When this record was created in our system.

4. appointment_start_time and appointment_end_time – Defines the start time of an appointment and its duration. Please notice that the end time can be NULL because it could be entered after the appointment ends.

5. appointment_status_id – References the appointment_status table and denotes the current status of that appointment, such as “scheduled” or “in progress”. If the patient wanted to postpone an appointment, we would assign a “postponed” status to this field and create a new appointment.

>### Patient_case 

We’ve already mentioned that appointments are not directly related to patients. I’ve used the patient_case table to link the two relevant tables. The reason for that is simple. A patient could come to our clinic multiple times and for various reasons. Each reason for a visit is treated as one case.

>### Appointment_status 

We have already mentioned the appointment_status table. It is a simple dictionary that stores all possible appointment statuses, such as “scheduled”, “canceled”, “postponed”, or “completed”. Status information will help us quickly filter appointments based on current status, e.g. finding all appointments scheduled for today. Generally, each appointment will change its status from “scheduled” to another status after its start time and/or end time have passed.

>### Documents 

The last part of our model is the Documents subject area. Only two of its six tables are unique to this subject area: document and document_type. The remaining tables are copies from other subject areas. They are here to simplify the model.

The document table contains all documents related to patients in any way. This is where we’ll store medical records, bills, and any other document type. For each document, we’ll record:

1. document_internal_id – An internal designation we’ll use to UNIQUELY denote that document.

2. document_name – A name we have chosen for that document.

3. document_type_id – A reference to the document_type dictionary.

4. time_created – A timestamp when this document was created.

5. document_url – An address of the location where the document is stored.

6. details – Are all details used to closely describe this document.











