import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LanguageService } from '../../../middleware/language.service';
import { LoginUser } from '../../../models/security/loginUser';
import { User } from '../../../models/user';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  model: LoginUser = { username: '', password: '' };
  currentUser: Observable<User | null> | undefined;

  constructor(public readonly authService: AuthService,
              public readonly langService: LanguageService,
              private readonly router: Router) { }

  ngOnInit(): void {
    this.currentUser = this.authService.currentUser$;
  }

  async login() {
    const response = await this.authService.loginUser(this.model);
    console.log(response);
  }
  logout() {
    this.authService.logout();
  }

  changeLanguage(lang: string) {
    if (lang === LanguageService.lang) {
      return;
    }
    const newUrl = this.getNewLangUrl(lang);
    LanguageService.changeLanguage(lang);
    this.router.navigate([newUrl]);
  }


  private getNewLangUrl(lang: string): string {
    return this.router.url.replace(LanguageService.lang, lang);
  }

}


