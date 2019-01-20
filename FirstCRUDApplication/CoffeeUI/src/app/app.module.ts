import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { HomeComponent } from './home.component';
import { CompanyComponent } from './company/company.component';
import { GlobalErrorComponent } from './global-error.component';
import { UserListComponent } from './user/user-list.component';
import { CompanyListComponent } from './company/company-list.component';
import { HomeAdminComponent } from './admin/home/home.component';
import { HeaderComponent } from './header/header.component';
import { HeaderAdminComponent } from './header/header.admin.component';


// MDB Angular Free
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MDBBootstrapModule , CheckboxModule, WavesModule, ButtonsModule, InputsModule, IconsModule, ChartsModule } from 'angular-bootstrap-md'

import { GlobalErrorHandlerService } from './global-error-handler.service';

import { LoginComponent } from './login/login.component';

import { JwtInterceptor } from './helpers/jwt.interceptor';

// определение маршрутов
const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: CompanyComponent },
  { path: 'error', component: GlobalErrorComponent },
  { path: 'superadmin/emulator/users', component: UserListComponent },
  { path: 'superadmin/emulator/companies', component: CompanyListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin/home', component: HomeAdminComponent }
];


@NgModule({
  declarations: [HeaderAdminComponent, HeaderComponent, AppComponent, LoginComponent, HomeComponent, HomeAdminComponent, CompanyComponent, GlobalErrorComponent, UserListComponent, CompanyListComponent],
  imports: [BrowserModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    CheckboxModule,
    IconsModule,
    MDBBootstrapModule.forRoot(),
    ButtonsModule,
    ChartsModule,
    InputsModule.forRoot(),
    WavesModule.forRoot()],
  providers: [
    GlobalErrorHandlerService,
    { provide: ErrorHandler, useClass: GlobalErrorHandlerService },
    {
        provide: HTTP_INTERCEPTORS,
        useClass: JwtInterceptor,
        multi: true
    },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
