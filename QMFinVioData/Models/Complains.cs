using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QMFinVioData.Models
{
	public class Complains
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("Date received")]
		public string DateReceived { get; set; }
		public string  Product { get; set; }
		
		[BsonElement("Sub-product")]
		public string SubProduct { get; set; }

		public string Issue { get; set; }

		[BsonElement("Sub-issue")]
		public string SubIssue { get; set; }

		[BsonElement("Consumer complaint narrative")]
		public string ComplainNarrative { get; set; }

		[BsonElement("Company public response")]
		public string PublicResponse { get; set; }

		public string Company { get; set; }
		public string State { get; set; }

		[BsonElement("ZIP code")]
		public string Zip { get; set; }

		public string Tags { get; set; }

		[BsonElement("Consumer consent provided?")]
		public string IsConsumerConsentProvided { get; set; }

		[BsonElement("Submitted via")]
		public string SubmissionMode { get; set; }

		[BsonElement("Date sent to company")]
		public string DateSentToCompany { get; set; }

		[BsonElement("Company response to consumer")]
		public string CompanyReponseToConsumer { get; set; }

		[BsonElement("Timely response?")]
		public string IsTimelyResponse { get; set; }

		[BsonElement("Complaint ID")]
		public int ComplainId { get; set; }
	}

}
