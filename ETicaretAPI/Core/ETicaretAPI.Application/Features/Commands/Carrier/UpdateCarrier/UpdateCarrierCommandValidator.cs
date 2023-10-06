using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandValidator : AbstractValidator<UpdateCarrierCommandRequest>
    {
        public UpdateCarrierCommandValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CarrierName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(75).WithMessage("{PropertyName} can not be longer than 200 characters");
            RuleFor(x => x.CarrierPlusDesiCost).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
