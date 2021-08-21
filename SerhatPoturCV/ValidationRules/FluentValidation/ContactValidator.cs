using FluentValidation;
using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contacts>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Bırakılamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli Bir Mail Adresi Girin");
        }
    }
}