import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { delay, finalize, Observable } from 'rxjs';
import { LoadingSpinnerService } from '../services/loading-spinner.service';


@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private loadingSpinnerService: LoadingSpinnerService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loadingSpinnerService.show();
    return next.handle(request).pipe(
      //delay(1000), //to see the spinner in action
      finalize(() => {
        this.loadingSpinnerService.hide();
      })
    );
  }
}