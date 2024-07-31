using Microsoft.AspNetCore.Mvc;
using TransactionApi.Models;
using TransactionApi.Services;

namespace TransactionApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TransactionsController : ControllerBase
  {
    private readonly ITransactionService _service;

    public TransactionsController(ITransactionService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
      var transactions = await _service.GetAllTransactionsAsync();
      return Ok(transactions);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateTransactionStatus(int id, [FromBody] string newStatus)
    {
      var transaction = await _service.UpdateTransactionStatusAsync(id, newStatus);
      if (transaction == null)
      {
        return NotFound();
      }
      return Ok(transaction);
    }

  }



}
