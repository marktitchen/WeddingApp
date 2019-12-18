using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingApp.Models
{
	public class WeddingDetails
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		[DisplayName("Wedding Fee")]
		public int Fee { get; set; }
		[Required]
		[Range(0, 1000)]
		public int NoOfGuest { get; set; }
		[Required]
		public int WeddingPackageId { get; set; }

		public WeddingPackage WeddingPackage { get; set; }
	}
}