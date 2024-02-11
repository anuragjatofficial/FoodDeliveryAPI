import { Component, inject } from '@angular/core';
import { AuthService } from '../../../service/auth.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  authService:AuthService = inject(AuthService);
  constructor(){}
  credentials:FormGroup = new FormGroup({
    username: new FormControl<string>(''),
    password: new FormControl<string>(''),
  });
  signIn(){
    this.authService.signIn({
      username:this.credentials.value.username ?? '',
      password: this.credentials.value.password ??''
    }).subscribe((res:any)=>{
      localStorage.setItem('token',res.authToken ?? '');
      console.log(res);
    })
  }
}
