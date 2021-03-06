var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControl } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';
import { Router } from '@angular/router';
var HeaderAdminComponent = /** @class */ (function () {
    function HeaderAdminComponent(integrationService, fb, errorHandler, elem, authenticationService, router) {
        this.integrationService = integrationService;
        this.fb = fb;
        this.errorHandler = errorHandler;
        this.elem = elem;
        this.authenticationService = authenticationService;
        this.router = router;
        this.loginFormModalEmail = new FormControl('', Validators.email);
        this.loginFormModalPassword = new FormControl('', Validators.required);
        this.loginData = { email: '', password: '' };
        this.cardFormLogin = fb.group({
            materialFormCardPasswordLoginEx: ['', Validators.required],
            materialFormCardEmailLoginEx: ['', Validators.required]
        });
    }
    HeaderAdminComponent.prototype.login = function () {
        this.authenticationService.login(this.loginData);
    };
    HeaderAdminComponent.prototype.logout = function () {
        this.authenticationService.logout();
    };
    HeaderAdminComponent.prototype.isLogin = function () {
        return this.authenticationService.isLogin();
    };
    HeaderAdminComponent.prototype.goToUsers = function () {
        this.router.navigate(['/admin/users']);
    };
    HeaderAdminComponent.prototype.goToPosts = function () {
        this.router.navigate(['/admin/posts']);
    };
    HeaderAdminComponent.prototype.goToHome = function () {
        this.router.navigate(['/admin/home']);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], HeaderAdminComponent.prototype, "loginData", void 0);
    HeaderAdminComponent = __decorate([
        Component({
            selector: 'header-admin',
            templateUrl: './header.admin.component.html',
            styleUrls: ['./header.admin.component.css'],
            providers: [IntegrationService, AuthenticationService]
        }),
        __metadata("design:paramtypes", [IntegrationService,
            FormBuilder,
            GlobalErrorHandlerService,
            ElementRef,
            AuthenticationService,
            Router])
    ], HeaderAdminComponent);
    return HeaderAdminComponent;
}());
export { HeaderAdminComponent };
//# sourceMappingURL=header.admin.component.js.map