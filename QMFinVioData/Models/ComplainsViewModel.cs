using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QMFinVioData.Models
{
	public class ComplainsViewModel
	{
		public string Company { get; set; }
		public string Product { get; set; }
		public string SubProduct { get; set; }
		public string Narrative { get; set; }
		public string DateReceived { get; set; }
		public string CompanyResponse { get; set; }
	}
}