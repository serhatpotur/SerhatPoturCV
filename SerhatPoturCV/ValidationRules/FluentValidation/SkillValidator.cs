using FluentValidation;
using SerhatPoturCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerhatPoturCV.ValidationRules.FluentValidation
{
    public class SkillValidator : AbstractValidator<Skills>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek Adı Boş Bırakılamaz");
            //RuleFor(x => x.SkillValue).NotEmpty().WithMessage("Yetenek Değeri Boş Bırakılamaz");
            //RuleFor(x => x.SkillValue).MinimumLength(1).WithMessage("Yetenek Değeri 0-100 Arası Değer Alabilir");
            //RuleFor(x => x.SkillValue).MaximumLength(3).WithMessage("Yetenek Değeri 0-100 Arası Değer Alabilir");
            //RuleFor(x => x.SkillValue).Must(Convert.ToString(skillValueBetween)).WithMessage("Yetenek Değeri 0-100 Arası Değer Alabilir");
            RuleFor(x => Convert.ToInt32(x.SkillValue)).LessThan(101).WithMessage("Yetenek Değeri 0-100 Arası Değer Alabilir");
            RuleFor(x => Convert.ToInt32(x.SkillValue)).GreaterThan(0).WithMessage("Yetenek Değeri 0-100 Arası Değer Alabilir");

        }
        //private bool skillValueBetween(string skillvalue)
        //{
        //    if ( skillvalue >= 0 && skillvalue <= 100)
        //    {
        //        return true;
        //    }
        //    return false;

        //}
    }
}