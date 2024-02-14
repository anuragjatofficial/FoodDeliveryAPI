import { CommonModule } from '@angular/common';
import { Component, Input, inject } from '@angular/core';
import { Item } from '../../models/Item';
import { ItemsService } from '../../service/items.service';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './item.component.html',
  styleUrl: './item.component.css'
})
export class ItemComponent {
  @Input() item!:Item ;
  itemService:ItemsService = inject(ItemsService);

  addToCart(){
    

    this.itemService.addToCart(this.item).subscribe({
      next:(res)=> console.log(res),
      error:(e)=>console.log(e)
    });
  }

}
