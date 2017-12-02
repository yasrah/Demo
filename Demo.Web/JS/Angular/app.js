var app = angular.module('app', ['angular-loading-bar', 'ngAnimate'])
  .config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
    cfpLoadingBarProvider.spinnerTemplate = '<div></div>';
  }])