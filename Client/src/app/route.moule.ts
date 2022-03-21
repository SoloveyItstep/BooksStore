import { NgModule, OnInit } from '@angular/core';
import { Routes, RouterModule, Router, NavigationStart } from '@angular/router';
import { AccountComponent } from './components/userComponents/account/account.component';
import { BookComponent } from './components/book/book.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { ErrorComponent } from './components/error/error.component';
import { LogginComponent } from './components/userComponents/login/loggin.component';
import { AccountLinkGuard } from './guards/account-link.guard';
import { RegisterComponent } from './components/userComponents/register/register.component';
import { AboutUsComponent } from './components/about-components/about-us/about-us.component';
import { DeliveryComponent } from './components/about-components/delivery/delivery.component';
import { PaymentInfoComponent } from './components/about-components/payment-info/payment-info.component';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { LanguageService } from './middleware/language.service';
import { MainComponent } from './components/main/main-page/main.component';

const routes: Routes = [
  { path: ':lang', component: MainComponent },
  { path: ':lang/app-error', component: ErrorComponent },
  { path: ':lang/book/:id', component: BookComponent },
  { path: ':lang/account', component: AccountComponent, canActivate: [AccountLinkGuard] },
  { path: ':lang/login', component: LogginComponent },
  { path: ':lang/register', component: RegisterComponent },
  { path: ':lang/about-us', component: AboutUsComponent },
  { path: ':lang/delivery', component: DeliveryComponent },
  { path: ':lang/payment', component: PaymentInfoComponent },
  { path: ':lang/not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: `${LanguageService.lang}/not-found`, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class BooksRoutingModule { }
