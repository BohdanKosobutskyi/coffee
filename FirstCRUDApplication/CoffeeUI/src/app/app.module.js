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
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home.component';
import { CompanyComponent } from './company/company.component';
import { GlobalErrorComponent } from './global-error.component';
import { UserListComponent } from './user/user-list.component';
import { CompanyListComponent } from './company/company-list.component';
import { HomeAdminComponent } from './admin/home/home.component';
// MDB Angular Free
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MDBBootstrapModule, CheckboxModule, WavesModule, ButtonsModule, InputsModule, IconsModule, ChartsModule } from 'angular-bootstrap-md';
import { GlobalErrorHandlerService } from './global-error-handler.service';
import { LoginComponent } from './login/login.component';
// определение маршрутов
var appRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: CompanyComponent },
    { path: 'error', component: GlobalErrorComponent },
    { path: 'superadmin/users', component: UserListComponent },
    { path: 'superadmin/companies', component: CompanyListComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin/home', component: HomeAdminComponent }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [AppComponent, LoginComponent, HomeComponent, HomeAdminComponent, CompanyComponent, GlobalErrorComponent, UserListComponent, CompanyListComponent],
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
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map