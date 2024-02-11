import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Credentials } from '../models/Credentials';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = `https://localhost:7146`;
  httpClient:HttpClient = inject(HttpClient);
  constructor() { }
  signIn(credential:Credentials){
    return this.httpClient.post(`${this.url}/authentication/admin`,credential);
  }
}
