import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TopLoaderComponent } from './components/loaders/top-loader/top-loader.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TopLoaderComponent],
  template: `
    <router-outlet></router-outlet>
    <app-top-loader></app-top-loader>
  `,
})
export class AppComponent {
  title = 'FoodDeliveryAPP';
}
