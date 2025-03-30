using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_Fluent
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x=>x.ContactUserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez").MinimumLength(3).WithMessage("Minimum 3 karakter giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez").
                MaximumLength(100).WithMessage("100 karakterden fazla giriş yazmayınız.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");

        }
    }
}
