import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { IBook } from '../../models/booksModels/book';
import { AuthService } from '../../services/auth.service';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

  books: Observable<IBook[]> | undefined;

  constructor(private readonly httpService: BooksService, public readonly authService: AuthService) { }

  ngOnInit() {
    this.books = this.httpService.getAllBooks();
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
