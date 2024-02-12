import { Component, OnInit, inject } from '@angular/core';
import { ItemComponent } from '../item/item.component';
import { ActivatedRoute } from '@angular/router';
import { RestaurantService } from '../../service/restaurant.service';
import { Restaurant } from '../../models/Restaurant';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-restaurant-items-page',
  standalone: true,
  imports: [ItemComponent,HeaderComponent,CommonModule],
  templateUrl: './restaurant-items-page.component.html',
  template:``,
  styleUrl: './restaurant-items-page.component.css'
})
export class RestaurantItemsPageComponent implements OnInit{
  route:ActivatedRoute = inject(ActivatedRoute);
  restaurant?:Restaurant;
  restaurantService:RestaurantService = inject(RestaurantService);
  id:string = '';

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    console.log(this.id);
    
    this.restaurantService.getRestaurantById(this.id).subscribe((data:any)=>{
      this.restaurant = data;
    });
    
  }
}
