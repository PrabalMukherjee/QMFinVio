(function () {

    angular.module('finvol').constant('fvConstants', {
        APP_TITLE: 'Financial Complains Database',
        APP_DESCRIPTION: 'Gives you ability to search complains on financial companies.',
        APP_VERSION: '1.0',
        FV_GETVIO_SVC: '/api/Search/GetVio',
        FV_GETCOMPANIES_SVC: '/api/search/companies'
    });
})();