import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpEventType,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService, NavigationService } from '@core';
import { tap } from 'rxjs/operators';
import { accessTokenKey } from '../constants';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private localStorageService: LocalStorageService,
    private redirectService: NavigationService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      tap(
        (httpEvent: HttpEvent<any>) => httpEvent,
        error => {
          if (error instanceof HttpErrorResponse && error.status === 401) {
            this.localStorageService.put({ name: accessTokenKey, value: null });
            this.redirectService.redirectToLogin();
          }
        }
      )
    );
  }
}
