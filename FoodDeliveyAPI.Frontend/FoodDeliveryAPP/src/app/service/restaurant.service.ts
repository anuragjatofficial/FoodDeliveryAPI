import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  
  
  http:HttpClient = inject(HttpClient);
  token:string = '';
  url = `https://localhost:7146`;


  constructor() { 
    this.token  = localStorage.getItem('token')|| '';
  }

  getAllRestaurants(page:number = 1,pagesize:number = 10){
    return this
            .http
            .get(`${this.url}/Restaurant?page=${page}&pagesize=${pagesize}&orderBy=restaurantname&sortOrder=asc`,{ observe:'response',headers:{ 'Authorization': `Bearer ${this.token}` }});
  }

  getRestaurantById(id: string) {
    return this
            .http
            .get(`${this.url}/restaurant/${id}`,{observe:'response',headers:{'Authorization': `Bearer ${this.token}`}});
  }

}