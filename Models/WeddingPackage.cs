//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace WeddingApp.Models
//{
//	public class WeddingPackage
//	{
//		[Required]
//		public int Id { get; set; }

//		[Required]
//		[DisplayName("Wedding Package")]
//		public string Name { get; set; }
//	}
//}

////////////////////////////////////
/////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingApp.Models
{
	public class WeddingPackage
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[DisplayName("Wedding Package")]
		public string Name { get; set; }
	}
}