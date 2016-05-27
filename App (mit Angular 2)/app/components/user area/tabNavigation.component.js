System.register(['angular2/core'], function(exports_1, context_1) {
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
    var core_1;
    var TabNavigationComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            TabNavigationComponent = (function () {
                function TabNavigationComponent() {
                    this.selectedTab = 'live';
                }
                TabNavigationComponent.prototype.liveTabClicked = function () {
                    this.selectedTab = 'live';
                };
                TabNavigationComponent.prototype.actualTabClicked = function () {
                    this.selectedTab = 'actual';
                };
                TabNavigationComponent.prototype.modelViewListTabClicked = function () {
                    this.selectedTab = 'modelViewList';
                };
                TabNavigationComponent = __decorate([
                    core_1.Component({
                        selector: 'tab-navigation',
                        directives: [],
                        providers: [],
                        template: "\n    <div class=\"col s12\">\n      <ul class=\"tabs\">\n      <!--class=\"active\"-->\n        <li class=\"tab col s4 light-blue\"><a href=\"#live\" (click)=\"liveTabClicked()\" [ngClass]=\"(selectedTab == 'live') ? 'active' : 'none'\">Live</a></li>\n        <li class=\"tab col s4 light-blue\"><a href=\"#actual\" (click)=\"actualTabClicked()\" [ngClass]=\"(selectedTab == 'actual') ? 'active' : 'none'\">Aktuelle</a></li>\n        <li class=\"tab col s4 light-blue\"><a href=\"#MVList\" (click)=\"modelViewListTabClicked()\" [ngClass]=\"(selectedTab == 'modelViewList') ? 'active' : 'none'\">Gespeicherte</a></li>\n      </ul>\n    </div>\n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], TabNavigationComponent);
                return TabNavigationComponent;
            }());
            exports_1("TabNavigationComponent", TabNavigationComponent);
        }
    }
});
//# sourceMappingURL=tabNavigation.component.js.map