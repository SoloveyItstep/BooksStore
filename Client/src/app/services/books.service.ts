import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { catchError, map, Observable, of } from "rxjs";

import { IBook } from '../models/booksModels/book';
import { environment } from '../../environments/environment'

@Injectable()
export class BooksService{
  //private baseUrl: string = 'https://localhost:44337/api'; //local
  constructor(private readonly http: HttpClient) { }

  getAllBooks(): Observable<IBook[]> {
    const url = `${environment.baseUrl}/books/books`;
    return this.http.get<IBook[]>(url)
      .pipe(map(x => x))
      .pipe(catchError(err => {
        console.log(err);
        return of([]);
      }));
  }

  get400() {
    return this.http.post(`${environment.baseUrl}/error/get400`, {}).pipe(catchError(err => of({
      '':''
    })));
  }

  get401() {
    return this.http.post(`${environment.baseUrl}/error/get401`, {}).pipe(catchError(err => of({
      '': ''
    })));
  }

  get404() {
    return this.http.post(`${environment.baseUrl}/error/get404`, {}).pipe(catchError(err => of({
      '': ''
    })));
  }

  get500() {
    return this.http.post(`${environment.baseUrl}/error/get500`, {}).pipe(catchError(err => of({
      '': ''
    })));
  }

  get400Validation() {
    return this.http.post(`${environment.baseUrl}/error/get400validation`, {}).pipe(catchError(err => of({
      '': ''
    })));
  }
}
