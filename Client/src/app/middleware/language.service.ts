import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  /**
   *Get all languages
   * */
  static readonly languageList: string[] = ['uk', 'en'];
  private static readonly currentLanguageSource = new BehaviorSubject<string>(LanguageService.getLanguage());

  /**
   *Get current alnguage as observable
   * */
  readonly currentLang$ = LanguageService.currentLanguageSource.asObservable();

  /**
   * Static method to set language (if language is not in language list then do nothing)
   * @param lang language to set to
   */
  static changeLanguage(lang: string): void {
    if (!!lang && LanguageService.languageList.includes(lang.toLowerCase())) {
      lang = lang.toLowerCase();
      LanguageService.currentLanguageSource.next(lang);
      localStorage.setItem('language', lang);
    }
  }

  /**
   *Get current language
   * */
  get currentLang(): string {
    return LanguageService.currentLanguageSource.getValue();
  }

  /**
   *Static getter to get current language
   * */
  static get lang(): string {
    return LanguageService.currentLanguageSource.getValue();
  }

  /**
   *Get language from storage
   * */
  private static getLanguage(): string {
    let lang = localStorage.getItem('language');
    if (!lang) {
      lang = LanguageService.getDefaultLanguage();
    }
    return lang;
  }

  /**
   *Get default language (first from list) ans save it to local storage and in to Behavior suject
   * */
  private static getDefaultLanguage() {
    const lang = LanguageService.languageList[0];
    localStorage.setItem('language', lang);
    LanguageService.changeLanguage(lang);
    return lang;
  }
}
