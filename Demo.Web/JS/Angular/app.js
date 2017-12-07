var app = angular.module('app', ['angular-loading-bar', 'ngAnimate', 'ui.bootstrap'])
  .config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
    cfpLoadingBarProvider.spinnerTemplate = '<div></div>';
  }])