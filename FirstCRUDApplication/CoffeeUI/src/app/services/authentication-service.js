var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { IntegrationService } from './integration-service';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { Router } from '@angular/router';
import { AppConfig } from './../configuration/config.component';
var AuthenticationService = /** @class */ (function () {
    function AuthenticationService(integrationService, errorHandler, router, config) {
        var _this = this;
        this.integrationService = integrationService;
        this.errorHandler = errorHandler;
        this.router = router;
        this.config = config;
        this.config.getConfigs().subscribe(function (data) {
            _this.webTokenUrl = data['webToken'];
        });
    }
    AuthenticationService.prototype.login = function (companyData) {
        var _this = this;
        this.integrationService.sendData(companyData, this.webTokenUrl).subscribe(function (result) {
            if (result) {
                localStorage.setItem('currentUser', JSON.stringify(result.body));
                _this.router.navigate(['/admin/home']);
            }
        }, function (err) {
            _this.errorHandler.handleError(err);
        });
    };
    AuthenticationService.prototype.logout = function () {
        localStorage.removeItem('currentUser');
        this.router.navigate(['/home']);
    };
    AuthenticationService.prototype.isLogin = function () {
        if (localStorage.getItem('currentUser') !== null) {
            return true;
        }
        else {
            return false;
        }
    };
    AuthenticationService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [IntegrationService,
            GlobalErrorHandlerService,
            Router,
            AppConfig])
    ], AuthenticationService);
    return AuthenticationService;
}());
export { AuthenticationService };
//# sourceMappingURL=authentication-service.js.map