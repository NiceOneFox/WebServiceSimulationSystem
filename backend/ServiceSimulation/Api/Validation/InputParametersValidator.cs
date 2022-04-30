using FluentValidation;
using Bll.Domain.Models;
using Api.enums;

namespace Api.Validation
{
    public class InputParametersValidator : AbstractValidator<InputParameters>
    {
        public InputParametersValidator()
        {
            RuleFor(p => p.NumberOfSources).NotEmpty().InclusiveBetween(1, 100);
            RuleFor(p => p.NumberOfDevices).NotEmpty().InclusiveBetween(1, 100);
            RuleFor(p => p.AmountOfRequests).NotEmpty().InclusiveBetween(1, 5000);
            RuleFor(p => p.BufferSize).NotEmpty().InclusiveBetween(1, 100);
            RuleFor(p => p.LambdaForDevice).NotEmpty().ExclusiveBetween(0, 10000);
            RuleFor(p => p.NumberOfSources).NotEmpty().ExclusiveBetween(0, 10000);
            RuleFor(p => p.ModelingTime).NotEmpty().ExclusiveBetween(0, 10000);
            RuleFor(p => p.BufferType).IsInEnum();
        }
    }
}