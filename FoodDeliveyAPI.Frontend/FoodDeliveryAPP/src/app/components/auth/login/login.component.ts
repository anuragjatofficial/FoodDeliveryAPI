import { Component, EventEmitter, Output, inject } from '@angular/core';
import { AuthService } from '../../../service/auth.service';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule, JsonPipe } from '@angular/common';
import { BeatLoaderComponent } from '../../loaders/beat-loader/beat-loader.component';
import { Token } from '../../../models/Token';
import { Message } from 'primeng/api';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, BeatLoaderComponent, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  @Output() ToggleLogin: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() showToastEvent: EventEmitter<Message> = new EventEmitter<Message>();

  authService: AuthService = inject(AuthService);

  message: Message = {};
  isLoading: boolean = false;
  showPassword = false;

  constructor() {}

  credentials: FormGroup = new FormGroup({
    username: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    password: new FormControl<string>('', [Validators.required]),
  });

  signIn() {
    this.isLoading = true;
    this.authService
      .signIn({
        username: this.credentials.value.username ?? '',
        password: this.credentials.value.password ?? '',
      })
      .subscribe({
        next: (res: Token) => {
          this.authService.storeInfoInCookie(res?.authToken, res?.userId);
          localStorage.setItem('token', JSON.stringify(res));
          this.isLoading = false;
          this.togglePage();
          console.log(res);

          this.message = {
            severity: 'success',
            summary: 'Login Succes',
            detail: 'You are now Logged in 🎉!',
          };

          this.showToast();
        },
        error: (err: any) => {
          this.isLoading = false;
          this.togglePage();
          console.log(err);

          this.message = {
            severity: 'error',
            summary: 'Login Fail',
            detail: 'unable to login please try again',
          };

          this.showToast();
        },
        complete: () => {},
      });
  }

  togglePage() {
    this.ToggleLogin.emit(false);
  }

  showToast() {
    this.showToastEvent.emit(this.message);
  }

  togglePassword() {
    this.showPassword = !this.showPassword;
  }
}
