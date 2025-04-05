using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_Fluent
{
    public class WriterLoginValidator : AbstractValidator<Writer>
    {
        public WriterLoginValidator()
        {
            RuleFor(x=>x.WriterMail).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x=>x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
