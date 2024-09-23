using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş bırakamazsınız.");
            //RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanını boş bırakamazsınız.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş bırakamazsınız.");
            //RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş bırakamazsınız.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız.");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız.");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız.");
        }
    }
}
