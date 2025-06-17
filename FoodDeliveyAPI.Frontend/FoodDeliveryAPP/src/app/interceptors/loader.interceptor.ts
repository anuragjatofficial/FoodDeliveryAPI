import { HttpInterceptorFn } from '@angular/common/http';
import { LoaderService } from '../service/loader/loader.service';
import { inject } from '@angular/core';
import { finalize } from 'rxjs';

export const loaderInterceptor: HttpInterceptorFn = (req, next) => {
  const loaderService = inject(LoaderService);
  return next(req).pipe(finalize(() => loaderService.hide()));
};
// This interceptor will show the loader when a request is made and hide it when the request is completed.
// It uses the LoaderService to manage the loading state.