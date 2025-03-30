using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_Fluent
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Geçilemez");          
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Bir Mail Adresi Giriniz");
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçerli Bir Mail Adresi Giriniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En Fazla 100 Karakter Girişi Yapınız");
        }

    }
}
