﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingApp.Models.ViewModel
{
	public class FunctionViewModel
	{
		public IEnumerable<WeddingPackage> WeddingPackages { get; set; }
		public Function Function { get; set; }
	}
}