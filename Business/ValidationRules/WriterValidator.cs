using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz.");
            RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifre en az bir büyük harf içermelidir.");
            RuleFor(p => p.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifre en az bir küçük harf içermelidir.");
            RuleFor(p => p.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermelidir.");
        }
    }
}
