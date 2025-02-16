import { Component, Input } from '@angular/core';
import { Order } from '../../../models/Order';

@Component({
  selector: 'app-order-item',
  standalone: true,
  imports: [],
  template:`
  <div class="border-2 rounded-lg h-full w-[400px]">
  <div class="w-full h-[60%]">
    <img
      src="https://loremflickr.com/random?food,{{ 'item.name' }}"
      alt="Eight shirts arranged on table in black, olive, grey, blue, white, red, mustard, and green."
      class="rounded-t-lg h-full w-full object-cover"
    />
  </div>
  <div class="p-4 h-[40%] justify-between flex flex-col">
    <div class="">
      <h3 class="text-lg font-semibold">
        <a> <span aria-hidden="true" class=" "></span>{{ "item.name" }} </a>
      </h3>
      <p class="text-[#9ea3ac] font-normal py-2">
        {{ "item.description" }}
      </p>
    </div>
    <div class="flex justify-between items-center">
      <div>
        <p class="italic text-[#a39292]">8 colors</p>
        <p class="font-medium text-[#3c3939]">{{ "item.price" }}</p>
      </div>
      <div class="flex flex-col">
        
        <button
          class="bg-[#e54e46] px-5 text-[#ddd7d7] font-medium py-1 rounded-md"
        >
          Remove from cart
        </button>

      </div>
    </div>
  </div>
</div>
`,
  styleUrl: './order-item.component.css'
})
export class OrderItemComponent {
  @Input() order!:Order;
}
