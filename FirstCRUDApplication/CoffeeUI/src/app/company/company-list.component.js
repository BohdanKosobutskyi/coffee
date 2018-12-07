var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { IntegrationService } from './../services/integration-service';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { Router } from "@angular/router";
var CompanyListComponent = /** @class */ (function () {
    function CompanyListComponent(router, integrationService, errorHandler, config) {
        var _this = this;
        this.router = router;
        this.integrationService = integrationService;
        this.errorHandler = errorHandler;
        this.config = config;
        this.companies = [];
        this.headElements = ['ID', 'Email', 'Title', 'Is Approved', 'Action'];
        this.config.getConfigs().subscribe(function (data) {
            _this.companyGetAllUrl = data['companyList'];
            _this.companyApproveUrl = data['approveCompany'];
            _this.integrationService.getAll(_this.companyGetAllUrl).subscribe(function (data) { _this.companies = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        });
    }
    CompanyListComponent.prototype.approveCompany = function (company_id, is_approved) {
        var _this = this;
        if (is_approved === true)
            return;
        var postBody = {
            company_id: company_id,
            is_approved: is_approved
        };
        this.integrationService.sendData(postBody, this.companyApproveUrl).subscribe(function (result) { }, function (err) {
            _this.errorHandler.handleError(err);
        });
        this.router.navigate(['/superadmin/companies']);
    };
    CompanyListComponent = __decorate([
        Component({
            selector: 'company-list',
            templateUrl: './company-list.component.html',
            styleUrls: ['./company-list.component.css'],
            providers: [IntegrationService, AppConfig]
        }),
        __metadata("design:paramtypes", [Router, IntegrationService, GlobalErrorHandlerService, AppConfig])
    ], CompanyListComponent);
    return CompanyListComponent;
}());
export { CompanyListComponent };
//# sourceMappingURL=company-list.component.js.map