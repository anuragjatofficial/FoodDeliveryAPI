import { Component, Input } from '@angular/core';
import { Restaurant } from '../../models/Restaurant';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-restaurant',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './restaurant.component.html',
  styleUrl: './restaurant.component.css',
})
export class RestaurantComponent {
  @Input() restaurant!: Restaurant;
}
