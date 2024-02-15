import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';
import { ToastModule } from 'primeng/toast';
import { Message, MessageService } from 'primeng/api';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule, LoginComponent,ToastModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  providers:[MessageService]
})
export class HeaderComponent implements OnInit {
  authToken: string = '';
  showUserMenu: boolean = false;
  showLoginForm: boolean = false;
  showHeaderMenu: boolean = false;
  messageService:MessageService = inject(MessageService);

  constructor() {}

  ngOnInit(): void {
    this.getAuthToken();
  }

  getAuthToken(){
    const tokenString = localStorage.getItem('token');
    if (tokenString != null) {
      const token = JSON.parse(tokenString);
      this.authToken = token?.authToken;
    }
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

  showToast(message:Message){
    this.messageService.add(message);
    this.getAuthToken();
  }
}
