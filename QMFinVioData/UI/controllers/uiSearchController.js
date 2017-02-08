(function () {
    var uiSearchController = function (scope, log ,uiGridConstants, searchfinvol) {

        scope.filter = searchfinvol.filterStub;

        scope.gridViolations = {
            enableFiltering: true,
            flatEntityAccess: true,
            showGridFooter: true,
            fastWatch: true
        };

        scope.gridViolations.columnDefs = searchfinvol.resGridColDefs;

        scope.search = function (filter) {

            var successCallback = function (response) {
                log.info("Search completed.");
                scope.gridViolations.data = response;
            };

            var errorCallback = function (error) {
                log.error(error);
            };
            log.info("Searching for ");
            log.info(filter);

            searchfinvol.filterComplains(filter).then(successCallback, errorCallback);
        };

    };

    var app = angular.module('finvol');
    app.controller("uiSearchController", ["$scope","$log" ,"uiGridConstants","searchfinvol", uiSearchController]);
}());
