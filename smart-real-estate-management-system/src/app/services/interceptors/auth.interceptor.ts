import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');
   console.log("Token1", token)
    if (token) {
      const cloned = request.clone({
        headers: request.headers.set('Authorization', `Bearer ${token}`)
      });
      console.log("cloned", cloned)
      return next.handle(cloned);
    }

    return next.handle(request);
  }
}

