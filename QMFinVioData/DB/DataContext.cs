using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using QMFinVioData.Instrument;
using QMFinVioData.Models;
using QMFinVioData.Properties;

namespace QMFinVioData.DB
{
	public class DataContext
	{
		public IMongoDatabase Database;

		public DataContext()
		{
			var connString = Settings.Default.FinVioConnectionString;
			var settings = MongoClientSettings.FromUrl(new MongoUrl(connString));
			settings.ClusterConfigurator = builder => builder.Subscribe(new Log4NetEvents());

			var client = new MongoClient(settings);
			Database = client.GetDatabase(Settings.Default.FinVioDBName);
		}

		public IMongoCollection<Complains> AllComplains
		{
			get {
				return Database.GetCollection<Complains>("complains");
			}
		}
	}

}