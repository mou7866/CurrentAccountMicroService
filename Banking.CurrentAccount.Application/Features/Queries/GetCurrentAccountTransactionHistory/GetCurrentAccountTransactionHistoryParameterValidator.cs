
using AutoMapper;
using Banking.CurrentAccount.Application.Interfaces.Repositories;
using Banking.CurrentAccount.Application.Parameters;
using Banking.CurrentAccount.Application.Wrappers;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory
{
    public class GetCurrentAccountTransactionHistoryParameterValidator : AbstractValidator<GetCurrentAccountTransactionHistoryQuery>
    {
        public GetCurrentAccountTransactionHistoryParameterValidator()
        {
            RuleFor(x => x.AccountId)
                .NotNull()
                .NotEmpty().WithMessage("AccountId is required.");

            RuleFor(x => x.AccountId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("AccountId must be greater than or equal to 1.");

            RuleFor(x => x.CustomerId)
                .NotNull()
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.CustomerId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("CustomerId must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
