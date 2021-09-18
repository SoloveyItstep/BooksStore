import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterUser } from '../models/security/registerUser';
import { UserResponse } from '../models/security/userResponse';
import { take } from 'rxjs/operators'
import { LoginUser } from '../models/security/loginUser';
import { BehaviorSubject } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private readonly http: HttpClient) { }

  async loginUser(model: LoginUser): Promise<UserResponse> {
    const url = `${environment.baseUrl}/account/login`;
    const user = await this.http.post<UserResponse>(url, model).pipe<UserResponse>(take(1)).toPromise() as UserResponse;
    if (user) {
      localStorage.setItem('user', JSON.stringify(user));
      this.currentUserSource.next({ username: user.userName, token: user.token });
    }
    return user;
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null!);
  }

  initUserFromModel(user: User) {
    this.currentUserSource.next(user);
  }

  initUser() {
    const user = this.mapUser(JSON.parse(localStorage.getItem('user')!));
    this.initUserFromModel(user);
  }

  get isLoggedIn(): boolean {
    const user = this.currentUserSource.getValue();
    if (!!user && !!user.token) {
      return true;
    }
    return false;
  }

  private mapUser(user: UserResponse): User {
    if (!user) return null as any;
    return { username: user?.userName, token: user?.token };
  }

}
