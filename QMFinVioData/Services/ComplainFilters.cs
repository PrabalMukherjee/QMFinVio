using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using QMFinVioData.Models;

namespace QMFinVioData.Services
{
	public class ComplainFilters
	{
		public string Company { get; set; }
		public string Product { get; set; }

		public string SubProduct { get; set; }

		public FilterDefinition<Complains> ToFilterDefinition()
		{
			var filterDef = Builders<Complains>.Filter.Empty;

			if (!String.IsNullOrWhiteSpace(Company))
				filterDef &= Builders<Complains>.Filter.Where(c => c.Company == Company);

			if (!String.IsNullOrWhiteSpace(Product))
				filterDef &= Builders<Complains>.Filter.Where(c => c.Product == Product);

			if (!String.IsNullOrWhiteSpace(SubProduct))
				filterDef &= Builders<Complains>.Filter.Where(c => c.SubProduct == SubProduct);

			return filterDef;
		}
	}
}