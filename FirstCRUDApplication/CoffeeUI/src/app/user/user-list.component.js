var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
var UserListComponent = /** @class */ (function () {
    function UserListComponent() {
        this.elements = [
            { id: 1, first: 'Mark', last: 'Otto', handle: '@mdo' },
            { id: 2, first: 'Jacob', last: 'Thornton', handle: '@fat' },
            { id: 3, first: 'Larry', last: 'the Bird', handle: '@twitter' },
        ];
        this.headElements = ['ID', 'First', 'Last', 'Handle'];
    }
    UserListComponent = __decorate([
        Component({
            selector: 'user-list',
            templateUrl: './user-list.component.html',
            styleUrls: ['./user-list.component.css'],
        })
    ], UserListComponent);
    return UserListComponent;
}());
export { UserListComponent };
//# sourceMappingURL=user-list.component.js.map