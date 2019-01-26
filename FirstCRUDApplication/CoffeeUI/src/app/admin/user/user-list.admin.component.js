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
import { GlobalErrorHandlerService } from '../../global-error-handler.service';
import { AppConfig } from '../../configuration/config.component';
import { IntegrationService } from '../../services/integration-service';
var UserListAdminComponent = /** @class */ (function () {
    function UserListAdminComponent(integrationService, errorHandler, config) {
        var _this = this;
        this.integrationService = integrationService;
        this.errorHandler = errorHandler;
        this.config = config;
        this.users = [];
        this.headElements = ['ID', 'Phone', 'Password', 'Register Date', 'Is Confirm', 'Actions'];
        this.config.getConfigs().subscribe(function (data) {
            _this.userGetAdminUrl = data['userListAdmin'];
            _this.userDeleteFomCompanyUrl = data['userDeleteFromCompany'];
            _this.integrationService.getAll(_this.userGetAdminUrl).subscribe(function (data) { _this.users = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        });
    }
    UserListAdminComponent.prototype.deleteUser = function (user_id) {
        var _this = this;
        var postBody = {
            user_id: user_id
        };
        this.integrationService.sendData(postBody, this.userDeleteFomCompanyUrl).subscribe(function (result) {
            _this.integrationService.getAll(_this.userGetAdminUrl).subscribe(function (data) { _this.users = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        }, function (err) {
            _this.errorHandler.handleError(err);
        });
    };
    UserListAdminComponent = __decorate([
        Component({
            selector: 'user-list-admin',
            templateUrl: './user-list.admin.component.html',
            providers: [AppConfig, IntegrationService]
        }),
        __metadata("design:paramtypes", [IntegrationService, GlobalErrorHandlerService, AppConfig])
    ], UserListAdminComponent);
    return UserListAdminComponent;
}());
export { UserListAdminComponent };
//# sourceMappingURL=user-list.admin.component.js.map