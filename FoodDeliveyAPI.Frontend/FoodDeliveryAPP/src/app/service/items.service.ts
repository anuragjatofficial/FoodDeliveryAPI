import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Item } from '../models/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor() { }

  url = `https://localhost:7146`;

  http:HttpClient = inject(HttpClient);

  getItems() {
    return this.http.get<Item[]>(`${this.url}/item`);
  }

}