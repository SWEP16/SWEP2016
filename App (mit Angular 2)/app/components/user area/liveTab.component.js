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
    var LiveTabComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            LiveTabComponent = (function () {
                function LiveTabComponent() {
                }
                LiveTabComponent = __decorate([
                    core_1.Component({
                        selector: 'live-tab',
                        directives: [],
                        providers: [],
                        template: "\n      <div class=\"row\">\n        <div id=\"measurementSeries\" class=\"col s12 btn btn-large disabled\">\n          Wiederholungsgenauigkeit Messung\n        </div>\n      </div>\n\n      <div class=\"\">EVTL LOGO</div>\n\n      <div class=\"liveBottom\">\n          <a class=\" tab waves-effect waves-light btn light-blue fullwidth trigger\">Start</a>\n      </div>        \n    "
                    }), 
                    __metadata('design:paramtypes', [])
                ], LiveTabComponent);
                return LiveTabComponent;
            }());
            exports_1("LiveTabComponent", LiveTabComponent);
        }
    }
});
//# sourceMappingURL=liveTab.component.js.map