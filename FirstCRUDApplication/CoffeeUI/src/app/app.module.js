var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './home.component';
import { CompanyComponent } from './company/company.component';
import { GlobalErrorComponent } from './global-error.component';
import { UserListComponent } from './user/user-list.component';
import { UserListAdminComponent } from './admin/user/user-list.admin.component';
import { CompanyListComponent } from './company/company-list.component';
import { HomeAdminComponent } from './admin/home/home.component';
import { HeaderComponent } from './header/header.component';
import { HeaderAdminComponent } from './header/header.admin.component';
// MDB Angular Free
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MDBBootstrapModule, CheckboxModule, WavesModule, ButtonsModule, InputsModule, IconsModule } from 'angular-bootstrap-md';
import { GlobalErrorHandlerService } from './global-error-handler.service';
import { AppConfig } from './configuration/config.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ChartsModule } from 'ng2-charts';
// определение маршрутов
var appRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: CompanyComponent },
    { path: 'error', component: GlobalErrorComponent },
    { path: 'superadmin/emulator/users', component: UserListComponent },
    { path: 'superadmin/emulator/companies', component: CompanyListComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin/home', component: HomeAdminComponent },
    { path: 'admin/users', component: UserListAdminComponent }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [UserListAdminComponent, HeaderAdminComponent, HeaderComponent, AppComponent, LoginComponent, HomeComponent, HomeAdminComponent, CompanyComponent, GlobalErrorComponent, UserListComponent, CompanyListComponent],
            imports: [BrowserModule,
                ChartsModule,
                HttpModule,
                RouterModule.forRoot(appRoutes),
                FormsModule,
                HttpClientModule,
                ReactiveFormsModule,
                CheckboxModule,
                IconsModule,
                MDBBootstrapModule.forRoot(),
                ButtonsModule,
                InputsModule.forRoot(),
                WavesModule.forRoot()],
            providers: [
                AppConfig,
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
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map