import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationStart, Router, Routes } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { AppInsightsService } from './middleware/applicationInsightsService';
import { LanguageService } from './middleware/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title: string = 'Books store';
  private routerSubscription: Subscription | undefined;
  bodyClass: string = "body-max";

  constructor(private readonly appInsights: AppInsightsService,
              private readonly router: Router,
              private readonly translate: TranslateService) {
    this.appInsights.trackPage({ name: 'App loaded', pageType: 'main', uri: '/' });
    this.translate.addLangs(LanguageService.languageList);
    this.translate.setDefaultLang(LanguageService.lang);
  }

  ngOnInit(): void {

    /**
     *event to catch route redirects
     */
    this.routerSubscription = this.router.events.subscribe(event => {
      // if event is on route start
      if (event instanceof NavigationStart) {
        const nav = event as NavigationStart;
        const routes = this.getRoutes(this.router.config);  //get all routs
        const url = this.getUrl(routes, nav.url);   //get urrent url if it is right or 404
        // check if the url changed, then redirect
        if (nav.url !== url) {
          this.router.navigate([url])
        }
      }
    })
  }

  ngOnDestroy(): void {
    //if event xists then unsubscribe
    if (this.routerSubscription) {
      this.routerSubscription.unsubscribe();
    }
  }

  /**
   * 
   */
  changeTop($event: boolean) {
    this.bodyClass = $event ? "body-max" : "body-min";
  }

  /**
   * Get routes from the Router configuration
   * @param routes array of routes
   */
  private getRoutes(routes: Routes): string[] {
    const urls: string[] = [];
    // if routes exisits
    if (routes) {
      //get all routes (paths) from router config
      routes.forEach(x => {
        //get the only those, which starts with 'lang' parameter
        if (x?.path?.startsWith(':lang')) {
          urls.push(x.path);
        }
      });
    }
    return urls;

  }

  /**
   * Get current url if it is correct, otherwise get redirect url
   * @param routes routes from the Route configuration
   * @param url current url 
   */
  private getUrl(routes: string[], url: string): string {
    let lang = LanguageService.lang;
    const langList = LanguageService.languageList;

    // if url is default
    if (url === '/' || url === `/${lang}`) {
      return `/${lang}`;
    }
    //get url segments
    const urlSegments = url.split('/');
    //get potential language segment
    const urlLangSegment = urlSegments[1];
    //if the segment is not valid then return default url
    if (!urlLangSegment) {
      return `/${lang}`;
    }
    //if lang segment has the correct length
    if (urlLangSegment.length === 2) {
      //if the segment is a language and it is not current lang, then change current lang
      if (langList.includes(urlLangSegment.toLowerCase()) && urlLangSegment !== lang) {
        LanguageService.changeLanguage(urlLangSegment);
        lang = urlLangSegment.toLowerCase();
      }
      //if segment not in languages list, then return 404
      if (!langList.includes(urlLangSegment.toLowerCase())) {
        return `/${lang}/not-found`;
      }
      //try to find right url
      let newUrl = `/${lang}`;
      for (let i = 2; i < urlSegments.length; ++i) {
        newUrl += `/${urlSegments[i]}`;
      }
      //check if the new url is correct
      const templateUrl = newUrl.replace(`/${urlLangSegment}`, ':lang');
      if (routes.includes(templateUrl)) {
        return newUrl;
      }
    }
    else {
      //try to guess if the user writes a url without a language segment
      let newUrl = '';
      routes.forEach(route => {
        if (route.endsWith(url.toLowerCase())) {
          newUrl = `/${lang}${url}`;
        }
      });
      if (newUrl !== '') {
        return newUrl;
      }
    }
    //entered url is not valid. Returning 404
    return `/${lang}/not-found`;
  }

}
