import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { Item } from '../../../models/Item';
import { CommonModule } from '@angular/common';
import { BeatLoaderComponent } from '../../loaders/beat-loader/beat-loader.component';
import { OrderService } from '../../../service/order.service';
import { Message, MessageService } from 'primeng/api';
import { Order } from '../../../models/Order';

@Component({
  selector: 'app-checkout-popup',
  standalone: true,
  imports: [CommonModule, BeatLoaderComponent],
  templateUrl: './checkout-popup.component.html',
  styleUrl: './checkout-popup.component.css',
  providers: [MessageService],
})
export class CheckoutPopupComponent {
  @Input() items!: Item[];
  @Output() toggleCheckoutEvent: EventEmitter<void> = new EventEmitter<void>();
  @Output() showToastEvent: EventEmitter<Message> = new EventEmitter<Message>();
  isLoading: boolean = false;
  orderService: OrderService = inject(OrderService);
  message: Message = {};

  calculateCartTotal() {
    return this.items.reduce((total, item) => total + item.price, 0);
  }

  ToggleCheckOut() {
    this.toggleCheckoutEvent.emit();
  }

  placeOrder() {
    this.orderService.placeOrder().subscribe({
      next: (order: Order) => {
        this.showToast();
        this.ToggleCheckOut();
      },
    });
  }

  showToast() {
    this.message.severity = 'success';
    this.message.summary = 'Order Placed';
    this.message.detail = 'Order has been placed succesfully !';
    this.showToastEvent.emit(this.message);
  }
}
