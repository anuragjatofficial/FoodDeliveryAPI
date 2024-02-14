import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Credentials } from '../models/Credentials';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url = `https://localhost:7146`;
  httpClient:HttpClient = inject(HttpClient);
  private cookieService: CookieService = inject(CookieService);


  constructor() { }

  signIn(credential:Credentials){
    return this.httpClient.post(`${this.url}/authentication/admin`,credential);
  }

  storeInfoInCookie(token:string,userId:string){
    this.cookieService.set('token', token,undefined,undefined,undefined,true,"Lax");
    this.cookieService.set('userId', userId,undefined,undefined,undefined,true,"Lax");
  }

}
