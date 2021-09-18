import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {

  constructor(private readonly httpService: BooksService, public readonly authService: AuthService) { }

  ngOnInit() {
    this.authService.initUser();
  }

  async get400() {
    return await this.httpService.get400().pipe(take(1)).toPromise();;
  }

  async get401() {
    return await this.httpService.get401().pipe(take(1)).toPromise();
  }

  async get404() {
    return await this.httpService.get404().pipe(take(1)).toPromise();
  }

  async get500() {
    return await this.httpService.get500().pipe(take(1)).toPromise();
  }

  async get400Validation() {
    return await this.httpService.get400Validation().pipe(take(1)).toPromise();
  }

}
