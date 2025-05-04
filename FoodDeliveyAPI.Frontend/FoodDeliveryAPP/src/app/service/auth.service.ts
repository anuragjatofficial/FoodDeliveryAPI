import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Credentials } from '../models/Credentials';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Token } from '../models/Token';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url = environment.apiUrl;
  httpClient: HttpClient = inject(HttpClient);
  private cookieService: CookieService = inject(CookieService);

  constructor() {}

  signIn(credential: Credentials): Observable<Token> {
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
