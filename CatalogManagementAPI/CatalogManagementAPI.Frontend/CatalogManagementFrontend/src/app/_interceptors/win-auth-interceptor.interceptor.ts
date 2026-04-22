import { Injectable } from '@angular/core';
import { environment } from "../Environments/environment";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class WinAuthInterceptorInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({ withCredentials: true, headers: request.headers.append('Access-Control-Allow-Credentials', 'true').append("Access-Control-Allow-Origin", "*") })
    request.headers.append("Access-Control-Allow-Origin", environment.API_BASE);
    //request.headers.set('','');
    return next.handle(request)
  }
}
