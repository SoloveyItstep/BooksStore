import { Injectable } from "@angular/core"
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { LanguageService } from "../middleware/language.service";
import { AuthService } from "../services/auth.service";


@Injectable({
  providedIn: 'root'
})
export class AccountLinkGuard implements CanActivate {

  constructor(private readonly authService: AuthService, private readonly router: Router, private readonly langService: LanguageService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.isLoggedIn) {
      return true;
    }
    this.router.navigateByUrl(`${this.langService.currentLang}/login`);
    return false;
  }

}
