using FluentValidation;
using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.ValidationRules.FluentValidation
{
    public class CareerValidator:AbstractValidator<Careers>
    {
        public CareerValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Firma Adı Boş Bırakılamaz");
            RuleFor(x => x.StartTime).NotEmpty().WithMessage("Başlangıç Tarihi Boş Bırakılamaz");
            RuleFor(x => x.EndTime).NotEmpty().WithMessage("Bitiş Tarihi Boş Bırakılamaz");
            RuleFor(x => x.Position).NotEmpty().WithMessage("Pozisyon Alanı Boş Bırakılamaz");
        }
    }
}