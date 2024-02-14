import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Item } from '../models/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  private authToken:string;
  private id:string;
  constructor() { 
    const token = JSON.parse(localStorage.getItem('token')||'');
    this.authToken = token?.authToken;
    this.id= token?.userId;
  }

  url = `https://localhost:7146`;

  private http:HttpClient = inject(HttpClient);

  getItems() {
    return this.http.get<Item[]>(`${this.url}/item`);
  }

  addToCart(item:Item){
    return this.http.post(`${this.url}/Customer/${this.id}/cart/add`,item,{ headers:{'Authorization':`Bearer ${this.authToken}`} });
  }

}