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
import { ActivatedRoute } from '@angular/router';
var GlobalErrorComponent = /** @class */ (function () {
    function GlobalErrorComponent(route) {
        var _this = this;
        this.route = route;
        this.route.queryParams.subscribe(function (queryParam) {
            _this.statusText = queryParam['statusText'];
            _this.message = queryParam['error'];
        });
    }
    GlobalErrorComponent = __decorate([
        Component({
            template: "\n        <h2>{{statusText}}</h2>\n        <h2>Error message : {{message}}</h2>"
        }),
        __metadata("design:paramtypes", [ActivatedRoute])
    ], GlobalErrorComponent);
    return GlobalErrorComponent;
}());
export { GlobalErrorComponent };
//# sourceMappingURL=global-error.component.js.map