using B3.Cdb.Domain.Interface;
using B3.Cdb.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace B3.Cdb.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class InvestController : ControllerBase
{
    private readonly ILogger<InvestController> logger;
    private readonly IInvestService investService;

    public InvestController(ILogger<InvestController> logger, IInvestService investService)
    {
        this.logger = logger;
        this.investService = investService;
    }

    [HttpPost]
    public async Task<Position> CalculateCdb([FromBody] Operation request)
    {
        return await investService.CalculateCdbPositionAsync(request);
    }
}
