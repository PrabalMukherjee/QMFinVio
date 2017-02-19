(function () {
    var app = angular.module('finvol', ['ngAnimate', 'ui.grid', 'ngRoute', 'ngMaterial']); //'ngTouch',
    app.config(function ($routeProvider) {
        $routeProvider.when("/main", {
            templateUrl: "/UI/spaViews/SearchView.html",
            controller: "uiSearchController"
        }).otherwise({ redirectTo: "/main" });
    });
}());

