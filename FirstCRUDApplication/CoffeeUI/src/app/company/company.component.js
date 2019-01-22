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
import { AppConfig } from './../configuration/config.component';
import { IntegrationService } from './../services/integration-service';
import { AuthenticationService } from '../services/authentication-service';
import { Router } from '@angular/router';
var CompanyComponent = (function () {
    function CompanyComponent(integrationService, fb, errorHandler, config, elem, authenticationService, router) {
        var _this = this;
        this.integrationService = integrationService;
        this.fb = fb;
        this.errorHandler = errorHandler;
        this.config = config;
        this.elem = elem;
        this.authenticationService = authenticationService;
        this.router = router;
        this.loginFormModalEmail = new FormControl('', Validators.email);
        this.loginFormModalPassword = new FormControl('', Validators.required);
        this.companyData = { email: '', title: '', password: '', phone: '' };
        this.loginData = { email: '', password: '' };
        if (this.authenticationService.isLogin()) {
            this.router.navigate(['/admin/home']);
        }
        this.cardForm = fb.group({
            materialFormCardNameEx: ['', Validators.required],
            materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
            materialFormCardConfirmEx: ['', Validators.required],
            materialFormCardPasswordEx: ['', Validators.required],
            materialFormCardPhoneEx: ['', Validators.required]
        });
        this.cardFormLogin = fb.group({
            materialFormCardPasswordLoginEx: ['', Validators.required],
            materialFormCardEmailLoginEx: ['', Validators.required]
        });
        this.config.getConfigs().subscribe(function (data) {
            _this.companyAddUrl = data['companyAdd'];
        });
    }
    CompanyComponent.prototype.addCompany = function () {
        var _this = this;
        this.integrationService.sendData(this.companyData, this.companyAddUrl).subscribe(function (result) {
            _this.resultRegister = "Your company was succesffuly registered, please wait for approving";
        }, function (err) {
            _this.errorHandler.handleError(err);
        });
    };
    CompanyComponent.prototype.login = function () {
        this.authenticationService.login(this.loginData);
    };
    return CompanyComponent;
}());
__decorate([
    Input(),
    __metadata("design:type", Object)
], CompanyComponent.prototype, "companyData", void 0);
__decorate([
    Input(),
    __metadata("design:type", Object)
], CompanyComponent.prototype, "loginData", void 0);
CompanyComponent = __decorate([
    Component({
        selector: 'app-company',
        templateUrl: './company.component.html',
        styleUrls: ['./company.component.css'],
        providers: [AppConfig, IntegrationService, AuthenticationService]
    }),
    __metadata("design:paramtypes", [IntegrationService,
        FormBuilder,
        GlobalErrorHandlerService,
        AppConfig,
        ElementRef,
        AuthenticationService,
        Router])
], CompanyComponent);
export { CompanyComponent };
//# sourceMappingURL=company.component.js.map