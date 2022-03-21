import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PromotionShort } from '../../../models/promotions/promotionShort';

@Component({
  selector: 'promotions-carousel',
  templateUrl: './promotions-carousel.component.html',
  styleUrls: ['./promotions-carousel.component.scss']
})
export class PromotionsCarouselComponent implements OnInit {

  constructor() { }

  @Input() promotions: Observable<PromotionShort[]> | undefined;

  ngOnInit(): void {
  }

}
