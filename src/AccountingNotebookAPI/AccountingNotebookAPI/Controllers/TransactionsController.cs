using System;
using System.Collections.Generic;
using AccountingNotebookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using AccountingNotebookAPI.Enums;
using System.Threading;

namespace AccountingNotebookAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/transactions")]
    [SwaggerTag("transaction operations. There are 2 types of transaction: credit and debit. Credit transaction leads to the account balance growth. Debit transaction leads to the account balance reduction.")]
    public class TransactionsController : ControllerBase
    {
        private static bool isLocked = false;
        private static readonly object lockObj = new object();
        private bool lockTaken = false;
        private readonly TimeSpan timeout = TimeSpan.FromMilliseconds(500);

        private readonly IMemoryCache memoryCache;

        public TransactionsController(
            IMemoryCache memoryCache
        )
        {
            this.memoryCache = memoryCache;
        }

        [HttpGet("")]
        [SwaggerOperation(
           Summary = "Fetches Transaction History"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "successful operation", typeof(IEnumerable<Transaction>))]
        public IActionResult GetTransactions()
        {
            if (isLocked)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var transactions = memoryCache.GetOrCreate("Transactions", entry =>
            {
                return new List<Transaction>();
            });
            return Ok(transactions);
        }

        [HttpGet("{transactionId}")]
        [SwaggerOperation(
            Summary = "Find transaction by ID",
            Description = "Returns a single transaction object"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "successful operation", typeof(Transaction))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "invalid ID supplied")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "transaction not found")]
        public IActionResult GetTransactionById(
            [FromRoute, SwaggerParameter("ID of transaction to return", Description = "ID of transaction to return", Required = true)] string transactionId
        )
        {
            if (isLocked)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Guid transactionIdGuid;
            if (!Guid.TryParse(transactionId, out transactionIdGuid))
            {
                return BadRequest("invalid ID supplied");
            }
            var transactions = memoryCache.GetOrCreate("Transactions", entry =>
            {
                return new List<Transaction>();
            });
            var transaction = transactions.Where(x => string.Equals(x.Id, transactionId)).SingleOrDefault();
            if (transaction == null)
            {
                return NotFound("transaction not found");
            }


            return Ok(transaction);
        }
        
        [HttpPost]
        [SwaggerOperation(
            Summary = "Commit new transaction to the account"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "transaction stored", typeof(Transaction))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "invalid input")]
        public IActionResult CommitTransaction(
            [FromBody, SwaggerParameter("Transaction Object", Description = "Transaction Object", Required = true)] TransactionBody body
        )
        {
            try
            {
                Monitor.TryEnter(lockObj, timeout, ref lockTaken);
                if (lockTaken)
                {
                    isLocked = true;
                    if (!Enum.IsDefined(typeof(TransactionTypeEnum), body.Type) || body.Amount <= 0)
                    {
                        return BadRequest("invalid input");
                    }
                    var balance = memoryCache.GetOrCreate("Balance", entry =>
                    {
                        return 0m;
                    });
                    var transactions = memoryCache.GetOrCreate("Transactions", entry =>
                    {
                        return new List<Transaction>();
                    });

                    if (body.Type == TransactionTypeEnum.Credit)
                    {
                        balance += body.Amount;
                    }
                    else
                    {
                        if (balance >= body.Amount)
                        {
                            balance -= body.Amount;
                        }
                        else
                        {
                            return BadRequest("invalid input");
                        }
                       
                    }

                    var newTransaction = new Transaction()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = body.Type,
                        Amount = body.Amount,
                        EffectiveDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    };
                    transactions.Add(newTransaction);
                    memoryCache.Set("Transactions", transactions);
                    memoryCache.Set("Balance", balance);

                    return Ok(newTransaction);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            finally
            {
                if (lockTaken)
                {
                    isLocked = false;
                    Monitor.Exit(lockObj);
                }
            }                
        }
    }
}
