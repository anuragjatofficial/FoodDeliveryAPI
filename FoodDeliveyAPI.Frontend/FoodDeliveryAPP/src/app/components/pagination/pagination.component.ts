import { CommonModule, NgFor } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule, NgFor],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css',
})
export class PaginationComponent {
  @Input() totalEntries!: number;
  @Output() changePageData: EventEmitter<number> = new EventEmitter<number>();
  currentPage: number = 1;

  changePage(page: number) {
    this.changePageData.emit(page);
    this.currentPage = page;
  }

  goBack(page: number) {
    if (this.currentPage > 1) {
      this.changePageData.emit(page);
      this.currentPage = page;
    }
  }

  goForward(page: number) {
    if (!(this.currentPage >= this.totalEntries)) {
      this.changePageData.emit(page);
      this.currentPage = page;
    }
  }
}
