(function () {

    var searchService = function ($http) {

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
            return $http.post('/api/Search/GetVio', filter).then(function (response) {
                return response.data;
            });
        };

        return {
            filterStub: filterStub,
            resGridColDefs : resGridColDefs,
            filterComplains: searchComplains
        };
    };

    var app = angular.module('finvol');
    app.factory("searchfinvol", searchService);

}());