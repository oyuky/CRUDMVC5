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
                .NotEmpty().WithMessage("El nombre es requerido.")
                .Length(1,50).WithMessage("Máximo 50 caracteres.");
            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("El apellido paterno es requerido.")
                .Length(1, 60).WithMessage("Máximo 60 caracteres.");
            RuleFor(x => x.ApellidoMaterno)
                .NotEmpty().WithMessage("El apellido materno es requerido.")
                .Length(1, 60).WithMessage("Máximo 60 caracteres.");
            RuleFor(x => x.CURP)
                .NotEmpty().WithMessage("La CURP es requerida.")
                .Length(18).WithMessage("La CURP debe contener 18 caracteres.");
            RuleFor(x => x.CURP.CompareTo("")!=0 ? x.CURP.ToString() : "")
                .Matches(@"/^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9][12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/") // dot was here
                .When(x => x.CURP != null).WithMessage("Formato de CURP incorrecto.");
        }
    }
}