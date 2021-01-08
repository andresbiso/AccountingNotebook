using AccountingNotebookAPI.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace AccountingNotebookAPI.Models
{
    [SwaggerSchema(Required = new[] { "Type", "Amount" })]
    public class TransactionBody
    {
        [SwaggerSchema("Enum: [credit, debit]")]
        public TransactionTypeEnum Type { get; set; }

        [SwaggerSchema("Transaction numeric value. Incrementing or decrementing the account balance, based on the transaction type.")]
        public decimal Amount { get; set; }
    }
}
