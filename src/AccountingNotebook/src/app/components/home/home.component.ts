import { Component, OnInit } from '@angular/core';
import { NgbAccordionConfig } from '@ng-bootstrap/ng-bootstrap';
import { TransactionTypeEnum } from 'src/app/enums/transaction-type.enum';
import { Transaction } from '../../models/transaction';
import { AccountingService } from '../../services/accounting.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [NgbAccordionConfig]
})
export class HomeComponent implements OnInit {
  public isMenuCollapsed: boolean;
  public transactions: Transaction[];
  public openedId: string;
  public transactionType = TransactionTypeEnum;

  constructor(
    private accountingService: AccountingService,
    public accordionConfig: NgbAccordionConfig,
  ) {
    this.isMenuCollapsed = false;
    this.transactions = new Array<Transaction>();
    this.openedId = '';
    accordionConfig.closeOthers = true;
  }

  ngOnInit(): void {
    this.getTransactionsHistory();
  }

  public getTransactionsHistory() {
    this.accountingService.getTransactionsHistory().subscribe((data: any)=>{
      console.log(data);
      this.transactions = data;
    }) 
  }

  public changePanel(transactionId: string) {
    this.openedId = this.openedId !== transactionId ? transactionId : '';
  }

}
