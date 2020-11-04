import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpResponse, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class Interceptor implements HttpInterceptor {
  intercept(httpRequest: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {


     httpRequest = httpRequest.clone({ url: `https://localhost:5001/${httpRequest.url}` });
     //httpRequest = httpRequest.clone({ url: `http://192.168.0.65/${httpRequest.url}` });
    

    // if (httpRequest.headers.get("skip")){
    //     return next.handle(httpRequest);
    // }
           
    // var user = JSON.parse(localStorage.getItem("user"));
    
    // httpRequest = httpRequest.clone({ headers: httpRequest.headers.set('Authorization', 'Bearer ' + user.token) });

    // httpRequest = httpRequest.clone({ headers: httpRequest.headers.set('Content-Type', 'application/json') });


    return next.handle(httpRequest);
  }
}