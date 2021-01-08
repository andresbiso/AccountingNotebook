import { TransactionTypeEnum } from "../enums/transaction-type.enum";

export interface ITransactionBody {
    type: TransactionTypeEnum;
    amount: number;
}