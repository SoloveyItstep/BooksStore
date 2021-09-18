import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BooksService } from './services/books.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavbarComponent } from './shared/components/nav/navbar.component';
import { FormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService } from './services/auth.service';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './middleware/httpInterceptor';
import { JwtInterceptor } from './middleware/jwtInterceptor';
import { BookComponent } from './components/book/book.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { ErrorComponent } from './components/error/error.component';
import { BooksRoutingModule } from './route.moule';
import { ApplicationinsightsAngularpluginErrorService } from '@microsoft/applicationinsights-angularplugin-js';
import { AppInsightsService } from './middleware/applicationInsightsService';
import { AccountComponent } from './components/userComponents/account/account.component';
import { LogginComponent } from './components/userComponents/login/loggin.component';
import { RegisterComponent } from './components/userComponents/register/register.component';
import { AboutUsComponent } from './components/about-components/about-us/about-us.component';
import { DeliveryComponent } from './components/about-components/delivery/delivery.component';
import { PaymentInfoComponent } from './components/about-components/payment-info/payment-info.component';
import { LanguageService } from './middleware/language.service';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BookComponent,
    BooksListComponent,
    ErrorComponent,
    AccountComponent,
    LogginComponent,
    RegisterComponent,
    AboutUsComponent,
    DeliveryComponent,
    PaymentInfoComponent,
    PageNotFoundComponent
  ],
  imports: [
    BooksRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [
    AppInsightsService,
    BooksService,
    AuthService,
    LanguageService,
    { provide: ErrorHandler, useClass: ApplicationinsightsAngularpluginErrorService },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
