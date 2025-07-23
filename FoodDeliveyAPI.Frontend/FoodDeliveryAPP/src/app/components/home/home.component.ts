import { Component, OnInit, inject } from '@angular/core';
import { ItemsService } from '../../service/items.service';
import { ItemComponent } from '../item/item.component';
import { CommonModule } from '@angular/common';
import { Item } from '../../models/Item';
import { HeaderComponent } from '../header/header.component';
import { LoginComponent } from '../auth/login/login.component';
import { LandingComponent } from "../landing/landing.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ItemComponent, CommonModule, HeaderComponent, LoginComponent, LandingComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [ItemsService],
})
export class HomeComponent implements OnInit {
  itemservice: ItemsService = inject(ItemsService);
  showLoginPage: boolean = false;
  items: Item[] = [];

  ngOnInit() {
    this.itemservice.getItems().subscribe((res) => {
      this.items = res;
    });
  }

  toggleLoginPage($event: boolean) {
    this.showLoginPage = !this.showLoginPage;
  }
}
