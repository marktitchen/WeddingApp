using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingApp.Models
{
	public class Enquiry
	{
		[Required]
		public int Id { get; set; }
		public string Message { get; set; }
		public int EnquiryCategoryId { get; set; }

		public EnquiryCategory EnquiryCategory { get; set; }
	}
}