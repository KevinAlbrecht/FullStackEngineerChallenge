import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AuthService } from '@pay/shared/services';
import { ApiExceptionCode, ApiException } from '@pay/shared/models';

@Injectable({ providedIn: 'root' })
export class BaseInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    private location: Location,
    private authService: AuthService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse): Observable<any> {
    const exception: ApiException = {
      exceptionMessage: err.message,
      exceptionCode: null,
    };
    switch (err.status) {
      default:
      case 400:
        exception.exceptionCode = ApiExceptionCode.BadRequest;
        break;
      case 401:
        exception.exceptionCode = ApiExceptionCode.NotAuthenticated;
        break;
      case 403:
        exception.exceptionCode = ApiExceptionCode.NotAuthorized;
        break;
      case 404:
        exception.exceptionCode = ApiExceptionCode.NotFound;
        break;
    }
    return throwError(exception);
  }
}
