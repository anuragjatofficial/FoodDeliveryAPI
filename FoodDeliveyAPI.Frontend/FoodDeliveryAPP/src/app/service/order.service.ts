import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Order } from '../models/Order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  url = `https://ominous-journey-r965xjqqvxqhp454-5275.app.github.dev`;
  httpClient: HttpClient = inject(HttpClient);

  private authToken: string = '';
  private id: string = '';

  constructor() {
    var detailsString = localStorage.getItem('token');
    if (detailsString) {
      var user = JSON.parse(detailsString);
      this.authToken = user?.authToken ?? '';
      this.id = user?.userId ?? '';
    }
  }

  placeOrder(): Observable<Order> {
    return this.httpClient.post<Order>(
      `${this.url}/order/customer/${this.id}`,
      {},
      { headers: { Authorization: `Bearer ${this.authToken}` } }
    );
  }

  getAllOrders(): Observable<any> {
    return this.httpClient.get<any>(
      `${this.url}/Customer/${this.id}/orders/all`,
      { headers: { Authorization: `Bearer ${this.authToken}` } }
    );
  }

  getActiveOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(
      `${this.url}/Customer/${this.id}/orders/active`,
      { headers: { Authorization: `Bearer ${this.authToken}` } }
    );
  }
}
