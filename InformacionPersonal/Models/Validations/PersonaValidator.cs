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
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Requerido.")
                .Length(1,50).WithMessage("Máximo 50 caracteres.");
            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("Requerido.")
                .Length(1, 60).WithMessage("Máximo 60 caracteres.");
            RuleFor(x => x.ApellidoMaterno)
                .NotEmpty().WithMessage("Requerido.")
                .Length(1, 60).WithMessage("Máximo 60 caracteres.");
            RuleFor(x => x.CURP)
                .NotEmpty().WithMessage("Requerida.")
                .Length(18).WithMessage("Se requieren 18 caracteres.")
                .Matches(@"^[a-zA-Z]{4}\d{6}[a-zA-Z]{6}\d{2}$").WithMessage("Formato de incorrecto.");
        }
    }
}