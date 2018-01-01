var app = angular.module('app', ['angular-loading-bar', 'ngAnimate', 'ui.bootstrap', 'ngSanitize', 'ui-notification'])
  .config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
    cfpLoadingBarProvider.spinnerTemplate = '<div></div>';
  }])