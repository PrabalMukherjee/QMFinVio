(function () {
    var app = angular.module('finvol', ['ngAnimate', 'ui.grid', 'ngRoute', 'ngMaterial']); 
    app.config(function ($routeProvider) {
        $routeProvider.when("/main", {
            templateUrl: "/UI/spaViews/SearchView.html",
            controller: "uiSearchController",
            controllerAs: 'srch'
        })
        .when("/test",
        {
            templateUrl: "/UI/spaViews/test.html",
            controller: "anotherController",
            controllerAs: 'ctrl'
        })
        .otherwise({ redirectTo: "/main" });
    });
}());

