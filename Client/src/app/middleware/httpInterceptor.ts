import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { catchError, Observable, throwError } from "rxjs";
import { ApplicationInsights, IExceptionTelemetry, SeverityLevel } from '@microsoft/applicationinsights-web';
import { environment } from '../../environments/environment';
import { AppInsightsService } from "./applicationInsightsService";


@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private readonly router: Router, private readonly toastr: ToastrService,
              private readonly appInsights: AppInsightsService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      catchError(error => {
        if (error) {
          this.appInsights.trackError({ id: '1', error: error.error, exception: error.error, severityLevel: SeverityLevel.Error });
          switch (error.status) {
            case 400:
              const err = error?.error?.errors;
              if (err) {
                const modalStateErrors = [];
                for (const key in err) {
                  if (err[key]) {
                    modalStateErrors.push(err[key]);
                  }
                }
                throw modalStateErrors;
              }
              else {
                this.toastr.error(error.statusText, error.status);
              }
              break;
            case 401:
              this.toastr.error(error.statusText, error.status);
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras: NavigationExtras = {
                state: {
                  error: error.error
                }
              }
              this.router.navigateByUrl('/app-error', navigationExtras);
              break;
            default:
              this.toastr.error('something went wrong');
              console.log(error);
              break;
          }
        }
        throw error;
      })
    )
  }

}
