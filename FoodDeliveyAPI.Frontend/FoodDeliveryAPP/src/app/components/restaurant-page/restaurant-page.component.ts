import { Component, inject } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { RestaurantService } from '../../service/restaurant.service';
import { RestaurantComponent } from '../restaurant/restaurant.component';
import { Restaurant } from '../../models/Restaurant';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-restaurant-page',
  standalone: true,
  imports: [HeaderComponent,RestaurantComponent,CommonModule],
  templateUrl: './restaurant-page.component.html',
  styleUrl: './restaurant-page.component.css'
})
export class RestaurantPageComponent{
  restaurantService : RestaurantService  = inject(RestaurantService);
  restaurants:Restaurant[] = [];
  constructor(){
    this.getRestaurants();
  }
  
  getRestaurants(){
    this.restaurantService.getAllRestaurants().subscribe((res:any)=>{
      this.restaurants = res;
    });
  }
}
