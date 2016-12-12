using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuperStore.Models
{
	public class Record
	{
		public int RecordId { get; set; }

		[DataType(DataType.Date)]
		public string Date { get; set; }

		public string CustomerName { get; set; }

		public string ProductName { get; set; }

		public int Quantity { get; set; }

		public string DeliveryAddress { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

	}
}
