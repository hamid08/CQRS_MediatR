using CQRS_MediatR.CQRS.InputModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Queries
{
    public class API1Validation : AbstractValidator<APIWithCacheQueryInputModel>
    {
        public API1Validation()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty().WithMessage("NameCantBeEmpty")
            //    .Length(10, 15).WithMessage("LengthOutOfRange")
            //    .Must(ValidateName).WithMessage("CustomError");
        }

        private bool ValidateName(string _name)
        {
            if (_name == "Sajjad")
                return false;
            return true;
        }
    }
}
