using FluentValidation;
using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<Abouts>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Adınız En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).WithMessage("Soydınız En Az 2 Karakter Olmalıdır");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifreniz En Az 6 Karakter Olmalıdır");
            RuleFor(x => x.Phone).NotEmpty().MinimumLength(10).MaximumLength(11).WithMessage("Geçersiz Telefon Numarası");
            //RuleFor(x => x.Dateofbirth).Must(isBirth).WithMessage("Geçersiz Doğum Tarihi");
            //RuleFor(x => x.Dateofbirth). MaximumLength(10).WithMessage("Geçersiz Doğum Tarihi");
            //RuleFor(x => x.Dateofbirth.ToString()).MinimumLength(8).WithMessage("Geçersiz Doğum Tarihi");
            RuleFor(x => x.Dateofbirth).NotEmpty().WithMessage("Doğum Tarihi Boş Bırakılamaz");
            RuleFor(x => x.Mail).Must(isMail).WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(x => x.Job).NotEmpty().WithMessage("Meslek Alanı Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz");

        }
        private bool isMail(string mail)
        {
            if (!String.IsNullOrEmpty(mail))
            {
                return mail.Contains("@");
            }
            return false;
        }
        //private DateTime isBirth(DateTime birth)
        //{
        //    if (birth.Date.ToShortDateString().Length<8 || birth.Date.ToShortDateString().Length > 10)
        //    {
        //        return birth;
        //    }
        //    return birth;
        //}
    }
}