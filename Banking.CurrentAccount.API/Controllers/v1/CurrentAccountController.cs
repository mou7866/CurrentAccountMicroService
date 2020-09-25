using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.CurrentAccount.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CurrentAccountController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCurrentAccountTransactionHistoryParameter filter)
        {
            return Ok(await Mediator.Send(new GetCurrentAccountTransactionHistoryQuery() { CustomerId = filter.CustomerId, AccountId = filter.AccountId,
                                                                                           PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }
    }
}
