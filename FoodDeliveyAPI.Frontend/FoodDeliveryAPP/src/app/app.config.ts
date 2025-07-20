import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import {
  HTTP_INTERCEPTORS,
  HttpClientModule,
  provideHttpClient,
  withInterceptors,
} from '@angular/common/http';
import {
  BrowserAnimationsModule,
  provideAnimations,
} from '@angular/platform-browser/animations';
import { loaderInterceptor } from './interceptors/loader.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimations(),
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(BrowserAnimationsModule),
    provideHttpClient(withInterceptors([loaderInterceptor])),
    // Add any other providers you need here
  ],
};
