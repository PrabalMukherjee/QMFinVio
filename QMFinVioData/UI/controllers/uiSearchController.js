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

        scope.ac = {
            simulateQuery: false,
            isDisabled: false,
            noCache: true            
        };

        scope.ac.Companies = loadAll();

        scope.ac.querySearch = function (query) {
            var results = query ? scope.ac.Companies.filter(createFilterFor(query)) : scope.ac.Companies,
                deferred;
            if (scope.ac.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        };

        scope.ac.selectedItemChange = function (item) {
            scope.filter.Company = item.display;
            log.info('Item changed to ' + JSON.stringify(item));

        };

        scope.ac.searchTextChange = function (text) { log.info('Text changed to ' + text); };


        function loadAll() {
            var successCallback = function (response) {
                scope.ac.Companies = response;
            };

            var errorCallback = function (error) {
                log.error(error);
            };

            searchfinvol.Companies().then(successCallback, errorCallback);
        };

        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);

            return function filterFn(co) {
                return (co.value.indexOf(lowercaseQuery) === 0);
            };

        }
    };

    var app = angular.module('finvol');
    var ctrl = app.controller("uiSearchController", ["$scope", "$log", "uiGridConstants", "searchfinvol", uiSearchController]);
   
}());
