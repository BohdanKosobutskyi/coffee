var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var HomeAdminComponent = (function () {
    function HomeAdminComponent() {
        this.chartOptions = {
            responsive: true
        };
        this.chartData = [
            { data: [330, 600, 260, 700], label: 'New users' },
            { data: [120, 455, 100, 340], label: 'New posts' }
        ];
        this.chartLabels = ['January', 'February', 'Mars', 'April'];
    }
    return HomeAdminComponent;
}());
HomeAdminComponent = __decorate([
    Component({
        selector: 'home-admin',
        templateUrl: './home.component.html'
    })
], HomeAdminComponent);
export { HomeAdminComponent };
//# sourceMappingURL=home.component.js.map