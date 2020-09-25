using AutoMapper;
using Banking.CurrentAccount.Application.Interfaces.Repositories;
using Banking.CurrentAccount.Application.Parameters;
using Banking.CurrentAccount.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory
{
    public class GetCurrentAccountTransactionHistoryQuery : IRequest<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? CustomerId { get; set; } = null;
        public int? AccountId { get; set; } = null;
    }
    public class GetCurrentAccountTransactionHistoryHandler : IRequestHandler<GetCurrentAccountTransactionHistoryQuery, PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>>
    {
        private readonly IAccountTransactionRepositoryAsync _customerAccountRepository;
        private readonly IMapper _mapper;
        public GetCurrentAccountTransactionHistoryHandler(IAccountTransactionRepositoryAsync customerAccountRepository, IMapper mapper)
        {
            _customerAccountRepository = customerAccountRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>> Handle(GetCurrentAccountTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetCurrentAccountTransactionHistoryParameter>(request);
            var customerAccounts = await _customerAccountRepository.GetPagedReponseAccountTransactionHistoryAsync(validFilter.CustomerId, validFilter.AccountId, validFilter.PageNumber, validFilter.PageSize);
            return _mapper.Map<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>>(customerAccounts);
        }
    }
}
