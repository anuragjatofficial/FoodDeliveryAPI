import { Component, OnInit, inject } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { ItemComponent } from '../item/item.component';
import { CommonModule } from '@angular/common';
import { Item } from '../../models/Item';
import { ItemsService } from '../../service/items.service';
import { CheckoutPopupComponent } from './checkout-popup/checkout-popup.component';
import { ToastModule } from 'primeng/toast';
import { Message, MessageService } from 'primeng/api';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    HeaderComponent,
    ItemComponent,
    CommonModule,
    CheckoutPopupComponent,
    ToastModule,
  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
  providers: [MessageService],
})
export class CartComponent implements OnInit {
  items: Item[] = [];
  showCheckout: boolean = false;
  private messageService: MessageService = inject(MessageService);

  itemService: ItemsService = inject(ItemsService);

  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems() {
    this.itemService.getCartItems().subscribe((res: Item[]) => {
      this.items = res;
    });
  }

  calculateCartTotal() {
    return this.items.reduce((total, item) => total + item.price, 0);
  }

  ToggleCheckout() {
    this.showCheckout = !this.showCheckout;
  }

  showToast(message: Message) {
    this.messageService.add(message);
    this.refreshCart();
  }

  refreshCart() {
    this.loadCartItems();
  }
}
