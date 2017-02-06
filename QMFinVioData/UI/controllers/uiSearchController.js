var uiSearchController = function (scope, http, uiGridConstants) {
	scope.message = "Hello from controller";

	scope.filter = {
		Company: '',
		Product: '',
		SubProduct: ''
	};

	scope.gridViolations = {
		enableFiltering: true,
		flatEntityAccess: true,
		showGridFooter: true,
		fastWatch: true
	};

	scope.gridViolations.columnDefs = [
		{ name: 'Company' },
		{ name: 'Product' },
		{ name: 'SubProduct' },
		{ name: 'CompanyResponse' },
		{ name: 'DateReceived' },
		{ name: 'Narrative' }
	];

	scope.search = function (filter) {

		var successCallback = function (response) {
			scope.gridViolations.data = response.data;
		};

		var errorCallback = function (error) {

		};

		http.post('/api/Search/GetVio', filter).then(successCallback, errorCallback);
	};

};