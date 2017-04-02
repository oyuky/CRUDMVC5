using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformacionPersonal.Models.Validations
{
    public class PersonaValidator: AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().Length(50).WithMessage("El nombre es requerido.");
            //RuleFor(x => x.Nombre).NotEmpty().Length(20, 250).WithMessage("Must be atleast 20 characters"); ;

        }
    }
}