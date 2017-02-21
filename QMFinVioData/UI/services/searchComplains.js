(function () {

    var app = angular.module('finvol');
    app.factory("searchfinvol", searchService);

    function searchService(http, fvConst) {

        var filterStub = {
            Company: '',
            Product: '',
            SubProduct: ''
        };

        var resGridColDefs = [
            { name: 'Company' },
            { name: 'Product' },
            { name: 'SubProduct' },
            { name: 'CompanyResponse' },
            { name: 'DateReceived' },
            { name: 'Narrative' }
        ];

        var searchComplains = function (filter) {
            return http.post(fvConst.FV_GETVIO_SVC, filter).then(function (response) {
                return response.data;
            });
        };

        var getAllCompanies = function () {
            return http.get(fvConst.FV_GETCOMPANIES_SVC).then(function (response) {
                return response.data;
            });
        };

        
        return {
            filterStub: filterStub,
            resGridColDefs : resGridColDefs,
            filterComplains: searchComplains,
            Companies: getAllCompanies
        };
    };

    searchService.$inject = ['$http', 'fvConstants'];
}());