using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici mail adresi boş bırakılamaz.");
            //RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçersiz mail adresi.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçersiz mail adresi.");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresi boş bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş bırakılamaz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız.");
        }
    }
}
