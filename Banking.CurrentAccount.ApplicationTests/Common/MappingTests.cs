using AutoMapper;
using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Banking.CurrentAccount.Application.Mappings;
using Banking.CurrentAccount.Domain.Common;
using NUnit.Framework;
using System;

namespace Banking.CurrentAccount.ApplicationTests.Common
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Transaction), typeof(GetCurrentAccountTransactionHistoryViewModel))]
        [TestCase(typeof(GetCurrentAccountTransactionHistoryQuery), typeof(GetCurrentAccountTransactionHistoryParameter))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
