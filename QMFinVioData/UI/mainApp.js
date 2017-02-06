(function () {
	var app = angular.module('finvol', ['ngAnimate', 'ngTouch','ui.grid']);
	app.controller("uiSearchController", ["$scope", "$http" ,"uiGridConstants", uiSearchController]);

}());