using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QMFinVioData.Services;
using QMFinVioData.Models;
using System.Threading.Tasks;

namespace FinVolTest
{
	[TestClass]
	public class SearchControllerTest
	{
		[TestMethod]
		public async Task TestGetByFilter()
		{
			//db.complains.find({Company : 'NRA Group, LLC', Product : 'Other financial service'})
			var filter = new ComplainFilters { Company = "NRA Group, LLC" , Product = "Other financial service" };

			var srchctrl = new SearchController();
			var result = await srchctrl.GetVio(filter);

			//Console.WriteLine(Newtonsoft.Json.JsonConvert.ToString(result));

			Assert.AreEqual(result.Count, 1);
		}
	}
}
