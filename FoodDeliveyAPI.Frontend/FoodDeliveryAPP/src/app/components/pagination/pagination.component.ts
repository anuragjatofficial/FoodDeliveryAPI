import { CommonModule, NgFor } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule,NgFor],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent {

  @Input() totalEntries!: number;
  @Output() changePageData:EventEmitter<number> = new EventEmitter<number>();
  currentPage:number = 1;

  changePage(page:number) {
    this.changePageData.emit(page);
    this.currentPage = page;
  }

}
