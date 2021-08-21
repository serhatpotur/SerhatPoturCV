using FluentValidation;
using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.ValidationRules.FluentValidation
{
    public class SocialMediaValidator:AbstractValidator<SocialMedias>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.MediaName).NotEmpty().WithMessage("Sosyal Medya İsmi Boş Bırakılamaz");
            RuleFor(x => x.MediaClass).NotEmpty().WithMessage("Sosyal Medya Icon Classı Boş Bırakılamaz");
            RuleFor(x => x.MediaLink).NotEmpty().WithMessage("Sosyal Medya Linki Boş Bırakılamaz");
        }
    }
}