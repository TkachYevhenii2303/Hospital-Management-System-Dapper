using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Dapper_Data_Access_Layer.Entities;

namespace Dapper_Data_Access_Layer.Bogus_Generator
{
    public class Seeding_Bogus
    {
        public static List<Employees> Employees { get; set; } = new();
        public static List<Roles> Roles { get; set; } = new();
        public static List<Has_Role> Has_Roles { get; set; } = new();

        public static List<Employees> Seeding_Employees()
        {
            Employees = new Faker<Employees>(locale: "uk")
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

            var Roles_types = Enum.GetValues(typeof(Roles))
                .Cast<string>().Select(x => x.ToString()).ToArray();

            for (int i = 0; i < Roles.Count; i++) { Roles[i].Role_title = Roles_types[i]; }

            return Roles;
        }

        public static List<Has_Role> Seeding_Has_Roles()
        {
            Has_Roles = new Faker<Has_Role>()
                .RuleFor(x => x.Employees_ID, f => f.PickRandom(Employees).ID)
                .RuleFor(x => x.Role_ID, f => f.PickRandom(Roles).ID)
                .Generate(30);

            return Has_Roles;
        }
    }
}
