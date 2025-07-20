import { CommonModule } from '@angular/common';
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { LoaderService } from '../../../service/loader/loader.service';

@Component({
  selector: 'app-top-loader',
  standalone: true,
  imports: [CommonModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  template: ` <div
    *ngIf="loader.loading$ | async"
    class="fixed top-0 left-0 w-full h-1.5 z-50"
  >
    <div
      class="h-full bg-indigo-600 animate-pulse transition-all duration-300"
    ></div>
  </div>`,
  styleUrl: './top-loader.component.css',
})
export class TopLoaderComponent {
  constructor(public loader: LoaderService) {
    // The loader service is injected to access the loading state
  }
}
