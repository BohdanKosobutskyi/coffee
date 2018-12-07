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
import { UserHttpService } from './user-http.service';
import { GlobalErrorHandlerService } from '../global-error-handler.service';
import { AppConfig } from './../configuration/config.component';
var UserListComponent = /** @class */ (function () {
    function UserListComponent(httpService, errorHandler, config) {
        var _this = this;
        this.httpService = httpService;
        this.errorHandler = errorHandler;
        this.config = config;
        this.users = [];
        this.headElements = ['ID', 'Phone', 'Password', 'Register Date'];
        this.config.getConfigs().subscribe(function (data) {
            _this.userList = data['userList'];
            _this.httpService.getUsers(_this.userList).subscribe(function (data) { _this.users = data; }, function (err) {
                _this.errorHandler.handleError(err);
            });
        });
    }
    UserListComponent = __decorate([
        Component({
            selector: 'user-list',
            templateUrl: './user-list.component.html',
            styleUrls: ['./user-list.component.css'],
            providers: [UserHttpService, AppConfig]
        }),
        __metadata("design:paramtypes", [UserHttpService, GlobalErrorHandlerService, AppConfig])
    ], UserListComponent);
    return UserListComponent;
}());
export { UserListComponent };
//# sourceMappingURL=user-list.component.js.map