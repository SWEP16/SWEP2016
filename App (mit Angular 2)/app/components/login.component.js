System.register(['angular2/core', '../view model/session'], function(exports_1, context_1) {
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
    var core_1, session_1;
    var LoginComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (session_1_1) {
                session_1 = session_1_1;
            }],
        execute: function() {
            LoginComponent = (function () {
                function LoginComponent() {
                    this.userName = "";
                    this.networkCode = "";
                    this.userNameValid = false;
                    this.networkCodeValid = false;
                }
                LoginComponent.prototype.login = function () {
                    if (this.isValid()) {
                        console.log("Hallo " + this.userName);
                        session_1.Session.isLoggedIn = true;
                        session_1.Session.username = this.userName;
                    }
                    else {
                        console.log("Eingaben sind nicht valide");
                    }
                };
                LoginComponent.prototype.isValid = function () {
                    return (this.validateUserName() && this.validateNetworkCode());
                };
                LoginComponent.prototype.validateUserName = function () {
                    if (this.userName.length >= 3) {
                        this.userNameValid = true;
                        return true;
                    }
                    else {
                        this.userNameValid = false;
                        return false;
                    }
                };
                LoginComponent.prototype.validateNetworkCode = function () {
                    return (this.networkCode.length == 8);
                };
                LoginComponent = __decorate([
                    core_1.Component({
                        selector: 'login',
                        directives: [],
                        providers: [],
                        template: "\n    <div class=\"row\">\n      <form class=\"col s12\">\n        <div class=\"row\">\n        <center><h2 class=\"oswlad\">PROTOTYP APP</h2></center>\n          <div class=\"input-field col s12\">\n            <input [(ngModel)]=\"userName\"\n              [ngClass]=\"(userName.length > 0) ? (validateUserName() ? 'success' : 'failed') : 'none'\"\n              type=\"text\" class=\"validate\">\n            <label for=\"username\">Username</label>\n          </div>\n          <div class=\"input-field col s12 \">\n            <input [(ngModel)]=\"networkCode\"\n              [ngClass]=\"(networkCode.length > 0) ? (validateNetworkCode() ? 'success' : 'failed') : 'none'\"\n              type=\"text\" class=\"validate\">\n            <label for=\"code\">Code</label>\n          </div>\n          <div class=\"input-field col s12\">\n            <a class=\"waves-effect waves-light btn light-blue fullwidth\" (click)=\"login()\">connect</a>\n          </div>\n        </div>\n      </form>\n    </div>\n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], LoginComponent);
                return LoginComponent;
            }());
            exports_1("LoginComponent", LoginComponent);
        }
    }
});
//# sourceMappingURL=login.component.js.map