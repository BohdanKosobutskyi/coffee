var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { CompanyService } from './company.service';
import { FormBuilder, Validators } from '@angular/forms';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
var CompanyComponent = /** @class */ (function () {
    function CompanyComponent(rest, fb, errorHandler) {
        this.rest = rest;
        this.fb = fb;
        this.errorHandler = errorHandler;
        this.companyData = { email: '', title: '', password: '' };
        this.cardForm = fb.group({
            materialFormCardNameEx: ['', Validators.required],
            materialFormCardEmailEx: ['', [Validators.email, Validators.required]],
            materialFormCardConfirmEx: ['', Validators.required],
            materialFormCardPasswordEx: ['', Validators.required]
        });
    }
    CompanyComponent.prototype.addCompany = function () {
        var _this = this;
        this.rest.addCompany(this.companyData).subscribe(function (result) { }, function (err) {
            _this.errorHandler.handleError(err);
        });
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], CompanyComponent.prototype, "companyData", void 0);
    CompanyComponent = __decorate([
        Component({
            selector: 'app-company',
            templateUrl: './company.component.html',
            styleUrls: ['./company.component.css'],
            providers: [CompanyService]
        }),
        __metadata("design:paramtypes", [CompanyService, FormBuilder, GlobalErrorHandlerService])
    ], CompanyComponent);
    return CompanyComponent;
}());
export { CompanyComponent };
//# sourceMappingURL=company.component.js.map