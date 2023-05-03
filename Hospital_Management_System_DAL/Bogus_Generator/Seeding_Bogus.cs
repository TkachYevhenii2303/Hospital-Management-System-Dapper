using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Dapper_Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dapper_Data_Access_Layer.Bogus_Generator
{
    public static class Seeding_Bogus
    {
        // Private static Lists for each Entity from database, and using them for Seeding Operations in Concrete Methods
        #region Lists Entities from the Database
        
        private static List<Employees> Employees { get; set; } = new();

        private static List<Roles> Roles { get; set; } = new();

        private static List<Has_Role> Has_Roles { get; set; } = new();

        private static List<Hospital> Hospitals { get; set; } = new();

        private static List<Department> Departments { get; set; } = new();

        private static List<In_Departments> In_Departments { get; set; } = new();

        private static List<Shedules> Shedules { get; set; } = new();

        private static List<Patients> Patients { get; set; } = new();

        private static List<Patients_Case> Patients_Cases { get; set; } = new();

        private static List<Appointment_Status> Appointment_Statuses { get; set; } = new(); 

        private static List<Appointment> Appointments { get; set; } = new();

        private static List<Status_Histories> Status_Histories { get; set; } = new();

        private static List<Document_types> Documents_types { get; set; } = new();

        private static List<Documents> Documents { get; set; } = new();

        #endregion

        /// <summary>
        /// Seeding Operaions for each Entity and Return Upgrage Entity with Random Data using Bogus Lib
        /// </summary>
        /// <returns>New Entity with Random information</returns>
        #region Methods for seeding all Entities

        public static List<Employees> Seeding_Employees()
        {
            Employees = new Faker<Employees>(locale: "en")
                .RuleFor(x => x.First_title, f => f.Person.FirstName)
                .RuleFor(x => x.Last_title, f => f.Person.LastName)
                .RuleFor(x => x.Email, (f, o) => f.Internet.Email(o.First_title, o.Last_title))
                .RuleFor(x => x.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Password, f => f.Internet.Password())
                .RuleFor(x => x.Active_is, f => f.Random.Bool())
                .Generate(20);

            return Employees; 
        }

        public static List<Roles> Seeding_Roles()
        {
            Roles = new Faker<Roles>().Generate(6);

            var Roles_types = Enum.GetNames(typeof(Roles_types));

            for (int i = 0; i < Roles.Count; i++) { Roles[i].Role_title = Roles_types[i]; }

            return Roles;
        }

        public static List<Has_Role> Seeding_Has_Roles()
        {
            Has_Roles = new Faker<Has_Role>()
                .RuleFor(x => x.Employees_ID, f => f.PickRandom(Employees).ID)
                .RuleFor(x => x.Roles_ID, f => f.PickRandom(Roles).ID)
                .Generate(30);

            return Has_Roles;
        }

        public static List<Hospital> Seeding_Hospitals()
        {
            Hospitals = new Faker<Hospital>()
                .RuleFor(x => x.Hospital_title, f => f.Company.CompanyName())
                .RuleFor(x => x.Details, f => f.Company.CatchPhrase())
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .Generate(10);

            return Hospitals;
        }

        public static List<Department> Seeding_Departments()
        {
            Departments = new Faker<Department>()
                .RuleFor(x => x.Department_title, f => f.Commerce.Department())
                .RuleFor(x => x.Hospital_ID, f => f.PickRandom(Hospitals).ID)
                .Generate(20);

            return Departments;
        }

        public static List<In_Departments> Seeding_in_Departments()
        {
            In_Departments = new Faker<In_Departments>()
                .RuleFor(x => x.Time_from, f => f.Date.Past())
                .RuleFor(x => x.Time_to, f => f.Date.Future())
                .RuleFor(x => x.Active_is, f => f.Random.Bool())
                .RuleFor(x => x.Employees_ID, f => f.PickRandom(Employees).ID)
                .RuleFor(x => x.Departments_ID, f => f.PickRandom(Departments).ID)
                .Generate(100);

            return In_Departments;
        }

        public static List<Shedules> Seeding_Shedules()
        {
            Shedules = new Faker<Shedules>()
                .RuleFor(x => x.Time_start, f => f.Date.Past())
                .RuleFor(x => x.Time_end, f => f.Date.Future())
                .RuleFor(x => x.In_Departments_ID, f => f.PickRandom(In_Departments).ID)
                .Generate(100);

            return Shedules;
        }

        public static List<Patients> Seeding_Patients()
        {
            Patients = new Faker<Patients>()
                .RuleFor(x => x.First_title, f => f.Person.FirstName)
                .RuleFor(x => x.Last_title, f => f.Person.LastName)
                .RuleFor(x => x.Email, (f, o) => f.Internet.Email(o.First_title, o.Last_title))
                .RuleFor(x => x.Mobile, f => f.Phone.Locale)
                .Generate(200);

            return Patients;
        }

        public static List<Patients_Case> Seeding_Patients_Cases()
        {
            Patients_Cases = new Faker<Patients_Case>()
                .RuleFor(x => x.Start_time, f => f.Date.Past())
                .RuleFor(x => x.End_time, f => f.Date.Future())
                .RuleFor(x => x.Total_Cost, f => f.Finance.Amount())
                .RuleFor(x => x.Patients_ID, f => f.PickRandom(Patients).ID)
                .Generate(150);

            return Patients_Cases;
        }

        public static List<Appointment_Status> Seeding_Appointment_Statuses()
        {
            Appointment_Statuses = new Faker<Appointment_Status>().Generate(5);

            var Statuses = Enum.GetNames(typeof(Statuses_types));

            for (int i = 0; i < Appointment_Statuses.Count; i++) { Appointment_Statuses[i].Status_title = Statuses[i]; }

            return Appointment_Statuses;
        }

        public static List<Appointment> Seeding_Appointments()
        {
            Appointments = new Faker<Appointment>()
                .RuleFor(x => x.Appointment_Start_time, f => f.Date.Past())
                .RuleFor(x => x.Appointment_End_time, f => f.Date.Future())
                .RuleFor(x => x.In_Departments_ID, f => f.PickRandom(In_Departments).ID)
                .RuleFor(x => x.Patient_Cases_ID, f => f.PickRandom(Patients_Cases).ID)
                .Generate(100);

            return Appointments;
        }

        public static List<Status_Histories> Seeding_Status_Histories()
        {
            Status_Histories = new Faker<Status_Histories>()
                .RuleFor(x => x.Details, f => f.Commerce.Product())
                .RuleFor(x => x.Appointment_Status_ID, f => f.PickRandom(Appointment_Statuses).ID)
                .RuleFor(x => x.Appointment_ID, f => f.PickRandom(Appointments).ID)
                .Generate(100);

            return Status_Histories;
        }

        public static List<Document_types> Seeding_Documents_types()
        {
            Documents_types = new Faker<Document_types>().Generate(5);

            var Documents = Enum.GetNames(typeof(Documents_types_Enum));

            for (int i = 0; i < Documents_types.Count; i++) { Documents_types[i].Types_title = Documents[i]; }

            return Documents_types;
        }

        public static List<Documents> Seeding_Documents()
        {
            Documents = new Faker<Documents>()
                .RuleFor(x => x.Documents_title, f => f.Commerce.Product())
                .RuleFor(x => x.Documents_details, f => f.Commerce.Color())
                .RuleFor(x => x.Documents_link, f => f.Internet.Url())
                .RuleFor(x => x.Patients_ID, f => f.PickRandom(Patients).ID)
                .RuleFor(x => x.In_Department_ID, f => f.PickRandom(In_Departments).ID)
                .RuleFor(x => x.Appointment_Status_ID, f => f.PickRandom(Appointments).ID)
                .RuleFor(x => x.Documents_types_ID, f => f.PickRandom(Documents_types).ID)
                .RuleFor(x => x.Patient_Case_ID, f => f.PickRandom(Patients_Cases).ID)
                .Generate(50);

            return Documents;
        }

        #endregion
    }
}
