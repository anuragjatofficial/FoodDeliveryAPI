import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-landing',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './landing.component.html',
  styleUrl: './landing.component.css',
})
export class LandingComponent implements AfterViewInit {
  @ViewChild('categoryRow', { static: false })
  categoryRow!: ElementRef<HTMLDivElement>;
  isAtStart = true;
  isAtEnd = false;

  ngAfterViewInit() {
    this.updateScrollButtons();
  }

  scrollCategories(direction: 'left' | 'right') {
    const row = this.categoryRow.nativeElement;
    const scrollAmount = 200;
    if (direction === 'left') {
      row.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
    } else {
      row.scrollBy({ left: scrollAmount, behavior: 'smooth' });
    }
    setTimeout(() => this.updateScrollButtons(), 300);
  }

  updateScrollButtons() {
    const row = this.categoryRow.nativeElement;
    this.isAtStart = row.scrollLeft === 0;
    this.isAtEnd = row.scrollLeft + row.clientWidth >= row.scrollWidth - 1;
  }
}
