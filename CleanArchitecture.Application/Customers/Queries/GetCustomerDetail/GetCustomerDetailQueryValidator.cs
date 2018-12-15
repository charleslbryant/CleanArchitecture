﻿using CleanArchitecture.Domain.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator(IReadStoreHandler redis)
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than zero");
        }
    }
}
