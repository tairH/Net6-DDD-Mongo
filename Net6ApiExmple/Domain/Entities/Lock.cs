using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Net6ApiExmple.Domain.Entities
{
	[BsonCollection("Lock")]
    public class Lock : Document
	{
		public Lock()
        { }

		//[BsonElement("SiteId")]
		public Int16 SiteId { get; set; }

		//[BsonElement("OrderStatus")]
		public OrderStatus OrderStatus { get; set; }
    }
}

