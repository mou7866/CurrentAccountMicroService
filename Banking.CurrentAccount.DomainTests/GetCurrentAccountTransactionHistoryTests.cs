using AutoMapper;
using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Banking.CurrentAccount.Application.Interfaces.Repositories;
using Banking.CurrentAccount.Application.Mappings;
using Banking.CurrentAccount.Application.Wrappers;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.DomainTests
{
    public class GetCurrentAccountTransactionHistoryTests
    {
        [Test]
        public async Task AccountIdCannotBeNull()
        {
            var validator = new GetCurrentAccountTransactionHistoryParameterValidator();
            GetCurrentAccountTransactionHistoryQuery command = new GetCurrentAccountTransactionHistoryQuery()
            {
                AccountId = 1,
                PageNumber = 1,
                PageSize = 5
            };

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Test]
        public async Task CustomerIdCannotBeNull()
        {
            var validator = new GetCurrentAccountTransactionHistoryParameterValidator();
            GetCurrentAccountTransactionHistoryQuery command = new GetCurrentAccountTransactionHistoryQuery()
            {
                CustomerId = 1,
                PageNumber = 1,
                PageSize = 5
            };

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Test]
        public async Task CustomerIdMustBeGreaterThanZero()
        {
            var validator = new GetCurrentAccountTransactionHistoryParameterValidator();
            GetCurrentAccountTransactionHistoryQuery command = new GetCurrentAccountTransactionHistoryQuery()
            {
                AccountId = 1,
                CustomerId = 0,
                PageNumber = 1,
                PageSize = 5
            };

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Test]
        public async Task AccountIdMustBeGreaterThanZero()
        {
            var validator = new GetCurrentAccountTransactionHistoryParameterValidator();
            GetCurrentAccountTransactionHistoryQuery command = new GetCurrentAccountTransactionHistoryQuery()
            {
                AccountId = 0,
                CustomerId = 1,
                PageNumber = 1,
                PageSize = 5
            };

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Test]
        public async Task ValidationPasses()
        {
            var validator = new GetCurrentAccountTransactionHistoryParameterValidator();
            GetCurrentAccountTransactionHistoryQuery command = new GetCurrentAccountTransactionHistoryQuery()
            {
                AccountId = 1,
                CustomerId = 1,
                PageNumber = 1,
                PageSize = 5
            };

            validator.Validate(command).IsValid.Should().BeTrue();
        }
    }
}