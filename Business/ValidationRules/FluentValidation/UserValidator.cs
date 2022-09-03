using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress().WithMessage("Lütfen geçerli bir e posta adresi giriniz.");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(3).WithMessage("En az 4 karakter olmalıdır.");
            RuleFor(u => u.Password).Must(Contain).WithMessage("-.,*/&%+^ karakterlerini içermelidir.");

        }

        private bool Contain(string arg)
        {
            return arg.Contains("-.,*/&%+^");
        }
    }
}
