import { Component, OnInit, inject } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { RestaurantService } from '../../service/restaurant.service';
import { RestaurantComponent } from '../restaurant/restaurant.component';
import { Restaurant } from '../../models/Restaurant';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from '../pagination/pagination.component';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-restaurant-page',
  standalone: true,
  imports: [HeaderComponent,RestaurantComponent,CommonModule,PaginationComponent],
  templateUrl: './restaurant-page.component.html',
  styleUrl: './restaurant-page.component.css'
})
export class RestaurantPageComponent implements OnInit{
  restaurantService : RestaurantService  = inject(RestaurantService);
  restaurants:Restaurant[] = [];
  totalPages = 0;
  constructor(){
    // this.getRestaurants();
  }
  
  ngOnInit(): void {
    this.getRestaurants();
  }


  getRestaurants(){
    this.restaurantService.getAllRestaurants().subscribe((response:any)=>{
      const headers: HttpHeaders = response.headers;
      this.totalPages =  Math.ceil(Number(headers.get('Records'))/10); 
      this.restaurants = response.body;
    });
  }

  getRestaurantByPage(page:number){
    this.restaurantService.getAllRestaurants(page).subscribe((response:any)=>{
      this.restaurants = response.body;
    })
  }

}
