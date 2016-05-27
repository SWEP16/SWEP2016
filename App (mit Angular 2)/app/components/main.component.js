System.register(['angular2/core', './login.component', './user area/userArea.component', '../view model/session'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, login_component_1, userArea_component_1, session_1;
    var MainComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (userArea_component_1_1) {
                userArea_component_1 = userArea_component_1_1;
            },
            function (session_1_1) {
                session_1 = session_1_1;
            }],
        execute: function() {
            MainComponent = (function () {
                function MainComponent() {
                }
                MainComponent.prototype.isLoggedIn = function () {
                    return session_1.Session.isLoggedIn;
                };
                MainComponent = __decorate([
                    core_1.Component({
                        selector: 'app',
                        directives: [login_component_1.LoginComponent, userArea_component_1.UserAreaComponent],
                        providers: [],
                        template: "\n        <login *ngIf=\"!isLoggedIn()\"></login>\n        <user-area *ngIf=\"isLoggedIn()\"></user-area>\n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], MainComponent);
                return MainComponent;
            }());
            exports_1("MainComponent", MainComponent);
        }
    }
});
//# sourceMappingURL=main.component.js.map