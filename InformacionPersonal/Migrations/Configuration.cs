namespace InformacionPersonal.Migrations
{
    using Models;
    using DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalContext context)
        {
            var personal = new List<Persona>
            {
                new Persona { Nombre = "Francisnco",   ApellidoPaterno = "Salazar", ApellidoMaterno="Aguirre", CURP="SAF1234551" },
                new Persona { Nombre = "Patricia",   ApellidoPaterno = "Molina", ApellidoMaterno="Garcia", CURP="PMG12345" },
                new Persona { Nombre = "Lorena",   ApellidoPaterno = "Aguilar", ApellidoMaterno="Ramirez", CURP="RAL12345" },
                new Persona { Nombre = "Jose",   ApellidoPaterno = "Tamayo", ApellidoMaterno="Perez", CURP="TPJ123455" },
                new Persona { Nombre = "David",   ApellidoPaterno = "Hernandez", ApellidoMaterno="Perez", CURP="HPD123455" }
            };
            personal.ForEach(s => context.Personal.AddOrUpdate(p => p.CURP, s));
            context.SaveChanges();

        }
    }
}
