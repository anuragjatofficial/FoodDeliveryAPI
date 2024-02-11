import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  constructor() { }

  url = `https://localhost:7146`;

  http:HttpClient = inject(HttpClient);

  getAllRestaurants(page:number = 1,pagesize:number = 10){
    const token = localStorage.getItem('token');
    return this.http.get(`${this.url}/Restaurant?page=${page}&pagesize=${pagesize}&orderBy=restaurantname&sortOrder=asc`,{headers:{ 'Authorization': `Bearer ${token}` }});
  }

}
