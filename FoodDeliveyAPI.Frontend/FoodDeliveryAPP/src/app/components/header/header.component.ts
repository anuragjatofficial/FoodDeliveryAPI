import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,CommonModule,LoginComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{
  authToken:string = '';
  showUserMenu:boolean = false;
  showLoginForm:boolean = false;
  constructor(){

  }

  ngOnInit(): void {
    const tokenString = localStorage.getItem('token');
    if(tokenString!=null){
      const token =  JSON.parse(tokenString);
      this.authToken = token?.authToken;
    }
   
  }

  toggleLoginForm(event:boolean){
    this.showLoginForm = event;
  }

  signOut(){
    localStorage.removeItem('token');
    this.showUserMenu = false;
  }

  toggleUserMenu(value:boolean){
    this.showUserMenu = value;
  }

}
