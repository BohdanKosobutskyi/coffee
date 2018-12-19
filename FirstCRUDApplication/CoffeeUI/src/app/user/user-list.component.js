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
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
import { IntegrationService } from './../services/integration-service';
var UserListComponent = (function () {
    function UserListComponent(integrationService, errorHandler, config) {
        var _this = this;
        this.integrationService = integrationService;
        this.errorHandler = errorHandler;
        this.config = config;
        this.users = [];
        this.headElements = ['ID', 'Phone', 'Password', 'Register Date', 'Is Confirm', 'Actions'];
        this.config.getConfigs().subscribe(function (data) {
            _this.userGetAllUrl = data['userList'];
            _this.userDeleteUrl = data['userDelete'];
            _this.integrationService.getAll(_this.userGetAllUrl).subscribe(function (data) { _this.users = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        });
    }
    UserListComponent.prototype.deleteUser = function (user_id) {
        var _this = this;
        var postBody = {
            user_id: user_id
        };
        this.integrationService.sendData(postBody, this.userDeleteUrl).subscribe(function (result) {
            _this.integrationService.getAll(_this.userGetAllUrl).subscribe(function (data) { _this.users = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        }, function (err) {
            _this.errorHandler.handleError(err);
        });
    };
    return UserListComponent;
}());
UserListComponent = __decorate([
    Component({
        selector: 'user-list',
        templateUrl: './user-list.component.html',
        styleUrls: ['./user-list.component.css'],
        providers: [AppConfig, IntegrationService]
    }),
    __metadata("design:paramtypes", [IntegrationService, GlobalErrorHandlerService, AppConfig])
], UserListComponent);
export { UserListComponent };
//# sourceMappingURL=user-list.component.js.map