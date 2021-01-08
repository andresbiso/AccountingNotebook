import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountingService {
  private apiUrl: string;
  private resourceName: string;

  constructor(private httpClient: HttpClient) {
    this.apiUrl = environment.apiUrl;
    this.resourceName = "transactions";
  }

  public getTransactionsHistory() {
    return this.httpClient.get(`${this.apiUrl}${this.resourceName}`);
  }

}
