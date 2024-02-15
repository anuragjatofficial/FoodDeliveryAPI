import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { RestaurantPageComponent } from './components/restaurant-page/restaurant-page.component';
import { RestaurantItemsPageComponent } from './components/restaurant-items-page/restaurant-items-page.component';
import { CartComponent } from './components/cart/cart.component';
import { OrdersComponent } from './components/orders/orders.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'restaurants', component: RestaurantPageComponent },
  { path: 'restaurants/:id', component: RestaurantItemsPageComponent },
  { path: 'cart', component: CartComponent },
  { path: 'orders/:status', component: OrdersComponent },
];
