import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LanguageService } from '../../../middleware/language.service';
import { PromotionShort } from '../../../models/promotions/promotionShort';
import { promotionsType } from '../../../models/promotions/promotionsType';
import { BooksService } from '../../../services/books.service';
import { PromotionsService } from '../../../services/promotions.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  public promotions: Observable<PromotionShort[]> | undefined;

  constructor(private readonly booksService: BooksService,
              private readonly promotionsService: PromotionsService,
              private readonly langService: LanguageService) { }

  ngOnInit(): void {
    this.promotions = this.promotionsService.getPromotionsShort(this.langService.currentLang, promotionsType.active)
  }

}
