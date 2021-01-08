import { DecimalPipe } from "@angular/common";
import { TransactionTypeEnum } from "../enums/transaction-type.enum";

export class Transaction {
    public id: string;
    public type: TransactionTypeEnum;
    public amount: number;
    public effectiveDate: string;

    constructor() {
        this.id = '';
        this.type = TransactionTypeEnum.Credit;
        this.amount = 0;
        this.effectiveDate = Date.now().toString();
    }
}