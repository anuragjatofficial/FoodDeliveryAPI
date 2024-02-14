import { Component, EventEmitter, Output, inject } from '@angular/core';
import { AuthService } from '../../../service/auth.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule, JsonPipe } from '@angular/common';
import { BeatLoaderComponent } from '../../loaders/beat-loader/beat-loader.component';
import { Token } from '../../../models/Token';  

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule,BeatLoaderComponent,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  authService:AuthService = inject(AuthService);
  @Output()ToggleLogin:EventEmitter<boolean> =  new EventEmitter<boolean>();
  isLoading:boolean = false;
  constructor(){}

  credentials:FormGroup = new FormGroup({
    username: new FormControl<string>(''),
    password: new FormControl<string>(''),
  });

  signIn(){
    this.isLoading = true;
    this.authService.signIn({
      username:this.credentials.value.username ?? '',
      password: this.credentials.value.password ??''
    }).subscribe((res:any)=>{
      
      this.authService.storeInfoInCookie(res?.authToken,res?.userId);

      localStorage.setItem('token',JSON.stringify(res));
      
      
      this.isLoading = false;
      this.togglePage();
      console.log(res);
    })
  }

  togglePage(){
    this.ToggleLogin.emit(false);
  }
}
