using Dapper_Data_Access_Layer.Bogus_Generator;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Entities_Repositories;
using Hospital_Management_System_Console.Employees_Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;

namespace Hospital_Management_System_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connections = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnections"].ConnectionString);

            await connections.OpenAsync();

            var transaction = connections.BeginTransaction();    

            await Seeding_all_Data_Program(connections, transaction);

            Console.ReadLine();
        }

        private static async Task Seeding_all_Data_Program(SqlConnection connections, IDbTransaction transaction)
        {
            Seeding_all_Dates<Employees_Repository, Employees> Seeding_Employees = new Seeding_all_Dates<Employees_Repository, Employees>(Seeding_Bogus.Seeding_Employees, new Employees_Repository(connections, transaction), transaction);

            await Seeding_Employees.Seeding_Repository();

            Seeding_all_Dates<Roles_Repository, Roles> Seeding_Roles = new Seeding_all_Dates<Roles_Repository, Roles>(Seeding_Bogus.Seeding_Roles, new Roles_Repository(connections, transaction), transaction);

            await Seeding_Roles.Seeding_Repository();

            Seeding_all_Dates<Has_Roles_Repository, Has_Role> Seeding_Has_Roles = new Seeding_all_Dates<Has_Roles_Repository, Has_Role>(Seeding_Bogus.Seeding_Has_Roles, new Has_Roles_Repository(connections, transaction), transaction);

            await Seeding_Has_Roles.Seeding_Repository();

            Seeding_all_Dates<Hospital_Repository, Hospital> Seeding_Hospitals = new Seeding_all_Dates<Hospital_Repository, Hospital>(Seeding_Bogus.Seeding_Hospitals, new Hospital_Repository(connections, transaction), transaction);

            await Seeding_Hospitals.Seeding_Repository();

            Seeding_all_Dates<Departments_Repository, Department> Seeding_Departments= new Seeding_all_Dates<Departments_Repository, Department>(Seeding_Bogus.Seeding_Departments, 
                new Departments_Repository(connections, transaction), transaction);

            await Seeding_Departments.Seeding_Repository();

            Seeding_all_Dates<In_Departments_Repository, In_Departments> Seeding_in_Departments = new Seeding_all_Dates<In_Departments_Repository, In_Departments>(Seeding_Bogus.Seeding_in_Departments,
                new In_Departments_Repository(connections, transaction), transaction);

            await Seeding_in_Departments.Seeding_Repository();

            Seeding_all_Dates<Shedules_Repository, Shedules> Seeding_Shedules = new Seeding_all_Dates<Shedules_Repository, Shedules>(Seeding_Bogus.Seeding_Shedules,
                new Shedules_Repository(connections, transaction), transaction);

            await Seeding_Shedules.Seeding_Repository();

            Seeding_all_Dates<Patients_Repository, Patients> Seeding_Patients = new Seeding_all_Dates<Patients_Repository, Patients>(Seeding_Bogus.Seeding_Patients,
               new Patients_Repository(connections, transaction), transaction);

            await Seeding_Patients.Seeding_Repository();

            Seeding_all_Dates<Patients_Cases_Repository, Patients_Case> Seeding_Patients_Cases = new Seeding_all_Dates<Patients_Cases_Repository, Patients_Case>(Seeding_Bogus.Seeding_Patients_Cases,
              new Patients_Cases_Repository(connections, transaction), transaction);

            await Seeding_Patients_Cases.Seeding_Repository();

            Seeding_all_Dates<Appointments_Statuses_Repository, Appointment_Status> Seeding_Appointment_Statuses = new Seeding_all_Dates<Appointments_Statuses_Repository, Appointment_Status>(Seeding_Bogus.Seeding_Appointment_Statuses,
              new Appointments_Statuses_Repository(connections, transaction), transaction);

            await Seeding_Appointment_Statuses.Seeding_Repository();

            Seeding_all_Dates<Appointments_Repository, Appointment> Seeding_Appointments = new Seeding_all_Dates<Appointments_Repository, Appointment>(Seeding_Bogus.Seeding_Appointments,
              new Appointments_Repository(connections, transaction), transaction);

            await Seeding_Appointments.Seeding_Repository();

            Seeding_all_Dates<Status_Histories_Repository, Status_Histories> Seeding_Status_Histories = new Seeding_all_Dates<Status_Histories_Repository, Status_Histories>(Seeding_Bogus.Seeding_Status_Histories,
               new Status_Histories_Repository(connections, transaction), transaction);

            await Seeding_Status_Histories.Seeding_Repository();

            Seeding_all_Dates<Documents_types_Repository, Document_types> Seeding_Documents_types = new Seeding_all_Dates<Documents_types_Repository, Document_types>(Seeding_Bogus.Seeding_Documents_types,
               new Documents_types_Repository(connections, transaction), transaction);

            await Seeding_Documents_types.Seeding_Repository();

            Seeding_all_Dates<Documents_Repository, Documents> Seeding_Documents = new Seeding_all_Dates<Documents_Repository, Documents>(Seeding_Bogus.Seeding_Documents,
               new Documents_Repository(connections, transaction), transaction);

            await Seeding_Documents.Seeding_Repository();

            await Console.Out.WriteLineAsync("All tables was inserted!!!");

            transaction.Commit();
        }
    }
}