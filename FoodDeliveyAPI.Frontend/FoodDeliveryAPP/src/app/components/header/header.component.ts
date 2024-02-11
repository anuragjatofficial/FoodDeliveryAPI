import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{
  authToken:string = '';
  @Output()loginForm: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(){

  }

  ngOnInit(): void {
    this.authToken = localStorage.getItem('token') ?? '';
  }

  showLoginForm(){
    if(!this.authToken){
      this.loginForm.emit(true);
    }
  }

}
