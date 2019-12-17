using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingApp.Models
{
	public class Function
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
		public DateTime FunctionDate { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
		public DateTime DateAdded { get; set; }
		[Required]
		//public int CustomerId { get; set; }
		public string Notes { get; set; }
		[Required]
		public int WeddingPackageId { get; set; }
		public WeddingPackage WeddingPackage { get; set; }





	}
}
	
