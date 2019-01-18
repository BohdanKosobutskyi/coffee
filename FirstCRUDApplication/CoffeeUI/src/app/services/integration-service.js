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
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
var IntegrationService = (function () {
    function IntegrationService(http) {
        this.http = http;
    }
    IntegrationService.prototype.getAll = function (apiEndpoint) {
        return this.http.get(apiEndpoint);
    };
    IntegrationService.prototype.sendData = function (postBody, url) {
        var httpHeaders = new HttpHeaders({
            'Content-Type': 'application/json'
        });
        return this.http.post(url, postBody, {
            headers: httpHeaders,
            observe: 'response'
        }).pipe(catchError(function (error) {
            return throwError(error);
        }));
    };
    return IntegrationService;
}());
IntegrationService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [HttpClient])
], IntegrationService);
export { IntegrationService };
//# sourceMappingURL=integration-service.js.map