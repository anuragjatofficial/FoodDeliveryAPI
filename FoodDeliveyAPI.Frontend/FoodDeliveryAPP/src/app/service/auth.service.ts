import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Credentials } from '../models/Credentials';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Token } from '../models/Token';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url = `https://ominous-journey-r965xjqqvxqhp454-5275.app.github.dev`;
  httpClient: HttpClient = inject(HttpClient);
  private cookieService: CookieService = inject(CookieService);

  constructor() {}

  signIn(credential: Credentials):Observable<Token> {
    return this.httpClient.post<Token>(
      `${this.url}/authentication/customer`,
      credential
    );
  }

  storeInfoInCookie(token: string, userId: string) {
    this.cookieService.set(
      'token',
      token,
      undefined,
      undefined,
      undefined,
      true,
      'Lax'
    );
    this.cookieService.set(
      'userId',
      userId,
      undefined,
      undefined,
      undefined,
      true,
      'Lax'
    );
  }
}
