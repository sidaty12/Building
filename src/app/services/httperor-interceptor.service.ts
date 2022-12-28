import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

export class HttpErrorInterceptorService implements HttpInterceptor {

  intercept(request: HttpRequest<any>, next: HttpHandler) {
      console.log('HTTP Request started');
      return next.handle(request);
  }

}
