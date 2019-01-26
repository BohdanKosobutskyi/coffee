var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
var GlobalErrorHandlerService = /** @class */ (function () {
    function GlobalErrorHandlerService(injector) {
        this.injector = injector;
    }
    GlobalErrorHandlerService.prototype.handleError = function (error) {
        var router = this.injector.get(Router);
        //console.log('URL: ' + router.url);
        if (error instanceof HttpErrorResponse) {
            //Backend returns unsuccessful response codes such as 404, 500 etc.				  
            console.error('Backend returned status code: ', error.statusText);
            console.error('Response body:', error.error);
        }
        else {
            //A client-side or network error occurred.
            console.error('Backend returned status code: ', error.statusText);
            console.error('An error occurred:', error.message);
        }
        router.navigate(['/error'], {
            queryParams: {
                'statusText': error.statusText,
                'error': error.error
            }
        });
    };
    GlobalErrorHandlerService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [Injector])
    ], GlobalErrorHandlerService);
    return GlobalErrorHandlerService;
}());
export { GlobalErrorHandlerService };
//# sourceMappingURL=global-error-handler.service.js.map