﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_Fluent
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifreyi Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Alanını Boş Geçemezsiniz");
            RuleFor(x=>x.WriterAbout).Must(AboutContainsA).WithMessage("Hakkımda Alanı A harfi içermeli");
        }

        private bool AboutContainsA(string about)
        {
            return about.Contains("a") || about.Contains("A");
        }
    }
}
