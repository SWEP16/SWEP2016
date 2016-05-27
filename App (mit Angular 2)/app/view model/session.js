System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Session;
    return {
        setters:[],
        execute: function() {
            Session = (function () {
                function Session() {
                }
                Session.username = "";
                Session.isLoggedIn = false;
                Session.isExecuter = false;
                return Session;
            }());
            exports_1("Session", Session);
        }
    }
});
//# sourceMappingURL=session.js.map