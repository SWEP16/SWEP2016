System.register(['angular2/core', './liveTab.component', './tabNavigation.component', '../../view model/session'], function(exports_1, context_1) {
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
    var core_1, liveTab_component_1, tabNavigation_component_1, session_1;
    var UserAreaComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (liveTab_component_1_1) {
                liveTab_component_1 = liveTab_component_1_1;
            },
            function (tabNavigation_component_1_1) {
                tabNavigation_component_1 = tabNavigation_component_1_1;
            },
            function (session_1_1) {
                session_1 = session_1_1;
            }],
        execute: function() {
            UserAreaComponent = (function () {
                function UserAreaComponent() {
                    this.selectedTab = 'live';
                    this.username = session_1.Session.username;
                }
                UserAreaComponent = __decorate([
                    core_1.Component({
                        selector: 'user-area',
                        directives: [liveTab_component_1.LiveTabComponent, tabNavigation_component_1.TabNavigationComponent],
                        providers: [],
                        template: "\n    <div>\n      <tab-navigation [selectedTab]=\"selectedTab\"></tab-navigation>\n      <div>\n        <live-tab *ngIf=\"selectedTab == 'live'\"></live-tab>\n\n        <div class=\"fixedBottom\">\n          <a class=\"btn light-blue fullwidth statusBar disabled\"><i class=\"material-icons left\">visibility</i> {{username}}</a>\n        </div>\n      </div>\n    </div>\n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], UserAreaComponent);
                return UserAreaComponent;
            }());
            exports_1("UserAreaComponent", UserAreaComponent);
        }
    }
});
//# sourceMappingURL=userArea.component.js.map