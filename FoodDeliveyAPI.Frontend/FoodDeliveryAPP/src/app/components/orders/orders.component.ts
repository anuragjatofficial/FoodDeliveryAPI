import { Component, OnInit, inject } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { OrderService } from '../../service/order.service';
import { Order } from '../../models/Order';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { OrderItemComponent } from './order-item/order-item.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [HeaderComponent, RouterModule, OrderItemComponent, CommonModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css',
})
export class OrdersComponent implements OnInit {
  private orderService: OrderService = inject(OrderService);
  private route: ActivatedRoute = inject(ActivatedRoute);

  showOrders: string = 'all';
  allOrders: Order[] = [];
  activeOrders: Order[] = [];

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.showOrders = params.get('status') ?? 'all';
    });

    this.fetchAllOrders();
    this.fetchActiveOrders();
  }

  fetchAllOrders() {
    this.orderService.getAllOrders().subscribe({
      next: (orders: any) => {
        this.allOrders = orders;
        console.log(orders);
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        console.log(this.allOrders);
      },
    });
  }

  fetchActiveOrders() {
    this.orderService.getActiveOrders().subscribe({
      next: (orders: Order[]) => {
        this.activeOrders = orders;
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        console.log(this.activeOrders);
      },
    });
  }
}
