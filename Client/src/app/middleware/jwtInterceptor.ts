import { Injectable } from '@angular/core'
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class JwtInterceptor implements HttpInterceptor {
  constructor(private readonly authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let currentUser: User;
    this.authService.currentUser$.pipe(take(1)).subscribe(user => currentUser = !!user ? user as User : { username: '', token: '' });
    if (currentUser!) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser?.token}`
        }
      });
    }
    return next.handle(request);
  }
}



