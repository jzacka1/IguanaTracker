using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace IguanaTracker.Data.Data.ViewModels
{
	public class IguanaLinkViewModel
	{
		private string link;

		public string Link { 
			get{
				return link;
			}
			set {
				link = HttpUtility.UrlDecode(value);
			} 
		}
		public Iguana Iguana { get; set; }
	}
}
