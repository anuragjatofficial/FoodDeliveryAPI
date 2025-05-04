import { Component, Input } from '@angular/core';
import { Order } from '../../../models/Order';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-item',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="rounded-xl border shadow-md w-[400px] bg-white overflow-hidden">
      <img
        src="https://loremflickr.com/400/250/food"
        alt="Order image"
        class="w-full h-[200px] object-cover"
      />

      <div class="p-5 flex flex-col gap-4">
        <div>
          <h2 class="text-xl font-semibold text-gray-800 mb-1">
            {{ order.restaurant.restaurantName }}
          </h2>

          <ul class="text-gray-600 text-sm list-disc list-inside space-y-1">
            @for (item of order.items; track $index) {
            <li>
              {{ item.name }} -
              <span class="text-gray-800 font-medium">₹{{ item.price }}</span>
            </li>
            }
          </ul>
        </div>

        <div class="flex justify-between items-center">
          <span class="text-base font-semibold text-gray-700">
            Total: ₹{{ getTotal() }}
          </span>
          <span
            class="text-sm font-medium px-3 py-1 rounded-full"
            [ngClass]="{
              'bg-green-100 text-green-700': order.orderStatus === 'DELIVERED',
              'bg-yellow-100 text-yellow-700':
                order.orderStatus === 'PREPARED' ||
                order.orderStatus === 'PLACED',
              'bg-red-100 text-red-700': order.orderStatus === 'CANCELLED',
              'bg-blue-100 text-blue-700':
                order.orderStatus === 'RECEIVED' ||
                order.orderStatus === 'ASSIGNED' ||
                order.orderStatus === 'PICKEDUP' ||
                order.orderStatus === 'REACHED'
            }"
          >
            {{ order.orderStatus }}
          </span>
        </div>

        <button
          class="mt-2 bg-red-500 hover:bg-red-600 text-white text-sm font-semibold py-2 rounded-lg transition"
        >
          View Details
        </button>
      </div>
    </div>
  `,
  styleUrl: './order-item.component.css',
})
export class OrderItemComponent {
  @Input() order!: Order;

  getTotal(): number {
    return this.order.items.reduce((sum, item) => sum + item.price, 0);
  }
}
