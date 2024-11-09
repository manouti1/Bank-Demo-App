using BankApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace BankApp.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public async Task<IActionResult> Create(OpenAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = _httpClientFactory.CreateClient("BankApiClient");
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("accounts", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { customerId = model.CustomerId });
            }

            ModelState.AddModelError("", "Error creating account");
            return View(model);
        }

        // GET: Account/Details/{customerId}
        [HttpGet("Account/Details{customerId}")]
        public async Task<IActionResult> Details(int customerId)
        {
            var client = _httpClientFactory.CreateClient("BankApiClient");
            var response = await client.GetAsync($"customers/{customerId}/accounts");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var responseData = await response.Content.ReadAsStringAsync();
            var accountDetails = JsonSerializer.Deserialize<AccountViewModel>(responseData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(accountDetails);
        }
    }

}
