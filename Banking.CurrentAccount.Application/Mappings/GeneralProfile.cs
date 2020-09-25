using AutoMapper;
using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Banking.CurrentAccount.Application.Wrappers;
using Banking.CurrentAccount.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CurrentAccount.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Transaction, GetCurrentAccountTransactionHistoryViewModel>()
                .ForMember(src => src.TransactionId, dest => dest.MapFrom(x => x.Id))
                .ForMember(src => src.AccountId, dest => dest.MapFrom(x => x.AccountId))
                .ForMember(src => src.AccountName, dest => dest.MapFrom(x => x.Account.AccountName))
                .ReverseMap();
            CreateMap<GetCurrentAccountTransactionHistoryQuery, GetCurrentAccountTransactionHistoryParameter>()
                .ForMember(src => src.AccountId, dest => dest.MapFrom(x => x.AccountId))
                .ForMember(src => src.CustomerId, dest => dest.MapFrom(x => x.CustomerId));

            CreateMap<PagedResponse<IReadOnlyList<Transaction>>, PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>>().ReverseMap();
        }
    }
}
