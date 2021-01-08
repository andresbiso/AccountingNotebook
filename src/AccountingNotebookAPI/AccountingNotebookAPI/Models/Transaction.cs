﻿using AccountingNotebookAPI.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace AccountingNotebookAPI.Models
{
    [SwaggerSchema(Required = new[] { "Type", "Amount" })]
    public class Transaction
    {
        [SwaggerSchema("Unique transaction identifier, generated by the service, when the transaction is being stored.", Format = "uuid")]
        public string Id { get; set; }

        [SwaggerSchema("Enum: [credit, debit]")]
        public TransactionTypeEnum Type { get; set; }

        [SwaggerSchema("Transaction numeric value. Incrementing or decrementing the account balance, based on the transaction type.")]
        public decimal Amount { get; set; }

        [SwaggerSchema("Effective date-time, generated by the service, when the transaction is being stored.", Format = "date")]
        public string EffectiveDate { get; set; }
    }
}