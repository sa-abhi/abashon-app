using AbashonWeb.Service.Features.ClientFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.ClientIdentificatinNumber).NotEmpty();
            RuleFor(x => x.ClientFirstName).NotEmpty().Length(2, 30);
            RuleFor(x => x.ClientLastName).NotEmpty().Length(2, 30);
            RuleFor(x => x.ContactNo).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();           
        }
    }
}
