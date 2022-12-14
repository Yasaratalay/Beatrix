using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş bırakılamaz.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("En fazla 150 karakter girebilirsiniz.");
            RuleFor(x => x.BlogTitle).MinimumLength(10).WithMessage("En az 10 karakter giriniz.");

        }
    }
}
