'use strict';
var app = angular.module('app', [
  'ui.router',
  'ui.router.tabs'
]);


app.config(['$urlRouterProvider', '$stateProvider', function($urlRouterProvider, $stateProvider){
  $urlRouterProvider.otherwise('/');

  $stateProvider
    .state('login', {
      url: '/',
      templateUrl: 'views/login.html'
    });
/*
    .state('leistungen', {
      url: '/leistungen',
      templateUrl: 'templates/leistungen.html'
    })

    .state('impressum', {
      url: '/impressum',
      templateUrl: 'templates/impressum.html'
    })

    .state('agb', {
      url: '/agb',
      templateUrl: 'templates/agb.html'
    })


    .state('partner', {
      url: '/partner',
      templateUrl: 'templates/partner.html',
    })

    .state('unternehmen', {
      url: '/unternehmen',
      templateUrl: 'templates/unternehmen.html',
    })

    .state('kontakt', {
      url: '/kontakt',
      templateUrl: 'templates/kontakt.php', 
    })
      /*.state('kontakt.formular', {
        url:         'formular',
        templateUrl: 'templates/formular.php'
      })*/
}]);


