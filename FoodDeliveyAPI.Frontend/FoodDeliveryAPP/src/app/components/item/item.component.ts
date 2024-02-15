import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, inject } from '@angular/core';
import { Item } from '../../models/Item';
import { ItemsService } from '../../service/items.service';
import { BeatLoaderComponent } from '../loaders/beat-loader/beat-loader.component';
import { ButtonLoaderComponent } from '../loaders/button-loader/button-loader.component';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [CommonModule,ButtonLoaderComponent],
  templateUrl: './item.component.html',
  styleUrl: './item.component.css',
})
export class ItemComponent implements OnInit{
  @Input() item!: Item;
  @Input() addOrDelete!: 'ADD' | 'DEL';
  @Output() updateCartItemsEvent: EventEmitter<void> = new EventEmitter<void>();

  isAlreadyInCart:boolean = false;
  isLoading:boolean = false;

  itemService: ItemsService = inject(ItemsService);


  ngOnInit(): void {
    this.checkAlreadyIncart();
  }

  addToCart() {
    this.isLoading = true;
    this.itemService.addToCart(this.item).subscribe({
      next: (res) => console.log(res),
      error: (e) => {
        console.log(e);
        this.isLoading = false;
      },
      complete: () => {
        this.updateCartItems();
        this.checkAlreadyIncart();
        this.isLoading = false;
      },
    });
  }

  removeFromCart() {
    this.itemService.removeFromCart(this.item.itemId).subscribe({
      next: (res: Item[]) => console.log(res),
      error: (err) => console.log(err),
      complete: () => {
        this.updateCartItems();
      },
    });
  }

  updateCartItems() {
    this.updateCartItemsEvent.emit();
  }

  checkAlreadyIncart(){
    this.itemService.checkIfAlreadyInCart(this.item).subscribe({
      next:(value:boolean) =>{
        this.isAlreadyInCart = value;
      },
      error: (err)=>{
        
      },
    })
  }

}
