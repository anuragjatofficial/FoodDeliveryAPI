import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Item } from '../models/Item';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
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

  url = `https://localhost:7146`;

  private http: HttpClient = inject(HttpClient);

  getItems() {
    return this.http.get<Item[]>(`${this.url}/item`);
  }

  addToCart(item: Item) {
    return this.http.post(`${this.url}/Customer/${this.id}/cart/add`, item, {
      headers: { Authorization: `Bearer ${this.authToken}` },
    });
  }

  getCartItems(): Observable<Item[]> {
    return this.http.get<Item[]>(`${this.url}/customer/${this.id}/cart`, {
      headers: { Authorization: `Bearer ${this.authToken}` },
    });
  }

  removeFromCart(itemId: string): Observable<Item[]> {
    return this.http.delete<Item[]>(
      `${this.url}/Customer/${this.id}/cart/${itemId}`,
      {
        headers: { Authorization: `Bearer ${this.authToken}` },
      }
    );
  }

  checkIfAlreadyInCart(item: Item): Observable<boolean> {
    return this.getCartItems().pipe(
      map((items: Item[]) => items.some((it) => it.itemId == item.itemId))
    );
  }
}
