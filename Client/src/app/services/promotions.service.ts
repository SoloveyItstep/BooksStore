import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { catchError, map, Observable, of } from "rxjs";

import { PromotionShort } from '../models/promotions/promotionShort';
import { Promotion } from '../models/promotions/promotion';
import { promotionsType } from '../models/promotions/promotionsType';
import { environment } from '../../environments/environment';

@Injectable()
export class PromotionsService {
  constructor(private readonly http: HttpClient) { }

  getPromotionsShort(lang: string, promotionType: promotionsType): any {
    const url = `${environment.baseUrl}/Promotions/Promotions-light`;
    return this.http.post<PromotionShort[]>(url, { promotionType, language: lang })
      .pipe(map(x => x))
      .pipe(catchError(err => {
        console.log(err);
        return of([]);
      }));
  }

  getPromotions(lang: string, promotionType: promotionsType): any {
    const url = `${environment.baseUrl}/Promotions/Promotions`;
    return this.http.post<Promotion[]>(url, { promotionType, language: lang })
      .pipe(map(x => x))
      .pipe(catchError(err => {
        console.log(err);
        return of([]);
      }));
  }
}
