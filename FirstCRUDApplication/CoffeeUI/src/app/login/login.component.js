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
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication-service';
import { IntegrationService } from '../services/integration-service';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(formBuilder, router, authenticationService) {
        this.formBuilder = formBuilder;
        this.router = router;
        this.authenticationService = authenticationService;
        this.loading = false;
        this.submitted = false;
        this.loginData = { email: '', password: '' };
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.loginForm = this.formBuilder.group({
            materialFormCardPasswordEx: ['', Validators.required],
            materialFormCardEmailEx: ['', Validators.required]
        });
        // reset login status
        this.authenticationService.logout();
    };
    LoginComponent.prototype.onSubmit = function () {
        this.loading = true;
        this.authenticationService.login(this.loginData);
        this.loading = false;
        this.router.navigate(['/admin/home']);
    };
    __decorate([
        Input(),
        __metadata("design:type", Object)
    ], LoginComponent.prototype, "loginData", void 0);
    LoginComponent = __decorate([
        Component({
            selector: 'login',
            templateUrl: './login.component.html',
            providers: [AuthenticationService, IntegrationService]
        }),
        __metadata("design:paramtypes", [FormBuilder,
            Router,
            AuthenticationService])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map