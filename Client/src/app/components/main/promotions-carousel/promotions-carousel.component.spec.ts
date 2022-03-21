import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PromotionsCarouselComponent } from './promotions-carousel.component';

describe('PromotionsCarouselComponent', () => {
  let component: PromotionsCarouselComponent;
  let fixture: ComponentFixture<PromotionsCarouselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PromotionsCarouselComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PromotionsCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
