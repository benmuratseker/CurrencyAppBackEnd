using CurrencyService;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IExchangeService exchangeService;
        public CurrencyController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService ?? throw new System.InvalidOperationException(nameof(exchangeService));
        }
        [HttpGet]
        public JsonResult Get()
        {
            return  new JsonResult(exchangeService.GetCurrency());
        }
    }
}
