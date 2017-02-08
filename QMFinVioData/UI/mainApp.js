(function () {
    var app = angular.module('finvol', ['ngAnimate', 'ngTouch', 'ui.grid', 'ngRoute']);
    app.config(function ($routeProvider) {
        $routeProvider.when("/main", {
            templateUrl: "/UI/spaViews/SearchView.html",
            controller: "uiSearchController"
        }).otherwise({ redirectTo: "/main" });
    });
}());

