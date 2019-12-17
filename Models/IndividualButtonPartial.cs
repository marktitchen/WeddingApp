using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WeddingApp.Models
{
	public class IndividualButtonPartial
	{
		public string ButtonType { get; set; }
		public string Action { get; set; }
		public string Glyph { get; set; }
		public string Text { get; set; }
		//int? - a null-able value
		public int? WeddingPackageId { get; set; }
		public int? EventId { get; set; }
		public int? CustomerId { get; set; }
		public int? EnquiryCategoryId { get; set; }
		public int? FunctionId { get; set; }
		public int? EnquiryId { get; set; }

		public string ActionParameter
		{
			get
			{
				var param = new StringBuilder(@"/");

				if(EventId != null && EventId > 0)
				{
					param.Append(String.Format("{0}", EventId));
				}
				if (CustomerId != null && CustomerId > 0)
				{
					param.Append(String.Format("{0}", CustomerId));
				}
				if (WeddingPackageId != null && WeddingPackageId > 0)
				{
					param.Append(String.Format("{0}", WeddingPackageId));
				}
				if (EnquiryCategoryId != null && EnquiryCategoryId > 0)
				{
					param.Append(String.Format("{0}", EnquiryCategoryId));
				}
				if (FunctionId != null && FunctionId > 0)
				{
					param.Append(String.Format("{0}", FunctionId));
				}
				if (EnquiryId != null && EnquiryId > 0)
				{
					param.Append(String.Format("{0}", EnquiryId));
				}

				return param.ToString();

			}
		}

	}
}