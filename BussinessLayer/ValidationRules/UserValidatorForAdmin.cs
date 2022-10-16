using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class UserValidatorForAdmin:AbstractValidator<User>
    {
        public UserValidatorForAdmin()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Firma Adı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Kullanıcı Adı maksimum 20 karakter olabilir.");
            RuleFor(x => x.CompanyName).MinimumLength(3).WithMessage("Firma Adı en az 3 karakter olamalıdır");
            RuleFor(x => x.CompanyName).MaximumLength(60).WithMessage("Firma Adı en fazla 60 karakter olabilir.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");
        }
       
    }
}
