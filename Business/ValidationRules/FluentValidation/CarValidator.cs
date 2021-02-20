using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.ModelYear).NotEmpty();
            RuleFor(x => x.DailyPrice).NotEmpty();
            RuleFor(x => x.DailyPrice).GreaterThan(0);
        }
    }
}
