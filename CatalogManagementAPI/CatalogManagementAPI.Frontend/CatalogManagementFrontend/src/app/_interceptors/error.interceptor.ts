import { inject, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(public router: Router, public toastr: ToastrService ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    return next.handle(request).pipe(
      catchError(
        (error: any) => {
          const modalStateErrors = [];
          if (error.status === 400) {
            if (error.error.errors) {
              for (const key in error.error.errors) {
                if (error.error.errors[key]) {
                    modalStateErrors.push(error.error.errors[key]);
                }
              }
              throw modalStateErrors.flat();
            }
            else {
              this.toastr.error(error.error, error.status);
            }
          } else if (error.status === 401) {
            this.toastr.error('Unathorised.', error.status);
          } else if (error.status === 404) {
            this.router.navigateByUrl('/not-found')
          } else if (error.status === 500) {
            const navigationExtras: NavigationExtras = {state:{error: error.error}};
            this.router.navigateByUrl('/internal-server-error', navigationExtras);
          } else {
            this.toastr.error('An error occurred. Please try again later.');
          }
          
          throw error;
        }
      )
    );
  }
}