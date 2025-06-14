import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  HostListener,
  Input,
  OnInit,
  Output,
  inject,
} from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';
import { ToastModule } from 'primeng/toast';
import { Message, MessageService } from 'primeng/api';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule, LoginComponent, ToastModule],
  animations: [
    trigger('menuAnimation', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(-10px)' }),
        animate(
          '200ms ease-out',
          style({ opacity: 1, transform: 'translateY(0)' })
        ),
      ]),
      transition(':leave', [
        animate(
          '150ms ease-in',
          style({ opacity: 0, transform: 'translateY(-10px)' })
        ),
      ]),
    ]),
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  providers: [MessageService],
})
export class HeaderComponent implements OnInit {
  authToken: string = '';
  showUserMenu: boolean = false;
  showLoginForm: boolean = false;
  showHeaderMenu: boolean = false;
  messageService: MessageService = inject(MessageService);

  constructor() {}

  ngOnInit(): void {
    this.getAuthToken();
  }

  getAuthToken() {
    const tokenString = localStorage.getItem('token');
    if (tokenString != null) {
      const token = JSON.parse(tokenString);
      this.authToken = token?.authToken;
    }
  }

  @HostListener('document:click', ['$event'])
  handleClickOutside(event: MouseEvent) {
    this.showUserMenu = false;
  }

  toggleLoginForm(event: boolean) {
    this.showLoginForm = event;
  }

  signOut() {
    localStorage.removeItem('token');
    this.showUserMenu = false;
    this.getAuthToken();
  }

  toggleUserMenu(value: boolean) {
    this.showUserMenu = value;
  }

  toggleHeader() {
    this.showHeaderMenu = !this.showHeaderMenu;
  }

  showToast(message: Message) {
    this.messageService.add(message);
    this.getAuthToken();
  }
}
