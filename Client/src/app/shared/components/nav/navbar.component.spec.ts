import { TestBed } from '@angular/core/testing';
import { NavbarComponent } from './navbar.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        NavbarComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(NavbarComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });
});
