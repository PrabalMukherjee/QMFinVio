using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using QMFinVioData.DB;
using QMFinVioData.Models;

namespace QMFinVioData.Services
{
    public class SearchController : ApiController
    {
		public readonly DataContext dbContext = new DataContext();

		/// <summary>
		/// Get Complains by Filter parameter
		/// </summary>
		/// <param name="filter"></param>
		[HttpPost]
		public async Task<List<ComplainsViewModel>> GetVio(ComplainFilters filters)
		{
			var complains = await FilterComplains(filters).Select(c => new ComplainsViewModel
			{
				Company = c.Company,
				Product = c.Product,
				SubProduct = c.SubProduct,
				CompanyResponse = c.CompanyReponseToConsumer,
				DateReceived = c.DateReceived,
				Narrative = c.ComplainNarrative
			}).OrderBy(c => c.Product).ThenBy(c => c.SubProduct).ThenByDescending(c => c.DateReceived).ToListAsync().ConfigureAwait(false);

			return complains;
		}

		private IMongoQueryable<Complains> FilterComplains(ComplainFilters filters)
		{
			var complains = dbContext.AllComplains.AsQueryable();

			if (!String.IsNullOrWhiteSpace(filters.Company))
				complains = complains.Where(c=> c.Company == filters.Company);

			if (!String.IsNullOrWhiteSpace(filters.Product))
				complains = complains.Where(c => c.Product == filters.Product);

			if (!String.IsNullOrWhiteSpace(filters.SubProduct))
				complains = complains.Where(c => c.SubProduct == filters.SubProduct);

			return complains;
		}

        [HttpGet]
        public async Task<IHttpActionResult> Companies()
        {
            try
            {
                var companies = await dbContext.AllComplains.Distinct<string>("Company", "{}").ToListAsync().ConfigureAwait(false);
                var result = companies.Select(c => new { value = c.ToLower() , display = c });
                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
