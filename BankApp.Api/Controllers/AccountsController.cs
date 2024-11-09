using BankApp.Application.Command;
using BankApp.Application.Handlers;
using BankApp.Application.Query;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly OpenAccountHandler _openAccountHandler;
        private readonly GetCustomerAccountDetailsHandler _getCustomerAccountDetailsHandler;

        public AccountsController(OpenAccountHandler openAccountHandler, GetCustomerAccountDetailsHandler getCustomerAccountDetailsHandler)
        {
            _openAccountHandler = openAccountHandler;
            _getCustomerAccountDetailsHandler = getCustomerAccountDetailsHandler;
        }

        [HttpPost]
        public async Task<IActionResult> OpenAccount([FromBody] OpenAccountCommand command)
        {
            var account = await _openAccountHandler.Handle(command);
            return CreatedAtAction(nameof(GetCustomerAccounts), new { customerId = account.CustomerId }, account);
        }

        [HttpGet("/api/customers/{customerId}/accounts")]
        public async Task<IActionResult> GetCustomerAccounts(int customerId)
        {
            var result = await _getCustomerAccountDetailsHandler.Handle(new GetCustomerAccountDetailsQuery { CustomerId = customerId });
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
