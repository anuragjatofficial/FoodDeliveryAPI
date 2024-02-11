import { Component, Input } from '@angular/core';
import { Restaurant } from '../../models/Restaurant';

@Component({
  selector: 'app-restaurant',
  standalone: true,
  imports: [],
  templateUrl: './restaurant.component.html',
  styleUrl: './restaurant.component.css'
})
export class RestaurantComponent {
  @Input() restaurant!:Restaurant;
}
